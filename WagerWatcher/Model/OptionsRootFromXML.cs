using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WagerWatcher.Model
{
    [Serializable, XmlRoot("options")]
    public class OptionsRootFromXML
    {
        [XmlElement("option")]
        public List<OptionFromXML> Options { get; set; }
    }
}
