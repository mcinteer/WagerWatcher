using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace WagerWatcher.Repositories
{
    public class RaceRepository
    {
       
        public void Add(Race race)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Save(race);
                transaction.Commit();
            }
        }


        public void Update(Race race)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Update(race);
                transaction.Commit();
            }
        }

        public void Remove(Race race)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(race);
                transaction.Commit();
            }
        }

        public static Race GetByID(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Get<Race>(id);
            }
        }

        public static IList<Race> GetRacesInMeeting(Meeting meeting)
        {
            IList<Race> races;
            using (var session = NHibernateHelper.OpenSession())
            {
                races = session
                    .CreateCriteria(typeof (Race))
                    .Add(Restrictions.Eq("MeetingId", meeting.MeetingId))
                    .List<Race>();
            }
            return races;
        }
    }
}
