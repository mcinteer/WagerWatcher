using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Results
{
    [Serializable, XmlRoot("also_ran")]
    public class XMLAlsoRanRootFromResults
    {
        [XmlElement("runners")]
        public XMLRunnersRootFromResults RunnersRoot { get; set; }
    }
}
