using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Results
{
    [Serializable, XmlRoot("pool")]
    public class XMLPoolFromResults
    {
        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlAttribute("number")]
        public string Number { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("amount")]
        public string Dividend { get; set; }
    }
}
