using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Pool
{
    [Serializable, XmlRoot("entry")]
    public class XMLEntryFromPool
    {
        [XmlElement("number")]
        public string Number { get; set; }

        [XmlElement("scratched")]
        public string Scratched { get; set; }

        [XmlElement("value")]
        public string Value { get; set; }

        [XmlElement("odds")]
        public string Odds { get; set; }

        [XmlElement("favouritism")]
        public string Favouritism { get; set; }
    }
}
