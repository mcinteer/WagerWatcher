using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Mindscape.LightSpeed;

namespace WagerWatcher.Model
{
    [XmlRoot("meetings")]
    public class MeetingsRootFromXML
    {
        [XmlElement("meeting")]
        public List<MeetingFromXML> Meetings { get; set; }
    }
}
