using System;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Schedule
{
    [Serializable, XmlRoot("Option")]
    public class XMLOptionFromSchedule
    {
        [XmlElement("number")]
        public string Number { get; set; }

        [XmlElement("type")]
        public string Type { get; set; }
    }
}
