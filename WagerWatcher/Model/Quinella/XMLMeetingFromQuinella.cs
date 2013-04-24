using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Quinella
{
    [Serializable, XmlRoot("meeting")]
    public class XMLMeetingFromQuinella
    {
        [XmlAttribute("number")]
        public string Number { get; set; }

        [XmlElement("races")]
        public XMLRacesRootFromQuinella RacesRoot { get; set; }
    }
}
