using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WagerWatcher.Model.Pool;
using WagerWatcher.Model.Results;
using WagerWatcher.Repositories;

namespace WagerWatcher.Controller
{
    public class PoolController
    {
        public static Pool BuildPoolForDB(XMLPoolFromResults xmlPool, BetType betType, Race race)
        {
            var pool = new Pool()
                {
                    BetType = betType,
                    Race = race
                };
            return pool;
        }

        public static Pool BuildPoolForDB(XMLPoolFromPool xmlPool, BetType betType, Race race)
        {
            var pool = new Pool()
            {
                BetType = betType,
                Race = race,
                BroughtForward = xmlPool.BroughtForward,
                Commingled = xmlPool.Commingled,
                CommingledInfo = xmlPool.CommingledInfo,
                Gaurantee = xmlPool.Gaurantee,
                Total = xmlPool.Total
            };
            return pool;
        }


        public static Pool GetPoolFromDB(Guid betTypeID, Guid raceID)
        {
            return PoolRepository.GetByBetTypeAndRace(betTypeID, raceID);
        }
    }
}
