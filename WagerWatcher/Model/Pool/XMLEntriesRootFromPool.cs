using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Pool
{
    [Serializable, XmlRoot("entries")]
    public class XMLEntriesRootFromPool
    {
        [XmlElement("entry")]
        public List<XMLEntryFromPool> Entries { get; set; }
    }
}
