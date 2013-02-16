using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Pool
{
    [Serializable, XmlRoot("race")]
    public class XMLRaceFromPool
    {
        [XmlElement("number")]
        public string Number { get; set; }

        [XmlElement("pools")]
        public XMLPoolsRootFromPool PoolsRoot { get; set; }

    }
}
