using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Odds
{
    [Serializable, XmlRoot("entries")]
    public class XMLEntriesRootFromOdds
    {
        [XmlElement("entry")]
        public List<XMLEntryFromOdds> Entries { get; set; } 

    }
}