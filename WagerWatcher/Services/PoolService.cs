using System;
using System.Collections.Generic;
using System.Linq;
using WagerWatcher.Model.Pool;
using WagerWatcher.Model.Results;
using WagerWatcher.Repositories;

namespace WagerWatcher.Services
{
    public class PoolService
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
            var results = new List<Result>();
            
            if (xmlPool.BetType == "PLC" || xmlPool.BetType == "WIN")
            {
                foreach (var runner in xmlPool.EntriesRoot.Entries)
                {
                    var horsesInRace = RaceRepository.GetHorsesInRace(race);
                    var horseName = horsesInRace.First(h => h.Number.ToString() == runner.Number).Name;
                    var horse = HorseRepository.GetByName(horseName);
                    var horseInResult = new EntrantInResult()
                        {
                            Horse = horsesInRace.First(h => h.Number.ToString() == runner.Number).Horse
                        };

                    var result = new Result()
                        {
                            AmountPaid = runner.Odds,
                            EntrantInResults = new List<EntrantInResult>(){horseInResult}                            
                        };
                    results.Add(result);
                }
            }

            var pool = new Pool()
            {
                BetType = betType,
                Race = race,
                BroughtForward = xmlPool.BroughtForward,
                Commingled = xmlPool.Commingled,
                CommingledInfo = xmlPool.CommingledInfo,
                Gaurantee = xmlPool.Gaurantee,
                Total = xmlPool.Total,
                Results = results
            };
            return pool;
        }


        public static Pool GetPoolFromDB(Guid betTypeID, Guid raceID)
        {
            return PoolRepository.GetByBetTypeIDAndRace(betTypeID, raceID);
        }

        public static IList<Pool> GetPoolByRace(Race race)
        {
            return PoolRepository.GetPoolsByRace(race);
        }

        public static void AddOrUpdate(Pool newPool)
        {
            try
            {
                var persistedPool = PoolRepository.GetByBetTypeIDAndRace((Guid)newPool.BetTypeId, (Guid)newPool.RaceId);
                if (persistedPool != null)
                {
                    newPool.PoolId = persistedPool.PoolId;
                    PoolRepository.Add(newPool);
                }
                else
                {
                    PoolRepository.Update(newPool);
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("123");
            }
        }
    }
}
