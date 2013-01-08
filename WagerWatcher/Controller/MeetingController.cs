using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mindscape.LightSpeed;
using WagerWatcher.Model;
using WagerWatcher.Model.Schedule;

namespace WagerWatcher.Controller
{
    public class MeetingController
    {
        public static Meeting GetMeetingFromScheduleForDB(XMLMeetingFromSchedule scheduleXMLMeeting)
        {
            var meeting = new Meeting()
                {
                    BetSlipType = scheduleXMLMeeting.BetslipType,
                    Code = scheduleXMLMeeting.Code,
                    Country = scheduleXMLMeeting.Country,
                    Course = RaceCourseController.BuildCourse(scheduleXMLMeeting.Venue),
                    JetBetCode = int.Parse(scheduleXMLMeeting.Number),
                    MDate = scheduleXMLMeeting.Date,
                    MeetingStatus = scheduleXMLMeeting.Status,
                    Name = scheduleXMLMeeting.Name,
                    Penetrometer = scheduleXMLMeeting.Penetrometer,
                    RaceType = scheduleXMLMeeting.Type,
                    TrackDirection = scheduleXMLMeeting.TrackDirection,
                    Venue = scheduleXMLMeeting.Venue
                };
            return meeting;
        }
    }
}
