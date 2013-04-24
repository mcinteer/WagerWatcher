using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Odds
{
    [Serializable, XmlRoot("pool_odds")]
    public class XMLPoolOddsFromOdds
    {
        [XmlElement("bet_type")]
        public List<XMLBetTypeFromOdds> BetType { get; set; }
    }
}