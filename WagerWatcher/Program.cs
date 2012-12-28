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
using WagerWatcher.Repositories;

namespace WagerWatcher
{
    public class Program
    {
        public static ISession Session;
        

        static void Main(string[] args)
        {
            
            Session = NHibernateHelper.OpenSession();
            var meetings = Objectify("2012-12-28");
            UpdateDataBase(meetings);

            /*GetSchedule("2012-12-09");*/
        }

        public static void UpdateDataBase(MeetingsRootFromXML xmlMeetings)
        {
            foreach (var xmlMeeting in xmlMeetings.Meetings)
            {
                var meeting = MeetingController.GetMeetingForDB(xmlMeeting);


                foreach (var xmlRace in xmlMeeting.RacesRoot.Races)
                {
                    var race = RaceController.BuildRaceForDB(xmlRace, meeting);

                    var raceRepo = new RaceRepository();
                    raceRepo.Add(race);

                    /* foreach (var xmlOption in xmlRace.OptionsRoot.Options)
                    {
                        var option = OptionController.BuildOptionForDB(xmlOption);
                        

                        unitOfWork.Add(option);
                    }

                    foreach (var xmlEntry in xmlRace.Entries.Entries)
                    {
                        var entry = EntryController.BuildEntryForDB(xmlEntry, race);
                        unitOfWork.Add(entry);


                    }*/
                }
                
            }
            /*foreach (var entry in xmlMeetings.Meetings.SelectMany(xmlMeeting => (
                from xmlRace in xmlMeeting.RacesRoot.Races 
                from xmlEntry in xmlRace.Entries.Entries 
                select EntryController.BuildEntryForDB(xmlEntry, xmlRace, xmlMeeting))))
            {
                unitOfWork.Add(entry);
            }
            unitOfWork.SaveChanges();*/
        }

        private static MeetingsRootFromXML Objectify(string s)
        {
            var scheduleDoc = new XmlDocument();
            scheduleDoc.Load(Constants.scheduleDownload + s);
            var scheduleNode = scheduleDoc.SelectSingleNode("schedule/meetings");
            if (scheduleNode == null) return null;
            MeetingsRootFromXML meetings = null;
            using (var reader = new StringReader(scheduleNode.OuterXml))
            {
                var serializer = new XmlSerializer(typeof (MeetingsRootFromXML));
                meetings = (MeetingsRootFromXML) serializer.Deserialize(reader);
            }
            return meetings;
        }




        /*private static void ObjectifyV(string s)
        {
            var uow = _context.CreateUnitOfWork();
            var scheduleDoc = new XmlDocument();
            scheduleDoc.Load(Constants.scheduleDownload + s);
            XmlNode scheduleNode = scheduleDoc.SelectSingleNode("schedule/meetings");
            if (scheduleNode == null) return;
            MeetingsRoot schedule = null;
            var meetings = new List<Meeting>();
            using (var reader = new StringReader(scheduleNode.OuterXml))
            {
                var serializer = new XmlSerializer(typeof (MeetingsRoot));
                schedule = (MeetingsRoot) serializer.Deserialize(reader);
            }
            foreach (var meet in schedule.Meetings)
            {
/*                meet.Id = Guid.NewGuid();#1#
                meetings.Add(meet);
                var course = uow.RaceCourses.SingleOrDefault(r => r.CourseName == meet.Venue);
                if (course == null)
                {
                    course = new RaceCourse() {CourseName = meet.Venue};
                    if (course.CourseName.Length > 19)
                    {
                        course.CourseName = course.CourseName.Substring(0, 19);
                    }
                    uow.Add(course);
                    meet.CourseId = course.Id;
                }
                else
                {
                    meet.CourseId = course.Id;
                }
                uow.Add(meet); 
                
            }
            uow.SaveChanges();
            
        }*/              
    }
}
