using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Pool
{
    [Serializable, XmlRoot("races")]
    public class XMLRacesRootFromPool
    {
        [XmlElement("race")]
        public List<XMLRaceFromPool> Races { get; set; }
    }
}
