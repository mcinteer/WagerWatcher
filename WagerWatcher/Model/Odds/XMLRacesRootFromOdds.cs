using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Odds
{
    [Serializable, XmlRoot("races")]
    public class XMLRacesRootFromOdds
    {
        [XmlElement("race")]
        public List<XMLRaceFromOdds> Races { get; set; }
    }
}