using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WagerWatcher.Model
{
    [Serializable, XmlRoot("Option")]
    public class OptionFromXML
    {
        [XmlElement("number")]
        public string Number { get; set; }

        [XmlElement("type")]
        public string Type { get; set; }
    }
}
