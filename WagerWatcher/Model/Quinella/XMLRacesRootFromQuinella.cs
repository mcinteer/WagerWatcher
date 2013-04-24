using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Quinella
{
    [Serializable, XmlRoot("races")]
    public class XMLRacesRootFromQuinella
    {
        [XmlElement("race")]
        public List<XMLRaceFromQuinella> Races { get; set; }
    }
}
