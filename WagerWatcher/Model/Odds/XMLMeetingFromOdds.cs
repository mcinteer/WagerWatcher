using System;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Odds
{
    [Serializable, XmlRoot("meeting")]
    public class XMLMeetingFromOdds
    {
        [XmlAttribute("number")]
        public string JetBetCode { get; set; }

        [XmlElement("races")]
        public XMLRacesRootFromOdds RacesRoot { get; set; }
    }
}