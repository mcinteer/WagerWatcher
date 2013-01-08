using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Schedule
{
    [Serializable, XmlRoot("options")]
    public class XMLOptionsRootFromSchedule
    {
        [XmlElement("option")]
        public List<XMLOptionFromSchedule> Options { get; set; }
    }
}
