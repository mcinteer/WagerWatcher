using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Results
{
    [Serializable, XmlRoot("races")]
    public class XMLRacesRootFromResults
    {
        [XmlElement("race")]
        public List<XMLRaceFromResults> Races { get; set; }
    }
}
