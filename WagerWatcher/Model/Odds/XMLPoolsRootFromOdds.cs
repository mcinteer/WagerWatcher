using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Odds
{
    [Serializable, XmlRoot("pools")]
    public class XMLPoolsRootFromOdds
    {
        [XmlElement("pool_odds")]
        public List<XMLPoolOddsFromOdds> PoolOdds { get; set; } 

    }
}