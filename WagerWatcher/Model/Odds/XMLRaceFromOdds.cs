using System;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Odds
{
    [Serializable, XmlRoot("race")]
    public class XMLRaceFromOdds
    {
        [XmlAttribute("number")]
        public string Number { get; set; }

        [XmlAttribute("winpool")]
        public string WinPool { get; set; }

        [XmlAttribute("plcpool")]
        public string PlacePool { get; set; }

        [XmlAttribute("qlapool")]
        public string QuinellaPool { get; set; }

        [XmlAttribute("tfapool")]
        public string TrifectaPool { get; set; }

        [XmlElement("entries")]
        public XMLEntriesRootFromOdds EntriesRoot { get; set; }

        [XmlElement("pools")]
        public XMLPoolsRootFromOdds PoolsRoot { get; set; }
        
    }
}