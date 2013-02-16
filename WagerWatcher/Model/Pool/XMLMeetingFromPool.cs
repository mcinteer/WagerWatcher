using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Pool
{
    [Serializable, XmlRoot("meeting")]
    public class XMLMeetingFromPool
    {
        [XmlElement("number")]
        public string JetBetCode { get; set; }

        [XmlElement("races")]
        public XMLRacesRootFromPool RacesRoot { get; set; }        
    }
}
