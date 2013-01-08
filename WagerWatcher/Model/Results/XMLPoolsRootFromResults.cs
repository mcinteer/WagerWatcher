using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Results
{
    [Serializable, XmlRoot("pools")]
    public class XMLPoolsRootFromResults
    {
        [XmlElement("pool")]
        public List<XMLPoolFromResults> Pools { get; set; }
    }
}
