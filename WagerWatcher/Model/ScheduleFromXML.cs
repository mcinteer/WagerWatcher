using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WagerWatcher.Model
{
    [Serializable,XmlRoot("schedule")]
    public class ScheduleFromXML
    {
        [XmlElement("meetings")]
        public MeetingsRootFromXML Meetings { get; set; }
    }
}
