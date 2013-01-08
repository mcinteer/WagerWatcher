using System;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Results
{
    [Serializable, XmlRoot("race")]
    public class XMLRaceFromResults
    {
        [XmlElement("placings")]
        public XMLPlacingsRootFromResults PlacingsRoot { get; set; }

        [XmlElement("also_ran")]
        public XMLAlsoRanRootFromResults AlsoRanRoot { get; set; }

        [XmlElement("pools")]
        public XMLPoolsRootFromResults PoolsRoot { get; set; }

        [XmlElement("scratchings")]
        public XMLScratchingsRootFromResults ScratchingsRoot { get; set; }

        [XmlAttribute("number")]
        public string Number { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("class")]
        public string Class { get; set; }

        [XmlAttribute("stake")]
        public string Stake { get; set; }

        [XmlAttribute("distance")]
        public string Distance { get; set; }

        [XmlAttribute("winnerstrainer")]
        public string WinnersTrainer { get; set; }

        [XmlAttribute("winnersbreeding")]
        public string WinnersBreeding { get; set; }

        [XmlAttribute("winnersowner")]
        public string WinnersOwner { get; set; }

        [XmlAttribute("winnerstime")]
        public string WinnersTime { get; set; }
    }

    
}
