﻿using System.Collections.Generic;
using WagerWatcher.Model.Schedule;
using WagerWatcher.Repositories;

namespace WagerWatcher.Services
{
    public class HorseInRaceService
    {
        public static HorseInRace BuildEntryForDB(XMLEntryFromSchedule xmlEntry/*, Race race*/)
        {
            

            if (xmlEntry.JockeyAllowance == null) xmlEntry.JockeyAllowance = "0";
            if (xmlEntry.JockeyWeight == null) xmlEntry.JockeyWeight = "0";
            if (xmlEntry.Number == null) xmlEntry.Number = "0";
            if (xmlEntry.Scratched == null) xmlEntry.Scratched = "0";

            var horseInRace = new HorseInRace
                {
                    Barrier = xmlEntry.Barrier,
                    JockeyName = xmlEntry.Jockey,
                    JockeyAllowance = xmlEntry.JockeyAllowance,
                    JockeyWeight = decimal.Parse(xmlEntry.JockeyWeight),
                    Name = xmlEntry.Name,
                    Number = int.Parse(xmlEntry.Number),
                   /* Race = race,*/
                    Scratched = int.Parse(xmlEntry.Scratched),
                    Horse = HorseService.GetHorse(xmlEntry)
                };
            return horseInRace;
        }

        public static IList<HorseInRace> GetEntrantsFormDBByRace(Race race)
        {
            return HorseInRaceRepository.GetEntrantsByRace(race);
        }
    }
}
