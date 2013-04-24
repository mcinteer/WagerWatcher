using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Quinella
{
    [Serializable, XmlRoot("race")]
    public class XMLRaceFromQuinella
    {
        [XmlAttribute("number")]
        public List<XMLRaceFromQuinella> Number { get; set; }

        [XmlAttribute("qlapool")]
        public List<XMLRaceFromQuinella> Qlapool { get; set; }

        [XmlElement("entries")]
        public XMLEntriesRootFromQuinella Entries { get; set; }
    }
}
