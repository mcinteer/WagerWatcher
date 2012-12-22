using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WagerWatcher.Model
{
    [Serializable, XmlRoot("races")]
    public class RacesRootFromXML
    {
        [XmlElement("race")]
        public List<RaceFromXML> Races { get; set; } 
    }
}
