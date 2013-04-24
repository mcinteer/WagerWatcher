using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;

namespace WagerWatcher.Repositories
{
    public class HorseInRaceRepository
    {
        public static void Add(HorseInRace horseInRace)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Save(horseInRace);
                transaction.Commit();
            }
        }

        public static void Update(HorseInRace horseInRace)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Update(horseInRace);
                transaction.Commit();
            }
        }

        public void Remove(HorseInRace horseInRace)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(horseInRace);
                transaction.Commit();
            }
        }

        public HorseInRace GetByID(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Get<HorseInRace>(id);
            }
        }

        public static IList<HorseInRace> GetEntrantsByRace(Race race)
        {
            IList<HorseInRace> horsesInRace;
            using (var session = NHibernateHelper.OpenSession())
            {
                horsesInRace = session
                    .CreateCriteria(typeof (HorseInRace))
                    .Add(Restrictions.Eq("RaceId", race.RaceId))
                    .List<HorseInRace>();
            }
            return horsesInRace;
        }
    }
}
