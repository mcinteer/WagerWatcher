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
        [XmlAttribute("number")]
        public string EntryNumber { get; set; }

        [XmlAttribute("name")]
        public string EntryName { get; set; }

        [XmlAttribute("jockey")]
        public string Jockey { get; set; }

        [XmlAttribute("distance")]
        public string Distance { get; set; }

        [XmlAttribute("finish_position")]
        public string FinishingPosition { get; set; }


    }
}
