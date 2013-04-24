using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Quinella
{
    [Serializable, XmlRoot("entries")]
    public class XMLEntriesRootFromQuinella
    {
        [XmlElement("entry")]
        public List<XMLEntryFromQuinella> Entries { get; set; }
    }
}
