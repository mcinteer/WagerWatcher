﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Results
{
    [Serializable, XmlRoot("scratchings")]
    public class XMLScratchingsRootFromResults
    {
        [XmlElement("scratching")]
        public List<XMLScratchingFromResults> Scratchings { get; set; } 
    }
}
