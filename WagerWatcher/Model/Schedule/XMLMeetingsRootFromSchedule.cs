using System.Collections.Generic;
using System.Xml.Serialization;
using WagerWatcher.Model.Schedule;

namespace WagerWatcher.Model
{
    [XmlRoot("meetings")]
    public class XMLMeetingsRootFromSchedule
    {
        [XmlElement("meeting")]
        public List<XMLMeetingFromSchedule> Meetings { get; set; }
    }
}
