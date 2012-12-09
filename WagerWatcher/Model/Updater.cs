using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using Mindscape.LightSpeed;
using System.Xml;
using System.Xml.XPath;

namespace WagerWatcher
{
    class Updater
    {
        private XMLHelper _schedule;
        private XMLHelper _odds;
        private XMLHelper _quenella;
        private XMLHelper _results;
        private XMLHelper _pools;
        private XMLHelper _willPay;
        private static LightSpeedContext<LightSpeedStoreModelUnitOfWork> _context;
        private LightSpeedStoreModelUnitOfWork uow;


        public Updater(string date)
        {
            _schedule = new XMLHelper(Constants.scheduleDownload + date);
            _odds = new XMLHelper(Constants.oddsDownload + date);
            _quenella = new XMLHelper(Constants.quenellaDownload + date);
            _results = new XMLHelper(Constants.resultsDownload + date);
            _pools = new XMLHelper(Constants.poolsDownload + date);
            _willPay = new XMLHelper(Constants.willPayDownload + date);
            _context = new LightSpeedContext<LightSpeedStoreModelUnitOfWork>("default")
                {
                    IdentityMethod = IdentityMethod.Guid
                };
        }

        public bool UpdateRaceDay()
        {
            var success = true;

            XPathNodeIterator scheduleReader = _schedule.GetNodeSet("/schedule/meetings/meeting");

            uow = _context.CreateUnitOfWork();

            while (scheduleReader.MoveNext())
            {
                var meetingInfo = scheduleReader.Current.SelectChildren(XPathNodeType.Element);
                Meeting currentMeeting = GetMeeting(meetingInfo);
                uow.Add(currentMeeting);
            }
            uow.SaveChanges();
            uow.Dispose();
            return success;
        }

        public Meeting GetMeeting(XPathNodeIterator meetingInfo)
        {
            var currentMeeting = new Meeting();
            while (meetingInfo.MoveNext())
            {
                switch (meetingInfo.Current.LocalName)
                {
                    case "date":
                        currentMeeting.MDate = Convert.ToDateTime(meetingInfo.Current.Value);
                        break;
                    case "number":
                        currentMeeting.JetBetCode = int.Parse(meetingInfo.Current.Value);
                        break;
                    case "track_dir":
                        currentMeeting.TrackDirection = meetingInfo.Current.Value;
                        break;
                    case "venue":
                        {
                            var currentCourse = uow.RaceCourses.SingleOrDefault(c => c.CourseName == meetingInfo.Current.Value) ?? new RaceCourse();
                            if (currentCourse.CourseName == null)
                            {                        
                                currentCourse.CourseName = meetingInfo.Current.Value;
                                uow.Add(currentCourse);
                            }
                            currentMeeting.CourseId = currentCourse.Id;
                        }
                        break;
                    case "races":
                        {
                            var races = meetingInfo.Current.SelectChildren(XPathNodeType.Element);
                            while (races.MoveNext())
                            {
                                var raceInfo = races.Current.SelectChildren(XPathNodeType.Element);
                                Race currentRace = GetRace(raceInfo);
                                currentRace.MeetingId = currentMeeting.Id;
                                uow.Add(currentRace);
                            }
                        }
                        break;
                }
            }
            return currentMeeting;
        }

        public Race GetRace(XPathNodeIterator raceInfo)
        {
            var currentRace = new Race();
            while (raceInfo.MoveNext())
            {
                switch (raceInfo.Current.LocalName)
                {
                    case "length":
                        currentRace.Distance = int.Parse(raceInfo.Current.Value);
                        break;
                    case "name":
                        currentRace.RaceName = raceInfo.Current.Value;
                        break;
                    case "number":
                        currentRace.RaceNum = int.Parse(raceInfo.Current.Value);
                        break;
                    case "stake":
                        currentRace.Stake = raceInfo.Current.Value;
                        break;
                    case "track":
                        currentRace.TrackCondition = raceInfo.Current.Value;
                        break;
                    case "weather":
                        currentRace.Weather = raceInfo.Current.Value;
                        break;
                    case "options":
                        break;
                    case "entries":
                        {
                            var runners = raceInfo.Current.SelectChildren(XPathNodeType.Element);
                            while (runners.MoveNext())
                            {
                                var runnerInfo = runners.Current.SelectChildren(XPathNodeType.Element);
                                HorseInRace currentRaceHorse = GetHorseInRace(runnerInfo);
                                currentRaceHorse.RaceId = currentRace.Id;
                                uow.Add(currentRaceHorse);

                                var currentHorse = uow.Horses.SingleOrDefault(h => h.HorseName == currentRaceHorse.Name) ?? new Horse();
                                if (currentHorse.HorseName == null)
                                {
                                    currentHorse.HorseName = currentRaceHorse.Name;
                                }
                                uow.Add(currentHorse);
                            }
                        }
                        break;
                }

            }
            return currentRace;
        }

        public HorseInRace GetHorseInRace(XPathNodeIterator runnerInfo)
        {
            var currentRaceHorse = new HorseInRace();
            while (runnerInfo.MoveNext())
            {
                switch (runnerInfo.Current.LocalName)
                {
                    case "barrier":
                        currentRaceHorse.Barrier = runnerInfo.Current.Value;
                        break;
                    case "jockey":
                        currentRaceHorse.Jockey = runnerInfo.Current.Value;
                        break;
                    case "name":
                        currentRaceHorse.Name = runnerInfo.Current.Value;
                        break;
                    case "jockey_weight":
                        currentRaceHorse.JockeyWeight = decimal.Parse(runnerInfo.Current.Value);
                        break;
                }                
            }
            return currentRaceHorse;
        }
    }
}
