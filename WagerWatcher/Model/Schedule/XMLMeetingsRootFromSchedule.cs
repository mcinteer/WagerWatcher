using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Mindscape.LightSpeed;
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
