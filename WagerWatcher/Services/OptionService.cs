using WagerWatcher.Model.Schedule;

namespace WagerWatcher.Services
{
    public class OptionService
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
