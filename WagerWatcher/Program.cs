using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Xml.Serialization;
using System.Resources;
using System.Xml;
using System.Xml.XPath;
using NHibernate;
using WagerWatcher.Model;
using WagerWatcher.Model.Pool;
using WagerWatcher.Model.Results;
using WagerWatcher.Repositories;
using WagerWatcher.Services;

namespace WagerWatcher
{
    public class Program
    {
        public static ISession  Session;

        private static PoolRepository _poolRepository;
        public static PoolRepository PoolRepository
        {
            get { return _poolRepository ?? (_poolRepository = new PoolRepository()); }
        }

        static void Main(string[] args)
        {
            var year = 2012;
            var month = 3;
            var day = 7;
            var dt = new DateTime(year, month, day);
            for (var count = 1; count < 52; count++)
            {
                
                var date = dt.ToString("yyyy-MM-dd");

                var meetingsFromSchedule = GetXMLMeetingsRootFromSchedule(date);                
                var meetingsFromPool = GetXMLMeetingsRootFromPool(date);
                var meetingsFromResults = GetXMLMeetingsRootFromResults(date);

                UpdateDataBase(meetingsFromSchedule,
                                meetingsFromResults,
                                meetingsFromPool);
                Console.WriteLine(Constants.Program_Main_Completed_import_for_ + date);
                dt = dt.AddDays(7);
            }

            
        }

        public void Main(int year, int month, int day, int periodToImport)
        {
            var dt = new DateTime(year, month, day);

            for (var x = 0; x < periodToImport; x++)
            {
                var date = dt.ToString("yyyy-MM-dd");

                var meetingsFromSchedule = GetXMLMeetingsRootFromSchedule(date);
                var meetingsFromPool = GetXMLMeetingsRootFromPool(date);
                var meetingsFromResults = GetXMLMeetingsRootFromResults(date);

                UpdateDataBase(meetingsFromSchedule,
                                meetingsFromResults,
                                meetingsFromPool);
                Console.WriteLine(Constants.Program_Main_Completed_import_for_ + date);
                dt = dt.AddDays(1);
            }


        }
        public static void UpdateDataBase(  XMLMeetingsRootFromSchedule xmlMeetingsFromSchedule, 
                                            XMLMeetingsRootFromResults  xmlMeetingsFromResults, 
                                            XMLMeetingsRootFromPool     xmlMeetingsFromPool)
        {
            UpdateSchedule  (xmlMeetingsFromSchedule);
            UpdatePools     (xmlMeetingsFromPool);
            UpdateResults   (xmlMeetingsFromResults);
        }


        private static void UpdatePools(XMLMeetingsRootFromPool poolsXMLMeetings)
        {
            foreach (var xmlMeeting in  poolsXMLMeetings.meetings)
            {
                var meeting = MeetingService.GetMeetingByDateAndJetBetCode(poolsXMLMeetings.Date,
                                                                              Int32.Parse(xmlMeeting.JetBetCode));
                var races = RaceService.GetRacesInMeeting(meeting);

                foreach (var xmlRace in xmlMeeting.RacesRoot.Races)
                {
                    var race1 = xmlRace;
                    var race = races.First(r => r.RaceNum == Int32.Parse(race1.Number));

                    foreach (var xmlPool in xmlRace.PoolsRoot.pools)
                    {
                        var betType = BetTypeService.GetBetTypeByXMLDesc(xmlPool.BetType);
                        var newPool =  PoolService.BuildPoolForDB(xmlPool, betType, race);
                       
                        PoolService.AddOrUpdate(newPool);
                    }
                }
            }
            
        }

        private static void UpdateSchedule(XMLMeetingsRootFromSchedule scheduleXMLMeetings)
        {
            foreach (var xmlMeeting in scheduleXMLMeetings.Meetings)
            {
                // Check if the meeting is already in the DB and use that one if it is, otherwise things break because we end up adding
                // Duplicate meetings to the DB. (If the Meeting doesn't exist then create it. 
                var meeting = MeetingService.GetOrBuildMeetingFromSchedule(xmlMeeting.Date,
                                                                              Int16.Parse(xmlMeeting.Number), xmlMeeting);
                    
                foreach (var xmlRace in xmlMeeting.RacesRoot.Races)
                {
                    var race = RaceService.BuildRaceForDB(xmlRace, meeting);

                    RaceService.AddOrUpdate(race);
                }
            }
        }

        public static void UpdateResults(XMLMeetingsRootFromResults resultsXMLMeetings)
        {
            foreach (var xmlMeeting in resultsXMLMeetings.Meetings)
            {
                var meeting = MeetingService.GetMeetingByDateAndJetBetCode(resultsXMLMeetings.Date,
                                                                              Int32.Parse(xmlMeeting.JetBetCode));
                var races = RaceService.GetRacesInMeeting(meeting);

                foreach (var xmlRace in xmlMeeting.RacesRoot.Races)
                {
                    var race1 = xmlRace;
                    var race = races.First(r => r.RaceNum == Int32.Parse(race1.Number));

                    // Create a dictionary of the races placings <Entry number, Entry Name>

                    var placings = new Dictionary<string, string>();
                    foreach (var placing in xmlRace.PlacingsRoot.placings)
                    {
                        if (!placings.ContainsKey(placing.FinishingPosition))
                        {
                            placings.Add(placing.FinishingPosition, placing.EntryName);
                        }
                        else
                        {
                            try
                            {
                                var horseName = placings[placing.FinishingPosition];
                                var nextPosition = Int16.Parse(placing.FinishingPosition) + 1;
                                placings.Add(placing.FinishingPosition + "=", placing.EntryName);
                                placings.Add(nextPosition + "=", horseName);
                            }
                            catch (Exception ex)
                            {
                                // This will happen when three horses dead heat. will need to find a fix for it
                                Console.WriteLine(ex);
                                Console.WriteLine("Three way dead heat.");
                            }
                            
                        }
                    }

                    var alsoRan = new List<FinishingPosition>();
                    foreach (var xmlRunner in xmlRace.AlsoRanRoot.RunnersRoot.Runners)
                    {
                        alsoRan.Add(new FinishingPosition
                            {
                                HorseName = xmlRunner.EntryName,
                                HorseNumber = xmlRunner.EntryNumber,
                                Position = Int16.Parse(xmlRunner.FinishingPosition)
                            });
                    }

                    foreach (var xmlPool in xmlRace.PoolsRoot.Pools)
                    {
                        var betType = BetTypeService.GetBetTypeByXMLDesc(xmlPool.Type);
                        var pool =
                            PoolService.GetPoolFromDB(betType.BetTypeId, race.RaceId)
                            ?? PoolService.BuildPoolForDB(xmlPool, betType, race);

                        var result = ResultsService.BuildResultForDB(xmlPool, pool, placings, alsoRan);                    

                      ResultsService.Add(result);
                    }
                }
            }
        }

        private static XMLMeetingsRootFromSchedule GetXMLMeetingsRootFromSchedule(string date)
        {
            var scheduleDoc = new XmlDocument();
            scheduleDoc.Load(Constants.scheduleDownload + date);
            
            var scheduleNode = scheduleDoc.SelectSingleNode("//meetings");
            if (scheduleNode == null) return null;

            XMLMeetingsRootFromSchedule xmlMeetings = null;
            using (var reader = new StringReader(scheduleNode.OuterXml))
            {
                var serializer = new XmlSerializer(typeof (XMLMeetingsRootFromSchedule));
                xmlMeetings = (XMLMeetingsRootFromSchedule) serializer.Deserialize(reader);
            }
            return xmlMeetings;
        }

        private static XMLMeetingsRootFromResults GetXMLMeetingsRootFromResults(string date)
        {
            var resultsDoc = new XmlDocument();
            resultsDoc.Load(Constants.resultsDownload + date);
            var meetingsRootNode = resultsDoc.SelectSingleNode("//meetings");
            if (meetingsRootNode == null) return null;
            XMLMeetingsRootFromResults xmlMeetings = null;
            using (var reader = new StringReader(meetingsRootNode.OuterXml))
            {
                var serializer = new XmlSerializer(typeof(XMLMeetingsRootFromResults));
                xmlMeetings = (XMLMeetingsRootFromResults)serializer.Deserialize(reader);
            }
            return xmlMeetings;
        }

        private static XMLMeetingsRootFromPool GetXMLMeetingsRootFromPool(string date)
        {
            var poolsDoc = new XmlDocument();
            poolsDoc.Load(Constants.poolsDownload + date);
            var meetingsRootNode = poolsDoc.SelectSingleNode("//meetings");
            if (meetingsRootNode == null) return null;
            XMLMeetingsRootFromPool xmlMeetings;
            using (var reader = new StringReader(meetingsRootNode.OuterXml))
            {
                var serializer = new XmlSerializer(typeof (XMLMeetingsRootFromPool));
                xmlMeetings = (XMLMeetingsRootFromPool) serializer.Deserialize(reader);
            }
            return xmlMeetings;
        }

        public void ImportSaturdays()
        {
            var year = 2012;
            var month = 3;
            var day = 7;
            var dt = new DateTime(year, month, day);
            for (var count = 1; count < 52; count++)
            {

                var date = dt.ToString("yyyy-MM-dd");

                var meetingsFromSchedule = GetXMLMeetingsRootFromSchedule(date);
                var meetingsFromPool = GetXMLMeetingsRootFromPool(date);
                var meetingsFromResults = GetXMLMeetingsRootFromResults(date);

                UpdateDataBase(meetingsFromSchedule,
                                meetingsFromResults,
                                meetingsFromPool);
                Console.WriteLine(Constants.Program_Main_Completed_import_for_ + date);
                dt = dt.AddDays(7);
            }
        }
    }
}
