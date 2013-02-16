using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WagerWatcher.Controller
{
    public class EntrantInResultController
    {
        public static EntrantInResult BuildEntrantInResultForDB(Horse horse, int? position)
        {

            var entrantInResult = new EntrantInResult()
                {
                    Horse = horse,
                    Position = position
                };
            return entrantInResult;
        }
    }
}
