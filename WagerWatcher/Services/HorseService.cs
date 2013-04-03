using WagerWatcher.Model.Schedule;
using WagerWatcher.Repositories;

namespace WagerWatcher.Services
{
    public class HorseService
    {
        public static Horse BuildHorseForDB(XMLEntryFromSchedule entry)
        {
            var horse = new Horse
                {
                    HorseName = entry.Name
                };
            return horse;
        }

        public static Horse GetHorse(XMLEntryFromSchedule entry)
        {
            return HorseRepository.GetByName(entry);          
        }
    }
}
