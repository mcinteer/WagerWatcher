using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Results
{
    [Serializable, XmlRoot("runners")]
    public class XMLRunnersRootFromResults
    {
        [XmlElement("runner")]
        public List<XMLRunnerFromResults> Runners { get; set; }
    }
}
