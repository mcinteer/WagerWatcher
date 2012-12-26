using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WagerWatcher.Model;

namespace WagerWatcher.Controller
{
    public class EntryController
    {
        public static HorseInRace BuildEntryForDB(EntryFromXML xmlEntry, Race race)
        {
            

            if (xmlEntry.JockeyAllowance == null) xmlEntry.JockeyAllowance = "0";
            if (xmlEntry.JockeyWeight == null) xmlEntry.JockeyWeight = "0";
            if (xmlEntry.Number == null) xmlEntry.Number = "0";
            if (xmlEntry.Scratched == null) xmlEntry.Scratched = "0";
            var horseInRace = new HorseInRace
                {
                    Barrier = xmlEntry.Barrier,
                    Jockey = JockeyController.GetJockey(xmlEntry.Jockey),
                    JockeyAllowance = xmlEntry.JockeyAllowance,
                    JockeyWeight = decimal.Parse(xmlEntry.JockeyWeight),
                    Name = xmlEntry.Name,
                    Number = int.Parse(xmlEntry.Number),
                    Race = race,
                    Scratched = int.Parse(xmlEntry.Scratched),
                    Horse = HorseController.GetHorse(xmlEntry)
                };
            return horseInRace;
        }
    }
}
