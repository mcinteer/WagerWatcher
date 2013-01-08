using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WagerWatcher.Model;
using WagerWatcher.Model.Schedule;

namespace WagerWatcher.Controller
{
    public class RaceController
    {
        public static Race BuildRaceForDB(XMLRaceFromSchedule scheduleXMLRace, Meeting meeting = null)
        {
            IList<FixedOption> options = 
                scheduleXMLRace.OptionsRoot.Options.Select(OptionController.BuildOptionForDB).ToList();
            IList<HorseInRace> entries = 
                scheduleXMLRace.Entries.Entries.Select(EntryController.BuildEntryForDB).ToList();
            var race = new Race()
                {
                    Class = ClassController.GetClass(scheduleXMLRace.Class),
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


    }
}
