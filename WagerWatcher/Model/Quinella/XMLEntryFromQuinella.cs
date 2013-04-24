using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Quinella
{
    [Serializable, XmlRoot("entry")]
    public class XMLEntryFromQuinella
    {
        [XmlAttribute("number")]
        public List<XMLEntryFromQuinella> Number { get; set; }

        [XmlAttribute("scr")]
        public List<XMLEntryFromQuinella> Scr { get; set; }

        [XmlAttribute("favouritism")]
        public List<XMLEntryFromQuinella> Favouritism { get; set; }

        [XmlAttribute("odds")]
        public List<XMLEntryFromQuinella> Odds { get; set; }
    }
}
