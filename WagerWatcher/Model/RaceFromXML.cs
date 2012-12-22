using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WagerWatcher.Model
{
    [Serializable, XmlRoot("race")]
    public class RaceFromXML
    {
        [XmlElement("class")]
        public string Class { get; set; }

        [XmlElement("length")]
        public string Length { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("norm_time")]
        public string NormalTime { get; set; }

        [XmlElement("number")]
        public string Number { get; set; }

        [XmlElement("overseas_number")]
        public string OverseasNumber { get; set; }

        [XmlElement("stake")]
        public string Stake { get; set; }

        [XmlElement("status")]
        public string Status { get; set; }

        [XmlElement("track")]
        public string Track { get; set; }

        [XmlElement("venue")]
        public string Venue { get; set; }

        [XmlElement("weather")]
        public string Weather { get; set; }

        [XmlElement("options")]
        public OptionsRootFromXML OptionsRoot { get; set; }

        [XmlElement("entries")]
        public EntriesRootFromXML Entries { get; set; }
    }

    
}

