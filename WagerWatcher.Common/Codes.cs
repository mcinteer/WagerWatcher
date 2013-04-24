using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagerWatcher.Common
{
    public class Codes
    {
        public class BetTypes
        {
            public const string Prefix = "BETTYPE/";
            public const string Win = Prefix + "WIN";
            public const string Place = Prefix + "PLACE";
            public const string Quinella = Prefix + "QUINELLA";
            public const string Trifecta = Prefix + "TRIFECTA";

        }
    }
}
