using WagerWatcher.Model.Pool;
using WagerWatcher.Model.Schedule;
using WagerWatcher.Repositories;

namespace WagerWatcher.Services
{
    public class MeetingService
    {
        public static Meeting GetMeetingFromScheduleForDB(XMLMeetingFromSchedule scheduleXMLMeeting)
        {
            var meeting = new Meeting()
                {
                    BetSlipType = scheduleXMLMeeting.BetslipType,
                    Code = scheduleXMLMeeting.Code,
                    Country = scheduleXMLMeeting.Country,
                    Course = RaceCourseService.BuildCourse(scheduleXMLMeeting.Venue),
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

        public static Meeting GetOrBuildMeetingFromSchedule(string date, short jetBetCode, XMLMeetingFromSchedule xmlMeeting)
        {
            var meeting = MeetingRepository.GetMeetingByDateAndJetBetCode(date, jetBetCode) ??
                          GetMeetingFromScheduleForDB(xmlMeeting);
            return meeting;
        }

        public static Meeting GetMeetingByDateAndJetBetCode(string date, int jetBetCode)
        {
            var meeting = MeetingRepository.GetMeetingByDateAndJetBetCode(date, jetBetCode);
            return meeting;
        }

        
    }
}
