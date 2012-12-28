using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WagerWatcher.Model;
using WagerWatcher.Repositories;

namespace WagerWatcher.Controller
{
    public class HorseController
    {
        public static Horse BuildHorseForDB(EntryFromXML entry)
        {
            var horse = new Horse
                {
                    HorseName = entry.Name
                };
            return horse;
        }

        public static Horse GetHorse(EntryFromXML entry)
        {
            return HorseRepository.GetByName(entry);          
        }
    }
}
