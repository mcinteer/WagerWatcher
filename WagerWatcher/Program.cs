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
using WagerWatcher.Model.Results;
using WagerWatcher.Repositories;

namespace WagerWatcher
{
    public class Program
    {
        public static ISession Session;
        private const string Date = "2013-01-05";

        static void Main(string[] args)
        {
            Session = NHibernateHelper.OpenSession();
            var meetingsFromSchedule = GetMeetingsRootFromSchedule(Date);
            var meetingsFromResults = GetXMLMeetingsRootFromResults(Date);
            UpdateDataBase(meetingsFromSchedule, meetingsFromResults);

        }

        

        public static void UpdateDataBase(XMLMeetingsRootFromSchedule xmlMeetingsFromSchedule, XMLMeetingsRootFromResults xmlMeetingsFromResults)
        {
            UpdateSchedule(xmlMeetingsFromSchedule);
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
                                                                              xmlMeeting.JetBetCode);
                foreach (var xmlRace in meeting.Races)
                {
                    var race = RaceRepository.GetRaceByDateAndJetBetCodeAndRaceNumber(meeting.MDate,
                                                                                      meeting.JetBetCode,
                                                                                      xmlRace.RaceNum);
                    //ResultController.BuildResult(pass in the correct races result node);
                }
            }
        }




        private static XMLMeetingsRootFromSchedule GetMeetingsRootFromSchedule(string date)
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

        
    }
}
