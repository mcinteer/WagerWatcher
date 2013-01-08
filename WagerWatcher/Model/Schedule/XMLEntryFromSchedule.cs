using System;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Schedule
{
    [Serializable, XmlRoot("entry")]
    public class XMLEntryFromSchedule
    {
        [XmlElement("barrier")]
        public string Barrier { get; set; }

        [XmlElement("jockey")]
        public string Jockey { get; set; }

        [XmlElement("jockey_allowance")]
        public string JockeyAllowance { get; set; }

        [XmlElement("jockey_weight")]
        public string JockeyWeight { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("number")]
        public string Number { get; set; }

        [XmlElement("scratched")]
        public string Scratched { get; set; }
    }
}