using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Quinella
{
    [XmlRoot("meetings")]
    public class XMLMeetingsRootFromQuinella
    {
        [XmlElement("meeting")]
        public List<XMLMeetingFromQuinella> Meetings { get; set; }
    }
}
