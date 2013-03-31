using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WagerWatcher.Repositories;

namespace WagerWatcher.Services
{
    public static class PoolService
    {
        public static IList<Pool> GetPoolByRace(Race race)
        {
            return PoolRepository.GetPoolsByRace(race);
        }


    }
}
