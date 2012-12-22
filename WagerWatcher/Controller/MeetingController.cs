using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mindscape.LightSpeed;
using WagerWatcher.Model;

namespace WagerWatcher.Controller
{
    public class MeetingController
    {
        public static Meeting GetMeetingForDB(MeetingFromXML xmlMeeting)
        {
            var meeting = new Meeting()
                {
                    BetSlipType = xmlMeeting.BetslipType,
                    Code = xmlMeeting.Code,
                    Country = xmlMeeting.Country,
                    Course = RaceCourseController.BuildCourse(xmlMeeting.Venue),
                    JetBetCode = int.Parse(xmlMeeting.Number),
                    MDate = xmlMeeting.Date,
                    MeetingStatus = xmlMeeting.Status,
                    Name = xmlMeeting.Name,
                    Penetrometer = xmlMeeting.Penetrometer,
                    RaceType = xmlMeeting.Type,
                    TrackDirection = xmlMeeting.TrackDirection,
                    Venue = xmlMeeting.Venue
                };
            return meeting;
        }
    }
}
