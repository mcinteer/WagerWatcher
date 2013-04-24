using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;

namespace WagerWatcher.Repositories
{
    public class ResultRepository
    {
        public static void Add(Result result)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Save(result);
                transaction.Commit();
            }
        }

        public static void Update(Result result)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Update(result);
                transaction.Commit();
            }
        }

        public void Remove(Result result)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(result);
                transaction.Commit();
            }
        }

        public Result GetByID(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Get<Result>(id);
            }
        }

        public static Result GetByDateAndMeetingAndRaceAndBetType(string raceDate, int? meetingNum, int? raceNum, int? horseNum, string betTypeDesc)
        {
            Result result;
            using (var session = NHibernateHelper.OpenSession())
            {
                result = session
                    .CreateCriteria(typeof (Result))
                    .Add(Restrictions.Eq("RaceDate", raceDate))
                    .Add(Restrictions.Eq("MeetingNum", meetingNum))
                    .Add(Restrictions.Eq("RaceNum", raceNum))
                    .Add(Restrictions.Eq("HorseNum", horseNum))
                    .Add(Restrictions.Eq("BetTypeDesc", betTypeDesc))
                    .UniqueResult<Result>();
            }
            return result;
        }
    }
}
