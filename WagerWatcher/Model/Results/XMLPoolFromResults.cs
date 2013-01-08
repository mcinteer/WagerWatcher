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
        [XmlElement("type")]
        public string Type { get; set; }

        [XmlElement("number")]
        public string Number { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("amount")]
        public string Dividend { get; set; }
    }
}
