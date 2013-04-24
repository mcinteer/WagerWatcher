using WagerWatcher.Repositories;

namespace WagerWatcher.Services
{
    public class EntrantInResultService
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

        public static EntrantInResult GetByResult(Result result)
        {
            return EntrantInResultRepository.GetByResult(result);
        }
    }
}
