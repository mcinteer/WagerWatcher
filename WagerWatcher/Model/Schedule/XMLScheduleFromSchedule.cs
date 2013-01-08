using System;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Schedule
{
    [Serializable,XmlRoot("schedule")]
    public class XMLScheduleFromSchedule
    {
        [XmlElement("meetings")]
        public XMLMeetingsRootFromSchedule Meetings { get; set; }
    }
}
