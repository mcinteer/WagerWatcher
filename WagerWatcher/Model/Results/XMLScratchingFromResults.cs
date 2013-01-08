using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Results
{
    [Serializable, XmlRoot("scratching")]
    public class XMLScratchingFromResults
    {
        [XmlElement("number")]
        public string EntryNumber { get; set; }

        [XmlElement("name")]
        public string EntryName { get; set; }

        [XmlElement("class")]
        public string Class { get; set; }

        [XmlElement("stake")]
        public string Stake { get; set; }

        [XmlElement("distance")]
        public string Distance { get; set; }
    }
}
