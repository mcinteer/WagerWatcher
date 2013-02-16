using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Pool
{
    [Serializable, XmlRoot("meetings")]
    public class XMLMeetingsRootFromPool
    {
        [XmlAttribute("date")]
        public string Date { get; set; }

        [XmlElement("meeting")]
        public List<XMLMeetingFromPool> meetings { get; set; }
    }
}
