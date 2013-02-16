using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Pool
{
    [Serializable, XmlRoot("pools")]
    public class XMLPoolsRootFromPool
    {
        [XmlElement("pool")]
        public List<XMLPoolFromPool> pools { get; set; }
    }
}
