using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WagerWatcher.Model;
using WagerWatcher.Model.Schedule;

namespace WagerWatcher.Controller
{
    public class OptionController
    {
        public static FixedOption BuildOptionForDB(XMLOptionFromSchedule scheduleXMLOption)
        {
            var option = new FixedOption
                {
                    BetType = scheduleXMLOption.Type,
                    OptionNum = int.Parse(scheduleXMLOption.Number)
                };
            return option;
        }
    }
}
