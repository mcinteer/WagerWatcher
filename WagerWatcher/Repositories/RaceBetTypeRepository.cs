using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WagerWatcher.Repositories
{
    public class RaceBetTypeRepository
    {
        public void Add(RaceBetType raceBetType)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Save(raceBetType);
                transaction.Commit();
            }
        }

        public void Update(RaceBetType raceBetType)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Update(raceBetType);
                transaction.Commit();
            }
        }

        public void Remove(RaceBetType raceBetType)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(raceBetType);
                transaction.Commit();
            }
        }

        public RaceBetType GetByID(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Get<RaceBetType>(id);
            }
        }
    }
}
