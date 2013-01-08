using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Schedule
{
    [Serializable, XmlRoot("entries")]
    public class XMLEntriesRootFromSchedule
    {
        [XmlElement("entry")]
        public List<XMLEntryFromSchedule> Entries { get; set; }
    }

   
}