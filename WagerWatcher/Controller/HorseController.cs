using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WagerWatcher.Model;
using WagerWatcher.Model.Schedule;
using WagerWatcher.Repositories;

namespace WagerWatcher.Controller
{
    public class HorseController
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
