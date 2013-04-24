using System;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Odds
{
    [Serializable, XmlRoot("entry")]
    public class XMLEntryFromOdds
    {
        [XmlAttribute("number")]
        public string Number { get; set; }

        [XmlAttribute("scr")]
        public string Scratched { get; set; }

        [XmlAttribute("win")]
        public string Win { get; set; }

        [XmlAttribute("plc")]
        public string Place { get; set; }
    }
}