using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WagerWatcher.Controller
{
    public class ClassController
    {
        private static Class BuildClassForDB(string classDesc = "description")
        {
            if (classDesc == null) classDesc = "description";
            var newClass = new Class
                {
                    ClassDesc = classDesc
                };
            return newClass;
        }

        public static Class GetClass(string desc)
        {
            if (desc == null) desc = "description";
            var uow = Program.Context.CreateUnitOfWork();
            var retVal = uow.Classes.FirstOrDefault(x => x.ClassDesc == desc);
            if (retVal == null)
            {
                retVal = BuildClassForDB(desc);
                uow.Add(retVal);
                uow.SaveChanges();
                
            }
            uow.Dispose();
            return retVal;
        }
    }
}
