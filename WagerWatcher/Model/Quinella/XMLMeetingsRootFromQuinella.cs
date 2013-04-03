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

    [Serializable, XmlRoot("meeting")]
    public class XMLMeetingFromQuinella
    {
        [XmlAttribute("number")]
        public string Number { get; set; }

        [XmlElement("races")]
        public XMLRacesRootFromQuinella RacesRoot { get; set; }
    }

    [Serializable, XmlRoot("races")]
    public class XMLRacesRootFromQuinella
    {
        [XmlElement("race")]
        public List<XMLRaceFromQuinella> Races { get; set; } 
    }

    [Serializable, XmlRoot("race")]
    public class XMLRaceFromQuinella
    {
        [XmlAttribute("number")]
        public string Number { get; set; }

        [XmlAttribute("qlapool")]
        public string Qlapool { get; set; }

        [XmlElement("entries")]
        public XMLEntriesRootFromQuinella Entries { get; set; }
    }

    [Serializable, XmlRoot("entries")]
    public class XMLEntriesRootFromQuinella
    {

    }
}
