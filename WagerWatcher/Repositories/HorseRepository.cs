using System;
using NHibernate.Criterion;
using WagerWatcher.Controller;
using WagerWatcher.Model;


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

        public static Horse GetByName(EntryFromXML entry)
        {
            Horse horse;
            using (var session = NHibernateHelper.OpenSession())
            {
                horse = session
                    .CreateCriteria(typeof (Horse))
                    .Add(Restrictions.Eq("HorseName", entry.Name))
                    .UniqueResult<Horse>();                
            }
            return horse ?? (HorseController.BuildHorseForDB(entry));
        }
    }
}