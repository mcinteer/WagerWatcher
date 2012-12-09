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
            _context = new LightSpeedContext<LightSpeedStoreModelUnitOfWork>("default");
            _context.IdentityMethod = IdentityMethod.Guid;
        }

        public bool UpdateRaceDay()
        {
            var success = true;

            XPathNodeIterator scheduleReader = _schedule.getNodeSet("/schedule/meetings/meeting");

            uow = _context.CreateUnitOfWork();

            while (scheduleReader.MoveNext())
            {
                var meetingInfo = scheduleReader.Current.SelectChildren(XPathNodeType.Element);
                Meeting currentMeeting = getMeeting(meetingInfo);
                uow.Add(currentMeeting);
            }
            uow.SaveChanges();
            uow.Dispose();
            return success;
        }

        public Meeting getMeeting(XPathNodeIterator meetingInfo)
        {
            var currentMeeting = new Meeting();
            while (meetingInfo.MoveNext())
            {
                if (meetingInfo.Current.LocalName == "date")
                {
                    currentMeeting.MDate = Convert.ToDateTime(meetingInfo.Current.Value);
                }
                else if (meetingInfo.Current.LocalName == "number")
                {
                    currentMeeting.JetBetCode = int.Parse(meetingInfo.Current.Value);
                }
                else if (meetingInfo.Current.LocalName == "track_dir")
                {
                    currentMeeting.TrackDirection = meetingInfo.Current.Value;
                }
                else if (meetingInfo.Current.LocalName == "venue")
                {
                    var currentCourse = uow.RaceCourses.SingleOrDefault(c => c.CourseName == meetingInfo.Current.Value) ?? new RaceCourse();
                    if (currentCourse.CourseName == null)
                    {                        
                        currentCourse.CourseName = meetingInfo.Current.Value;
                        uow.Add(currentCourse);
                    }
                    currentMeeting.CourseId = currentCourse.Id;
                }
                else if (meetingInfo.Current.LocalName == "races")
                {
                    var races = meetingInfo.Current.SelectChildren(XPathNodeType.Element);
                    while (races.MoveNext())
                    {
                        var raceInfo = races.Current.SelectChildren(XPathNodeType.Element);
                        Race currentRace = getRace(raceInfo);
                        currentRace.MeetingId = currentMeeting.Id;
                        uow.Add(currentRace);
                    }
                }
            }
            return currentMeeting;
        }

        public Race getRace(XPathNodeIterator raceInfo)
        {
            var currentRace = new Race();
            while (raceInfo.MoveNext())
            {
                if (raceInfo.Current.LocalName == "length")
                {
                    currentRace.Distance = int.Parse(raceInfo.Current.Value);
                }
                else if (raceInfo.Current.LocalName == "name")
                {
                    currentRace.RaceName = raceInfo.Current.Value;
                }
                else if (raceInfo.Current.LocalName == "number")
                {
                    currentRace.RaceNum = int.Parse(raceInfo.Current.Value);
                }
                else if (raceInfo.Current.LocalName == "stake")
                {
                    currentRace.Stake = raceInfo.Current.Value;
                }
                else if (raceInfo.Current.LocalName == "track")
                {
                    currentRace.TrackCondition = raceInfo.Current.Value;
                }
                else if (raceInfo.Current.LocalName == "weather")
                {
                    currentRace.Weather = raceInfo.Current.Value;
                }
                else if (raceInfo.Current.LocalName == "options")
                { }
                else if (raceInfo.Current.LocalName == "entries")
                {
                    var runners = raceInfo.Current.SelectChildren(XPathNodeType.Element);
                    while (runners.MoveNext())
                    {
                        var runnerInfo = runners.Current.SelectChildren(XPathNodeType.Element);
                        HorseInRace currentRaceHorse = getHorseInRace(runnerInfo);
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

            }
            return currentRace;
        }

        public HorseInRace getHorseInRace(XPathNodeIterator runnerInfo)
        {
            var currentRaceHorse = new HorseInRace();
            while (runnerInfo.MoveNext())
            {
                if (runnerInfo.Current.LocalName == "barrier")
                {
                    currentRaceHorse.Barrier = runnerInfo.Current.Value;
                }
                else if (runnerInfo.Current.LocalName == "jockey")
                {
                    currentRaceHorse.Jockey = runnerInfo.Current.Value;
                }
                else if (runnerInfo.Current.LocalName == "name")
                {
                    currentRaceHorse.Name = runnerInfo.Current.Value;
                }
                else if (runnerInfo.Current.LocalName == "jockey_weight")
                {
                    currentRaceHorse.JockeyWeight = decimal.Parse(runnerInfo.Current.Value);
                }                
            }
            return currentRaceHorse;
        }
    }
}
