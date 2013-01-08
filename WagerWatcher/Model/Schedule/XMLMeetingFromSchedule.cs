using System;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Schedule
{
    [Serializable, XmlRoot("meeting")]
    public class XMLMeetingFromSchedule
    {
        [XmlElement("betslip_type")]
        public string BetslipType { get; set; }

        [XmlElement("code")]
        public string Code { get; set; }

        [XmlElement("country")]
        public string Country { get; set; }

        [XmlElement("date")]
        public string Date { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("number")]
        public string Number { get; set; }

        [XmlElement("nz")]
        public string NZ { get; set; }

        [XmlElement("penetrometer")]
        public string Penetrometer { get; set; }
        
        [XmlElement("status")]
        public string Status { get; set; }

        [XmlElement("track_dir")]
        public string TrackDirection { get; set; }

        [XmlElement("type")]
        public string Type { get; set; }

        [XmlElement("venue")]
        public string Venue { get; set; }

        [XmlElement("races")]
        public XMLRacesRootFromSchedule RacesRoot { get; set; }
    }
}
