using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WagerWatcher.Model;

namespace WagerWatcher.Controller
{
    public class OptionController
    {
        public static FixedOption BuildOptionForDB(OptionFromXML xmlOption)
        {
            var option = new FixedOption
                {
                    BetType = xmlOption.Type,
                    OptionNum = int.Parse(xmlOption.Number)
                };
            return option;
        }
    }
}
