using System;
using System.Collections.Generic;
using System.Linq;
using WagerWatcher.Model.Results;
using WagerWatcher.Repositories;

namespace WagerWatcher.Services
{
    public class ResultsService
    {
        public static Result BuildResultForDB(XMLPoolFromResults xmlPool, Pool pool, Dictionary<string, string> placings, List<FinishingPosition> alsoRan)
        {
            var finishingPositions = GetFinishingPositions(xmlPool,placings);
            IList<EntrantInResult> entrantsInResults = new List<EntrantInResult>();

            try
            {
                entrantsInResults =
                (from finishingPosition in finishingPositions
                 let horse = HorseRepository.GetByName(finishingPosition.Value.HorseName)
                 select
                     EntrantInResultService
                     .BuildEntrantInResultForDB(horse, finishingPosition.Value.Position)).ToList();

                foreach (var runner in alsoRan)
                {
                    var horse = HorseRepository.GetByName(runner.HorseName);
                    var position = runner.Position;
                    entrantsInResults.Add(EntrantInResultService.BuildEntrantInResultForDB(horse,position));
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex);
                Console.WriteLine("Couldn't build a result.");
            }

            var result = new Result()
                {
                    Pool = pool,
                    AmountPaid = xmlPool.Dividend,
                    EntrantInResults = entrantsInResults            
                };
            return result;
        }

        private static Dictionary<int, FinishingPosition> GetFinishingPositions(XMLPoolFromResults xmlPool, Dictionary<string, string> placings)
        {
            var number = new List<string>();
            var horseName = new List<string>();
            var finishingPositions = new Dictionary<int, FinishingPosition>();
            
            if (xmlPool.Type == "PL6")
            {
                char[] dilimeters = {'/', ','};
                number = xmlPool.Number.Split(dilimeters).ToList();
                horseName = xmlPool.Name.Split(dilimeters).ToList();
            }
            else if (xmlPool.Number.Contains(':'))
            {
                number = xmlPool.Number.Split(':').ToList();
                horseName = xmlPool.Name.Split(',').ToList();
            }
            else if (xmlPool.Number.Contains('/'))
            {
                number = xmlPool.Number.Split('/').ToList();
                horseName = xmlPool.Name.Split(',').ToList();
            }
            else if (xmlPool.Number.Contains(','))
            {
                number = xmlPool.Number.Split(',').ToList();
                horseName = xmlPool.Name.Split(',').ToList();
            }
            else
            {
                number.Add(xmlPool.Number);
                horseName.Add(xmlPool.Name);
            }
            
           
            for (var i = 0; i < number.Count; i++)
            {
                number[i] = number[i].Replace("+", "");
                try
                {
                    var position = placings.FirstOrDefault(v => v.Value == horseName[i]).Key;
                    if (position.Contains("="))
                        position = position.Replace("=", "");
                    var finishingPosition = new FinishingPosition()
                    {
                        HorseName = horseName[i],
                        HorseNumber = number[i],
                        Position = Int32.Parse(position)
                    };
                    finishingPositions.Add(i, finishingPosition);
                }
                catch(NullReferenceException ex)
                {
                    // This error occurs when the result includes winners from different races, ie a double.
                    // the horse winning leg one is obviously not in the positions array for leg 2.
                    // Therefor when we search for it in the above code a null reference error is returned.
                    // Need to build the functionality to handle these types of bets (DBL,TRB,PK6,PL6,ETC)
                    Console.WriteLine(Constants.ResultsController_GetFinishingPositions_result_was_from_a_combination_of_races__IE__a_double_);
                }
                
            }
            return finishingPositions;
        }

        public static void Add(Result result)
        {
            ResultRepository.Add(result);
        }

        public static void AddOrUpdate(Result newResult)
        {
            try
            {
                var persistedResult = ResultRepository.GetByDateAndMeetingAndRaceAndBetType(newResult.RaceDate,
                                                                                            newResult.MeetingNum,
                                                                                            newResult.RaceNum,
                                                                                            newResult.HorseNum,
                                                                                            newResult.BetTypeDesc);
                if (persistedResult != null)
                {
                    newResult.ResultId = persistedResult.ResultId;
                    ResultRepository.Update(newResult);
                }
                else
                {
                    ResultRepository.Add(newResult);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("ERR:111");
            }
        }

    }
}
