using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WagerWatcher.Repositories;

namespace WagerWatcher.Services
{
    public class BetTypeService
    {
        public static BetType GetBetTypeByXMLDesc(string betType)
        {
            return BetTypeRepository.GetBetTypeByXMLDesc(betType);
        }
    }
}
