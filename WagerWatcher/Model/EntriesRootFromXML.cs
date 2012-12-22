using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Collections;
namespace WagerWatcher.Model
{
    [Serializable, XmlRoot("entries")]
    public class EntriesRootFromXML
    {
        [XmlElement("entry")]
        public List<EntryFromXML> Entries { get; set; }
    }

   
}