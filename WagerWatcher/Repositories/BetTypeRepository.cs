using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WagerWatcher.Repositories
{
    public class BetTypeRepository
    {
        public void Add(BetType betType)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Save(betType);
                transaction.Commit();
            }
        }

        public void Update(BetType betType)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Update(betType);
                transaction.Commit();
            }
        }

        public void Remove(BetType betType)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(betType);
                transaction.Commit();
            }
        }

        public BetType GetByID(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Get<BetType>(id);
            }
        }
    }
}
