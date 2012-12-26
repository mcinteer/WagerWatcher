using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WagerWatcher.Model;

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
            var uow = Program.Context.CreateUnitOfWork();
            var retVal = uow.Horses.FirstOrDefault(x => x.HorseName == entry.Name);
            if (retVal == null)
            {
                retVal = BuildHorseForDB(entry);
                uow.Add(retVal);
                uow.SaveChanges();
            }
            uow.Dispose();
            return retVal;
        }
    }
}
