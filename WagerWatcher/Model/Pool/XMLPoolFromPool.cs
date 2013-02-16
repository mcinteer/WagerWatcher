using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Pool
{
    [Serializable, XmlRoot("pool")]
    public class XMLPoolFromPool
    {
        [XmlElement("bet_type")]
        public string BetType { get; set; }

        [XmlElement("total")]
        public string Total { get; set; }

        [XmlElement("gaurantee")]
        public string Gaurantee { get; set; }

        [XmlElement("brought_forward")]
        public string BroughtForward { get; set; }

        [XmlElement("commingled")]
        public string Commingled { get; set; }

        [XmlElement("commingled_info")]
        public string CommingledInfo { get; set; }

        [XmlElement("entries")]
        public XMLEntriesRootFromPool EntriesRoot { get; set; }

    }
}
