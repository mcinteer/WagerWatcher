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
using WagerWatcher.Controller;
using WagerWatcher.Model;
using WagerWatcher.Model.Pool;
using WagerWatcher.Model.Results;
using WagerWatcher.Repositories;

namespace WagerWatcher
{
    public class Program
    {
        public static ISession  Session;

        static void Main(string[] args)
        {
            var year = 2013;
            var month = 2;

            for (var day = 1; day < 17; day++)
            {
                var dt = new DateTime(year, month, day);
                var date = dt.ToString("yyyy-MM-dd");

                var meetingsFromSchedule = GetXMLMeetingsRootFromSchedule(date);
                var meetingsFromResults = GetXMLMeetingsRootFromResults(date);
                var meetingsFromPool = GetXMLMeetingsRootFromPool(date);

                UpdateDataBase(meetingsFromSchedule,
                                meetingsFromResults,
                                meetingsFromPool);
                Console.WriteLine("Completed import for " + date);
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
                var meeting = MeetingRepository.GetMeetingByDateAndJetBetCode(poolsXMLMeetings.Date,
                                                                              Int32.Parse(xmlMeeting.JetBetCode));
                var races = RaceRepository.GetRacesInMeeting(meeting);

                foreach (var xmlRace in xmlMeeting.RacesRoot.Races)
                {
                    var race1 = xmlRace;
                    var race = races.First(r => r.RaceNum == Int32.Parse(race1.Number));

                    foreach (var xmlPool in xmlRace.PoolsRoot.pools.FindAll(p => p.BetType == "WIN"))
                    {
                        var betType = BetTypeRepository.GetBetTypeByXMLDesc(xmlPool.BetType);
                        var pool =
                         PoolController.GetPoolFromDB(betType.BetTypeId, race.RaceId)
                         ?? PoolController.BuildPoolForDB(xmlPool, betType, race);
                    }
                }
            }
            
        }

        private static void UpdateSchedule(XMLMeetingsRootFromSchedule scheduleXMLMeetings)
        {
            foreach (var xmlMeeting in scheduleXMLMeetings.Meetings)
            {
                var meeting = MeetingController.GetMeetingFromScheduleForDB(xmlMeeting);
                foreach (var xmlRace in xmlMeeting.RacesRoot.Races)
                {
                    var race = RaceController.BuildRaceForDB(xmlRace, meeting);

                    var raceRepo = new RaceRepository();
                    raceRepo.Add(race);
                }
            }
        }

        public static void UpdateResults(XMLMeetingsRootFromResults resultsXMLMeetings)
        {
            foreach (var xmlMeeting in resultsXMLMeetings.Meetings)
            {
                var meeting = MeetingRepository.GetMeetingByDateAndJetBetCode(resultsXMLMeetings.Date,
                                                                              Int32.Parse(xmlMeeting.JetBetCode));
                var races = RaceRepository.GetRacesInMeeting(meeting);

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
                            var horseName = placings[placing.FinishingPosition];
                            var nextPosition = Int16.Parse(placing.FinishingPosition) +1;
                            placings.Add(placing.FinishingPosition +"=", placing.EntryName);
                            placings.Add(nextPosition +"=", horseName);
                        }
                    }
                        

                    foreach (var xmlRunner in xmlRace.AlsoRanRoot.RunnersRoot.Runners.Where(
                        xmlRunner => !placings.ContainsKey(xmlRunner.FinishingPosition)))
                    {
                        placings.Add(xmlRunner.FinishingPosition, xmlRunner.EntryName);
                    }

                    foreach (var xmlPool in xmlRace.PoolsRoot.Pools)
                    {
                        var betType = BetTypeRepository.GetBetTypeByXMLDesc(xmlPool.Type);
                        var pool =
                            PoolController.GetPoolFromDB(betType.BetTypeId, race.RaceId)
                            ?? PoolController.BuildPoolForDB(xmlPool, betType, race);

                        var result = ResultsController.BuildResultForDB(xmlPool, pool, placings);                    

                        var resultRepo = new ResultRepository();
                        resultRepo.Add(result);
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

    }
}
