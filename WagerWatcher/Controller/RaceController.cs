using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WagerWatcher.Model;

namespace WagerWatcher.Controller
{
    public class RaceController
    {
        public static Race BuildRaceForDB(RaceFromXML xmlRace, Meeting meeting = null)
        {
            var race = new Race()
                {
                    Class = ClassController.GetClass(xmlRace.Class),
                    Distance = int.Parse(xmlRace.Length),
                    NormTime = xmlRace.NormalTime,
                    OverseasNumber = xmlRace.OverseasNumber,
                    RaceName = xmlRace.Name,
                    RaceNum = int.Parse(xmlRace.Number),
                    RaceStatus = xmlRace.Status,
                    Stake = xmlRace.Stake,
                    TrackCondition = xmlRace.Track,
                    Venue = xmlRace.Venue,
                    Weather = xmlRace.Weather,
                    Meeting = meeting
                };
            return race;
        }
    }
}
