using System;

namespace WagerWatcher.Repositories
{
    class MeetingRepository
    {
        public void Add(Meeting meeting)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Save(meeting);
                transaction.Commit();
            }
        }

        public void Update(Meeting meeting)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Update(meeting);
                transaction.Commit();
            }
        }

        public void Remove(Meeting meeting)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(meeting);
                transaction.Commit();
            }
        }

        public Meeting GetMeetingByID(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Get<Meeting>(id);
            }
        }
    }
}