using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WagerWatcher.Controller
{
    public class JockeyController
    {
        private static Jockey BuildJockeyForDB(string name)
        {
            if (name == null) name = "NO JOCKEY";
            var jockey = new Jockey()
                {
                    JockeyName = name
                };
            return jockey;
        }

        public static Jockey GetJockey(string name)
        {
            if (string.IsNullOrEmpty(name)) name = "NO JOCKEY";
            var uow = Program.Context.CreateUnitOfWork();
            var jockey = uow.Jockeys.FirstOrDefault(x => x.JockeyName == name);
            if (jockey == null)
            {
                jockey = BuildJockeyForDB(name);
                uow.Add(jockey);
                uow.SaveChanges();
                
            }
            uow.Dispose();
            return jockey;
        }
    }
}
