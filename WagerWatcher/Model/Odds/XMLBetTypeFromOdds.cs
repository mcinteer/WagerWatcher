using System;
using System.Xml.Serialization;

namespace WagerWatcher.Model.Odds
{
    [Serializable, XmlRoot("bet_type")]
    public class XMLBetTypeFromOdds
    {
        [XmlAttribute("comingled")]
        public string Comingled { get; set; }

        [XmlAttribute("comingled_info")]
        public string ComingledInfo { get; set; }

        [XmlAttribute("comingled_brand")]
        public string ComingledBrand { get; set; }
    }
}