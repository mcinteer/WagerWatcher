using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mindscape.LightSpeed;
using System.Resources;
using System.Xml;
using System.Xml.XPath;

namespace WagerWatcher
{
    class Program
    {
        private static LightSpeedContext<LightSpeedStoreModelUnitOfWork> _context;
        static void Main(string[] args)
        {
            _context = new LightSpeedContext<LightSpeedStoreModelUnitOfWork>("default");
            _context.IdentityMethod = IdentityMethod.Guid;
            GetSchedule("2012-12-09");
        } 

        public static bool GetSchedule(string date)
        {
            var success = false;
            var uow = _context.CreateUnitOfWork();
            var test = new Updater(date);

            test.UpdateRaceDay(uow).SaveChanges();
            

            return success;
        }
    }
}
