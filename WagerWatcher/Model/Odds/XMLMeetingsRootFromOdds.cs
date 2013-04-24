using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Odds
{
    [Serializable, XmlRoot("meetings")]
    public class XMLMeetingsRootFromOdds
    {
        [XmlAttribute("date")]
        public string Date { get; set; }

        [XmlElement("meeting")]
        public List<XMLMeetingFromOdds> Meetings { get;set; }
    }
}
