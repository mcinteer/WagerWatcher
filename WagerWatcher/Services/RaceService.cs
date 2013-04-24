using System.Collections.Generic;
using System.Linq;
using WagerWatcher.Model.Schedule;
using WagerWatcher.Repositories;

namespace WagerWatcher.Services
{
    public class RaceService
    {
        public static Race BuildRaceForDB(XMLRaceFromSchedule scheduleXMLRace, Meeting meeting = null)
        {
            IList<FixedOption> options = 
                scheduleXMLRace.OptionsRoot.Options.Select(OptionService.BuildOptionForDB).ToList();

            IList<HorseInRace> entries = 
                scheduleXMLRace.Entries.Entries.Select(EntryService.BuildEntryForDB).ToList();

            var race = new Race()
                {
                    Class = ClassService.GetClass(scheduleXMLRace.Class),
                    Distance = int.Parse(scheduleXMLRace.Length),
                    NormTime = scheduleXMLRace.NormalTime,
                    OverseasNumber = scheduleXMLRace.OverseasNumber,
                    RaceName = scheduleXMLRace.Name,
                    RaceNum = int.Parse(scheduleXMLRace.Number),
                    RaceStatus = scheduleXMLRace.Status,
                    Stake = scheduleXMLRace.Stake,
                    TrackCondition = scheduleXMLRace.Track,
                    Venue = scheduleXMLRace.Venue,
                    Weather = scheduleXMLRace.Weather,
                    Meeting = meeting,
                    FixedOptions = options,
                    HorseInRaces = entries
                };
            return race;
        }


        public static void AddOrUpdate(Race race)
        {
            var persistedRace = RaceRepository.GetRaceByDateAndMeetingAndRaceNum(race.NormTime, race.MeetingId, race.RaceNum);
            if (persistedRace != null)
            {
                race.RaceId = persistedRace.RaceId;
                RaceRepository.Update(race);
            }
            else
            {
                RaceRepository.Add(race);
            }
        }

        public static IList<Race> GetRacesInMeeting(Meeting meeting)
        {
            return RaceRepository.GetRacesInMeeting(meeting);
        }
    }
}
