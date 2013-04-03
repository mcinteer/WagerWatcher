using System;
using System.Collections.Generic;
using NHibernate.Criterion;
using WagerWatcher.Model;
using WagerWatcher.Model.Schedule;
using WagerWatcher.Services;


namespace WagerWatcher.Repositories
{
    public class HorseRepository 
    {
        public void Add(Horse horse)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Save(horse);
                transaction.Commit();
            }
        }

        public void Update(Horse horse)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Update(horse);
                transaction.Commit();
            }
        }

        public void Remove(Horse horse)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(horse);
                transaction.Commit();
            }
        }

        public Horse GetByID(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Get<Horse>(id);
            }
        }        

        public static Horse GetByName(XMLEntryFromSchedule entry)
        {
            Horse horse;
            using (var session = NHibernateHelper.OpenSession())
            {
                horse = session
                    .CreateCriteria(typeof (Horse))
                    .Add(Restrictions.Eq("HorseName", entry.Name))
                    .UniqueResult<Horse>();                
            }
            return horse ?? (HorseService.BuildHorseForDB(entry));
        }
        public static Horse GetByName(string name)
        {
            Horse horse;
            using (var session = NHibernateHelper.OpenSession())
            {
                horse = session
                    .CreateCriteria(typeof(Horse))
                    .Add(Restrictions.Eq("HorseName", name))
                    .UniqueResult<Horse>();
            }
            return horse;
        }

        public static IList<HorseInRace> GetHorsesInRace(Race race)
        {
            IList<HorseInRace> horses;
            using (var session = NHibernateHelper.OpenSession())
            {
                horses = session
                    .CreateCriteria(typeof(HorseInRace))
                    .Add(Restrictions.Eq("RaceId", race.RaceId))
                    .List<HorseInRace>();
            }
            return horses;
        }
    }
}