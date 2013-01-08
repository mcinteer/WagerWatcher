using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Results
{
    [Serializable, XmlRoot("runner")]
    public class XMLRunnerFromResults
    {
        [XmlElement("number")]
        public string EntryNumber { get; set; }

        [XmlElement("name")]
        public string EntryName { get; set; }

        [XmlElement("jockey")]
        public string Jockey { get; set; }

        [XmlElement("distance")]
        public string Distance { get; set; }

        [XmlElement("finish_position")]
        public string FinishingPosition { get; set; }


    }
}
