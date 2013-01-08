using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;

namespace WagerWatcher.Repositories
{
    public class RaceResultRepository
    {
        public void Add(RaceResult raceResult)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Save(raceResult);
                transaction.Commit();
            }
        }


        public void Update(RaceResult raceResult)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Update(raceResult);
                transaction.Commit();
            }
        }

        public void Remove(RaceResult raceResult)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(raceResult);
                transaction.Commit();
            }
        }

        public RaceResult GetByID(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Get<RaceResult>(id);
            }
        }

        public static RaceResult GetRaceByDateAndJetBetCodeAndRaceNumber(string date, int jetBetCode, int raceNumber)
        {
            RaceResult raceResult;
            using (var session = NHibernateHelper.OpenSession())
            {
                raceResult = session
                   .CreateCriteria(typeof(RaceResult))
                   .Add(Restrictions.Eq("MDate", date))
                   .Add(Restrictions.Eq("JetBetCode", jetBetCode))
                   .Add(Restrictions.Eq("RaceNum", raceNumber))
                   .UniqueResult<RaceResult>();
            }
            return raceResult;
        }
    }
}
