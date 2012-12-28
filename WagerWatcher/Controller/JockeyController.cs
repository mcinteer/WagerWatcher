using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WagerWatcher.Repositories;

namespace WagerWatcher.Controller
{
    public class JockeyController
    {
        public static Jockey BuildJockeyForDB(string name)
        {
            if (string.IsNullOrEmpty(name)) name = "NO JOCKEY";
            var jockey = new Jockey()
                {
                    JockeyName = name
                };
            JockeyRepository.Add(jockey);
            return jockey;
        }

        public static Jockey GetJockey(string name)
        {
            return string.IsNullOrEmpty(name) ? 
                BuildJockeyForDB("NO JOCKEY") : 
                JockeyRepository.GetByName(name);
        }
    }
}
