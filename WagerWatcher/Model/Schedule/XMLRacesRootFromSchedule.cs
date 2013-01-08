using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using WagerWatcher.Model.Schedule;

namespace WagerWatcher.Model
{
    [Serializable, XmlRoot("races")]
    public class XMLRacesRootFromSchedule
    {
        [XmlElement("race")]
        public List<XMLRaceFromSchedule> Races { get; set; } 
    }
}
