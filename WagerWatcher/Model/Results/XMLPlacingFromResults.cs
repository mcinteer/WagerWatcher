using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Results
{
    [Serializable, XmlRoot("placing")]
    public class XMLPlacingFromResults
    {
        [XmlAttribute("number")]
        public string EntryNumber { get; set; }

        [XmlAttribute("name")]
        public string EntryName { get; set; }

        [XmlAttribute("rank")]
        public string FinishingPosition { get; set; }

        [XmlAttribute("jockey")]
        public string Jockey { get; set; }

        [XmlAttribute("favouritism")]
        public string Favouritism { get; set; }

        [XmlAttribute("distance")]
        public string Distance { get; set; }

        [XmlAttribute("margin")]
        public string Margin { get; set; }

    }
}
