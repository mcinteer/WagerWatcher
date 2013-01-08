using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Results
{
    [Serializable, XmlRoot("meetings")]
    public class XMLMeetingsRootFromResults
    {
        [XmlElement("meeting")]
        public List<XMLMeetingFromResults> Meetings { get; set; }

        [XmlAttribute("date")]
        public string Date { get; set; }
    }
}
