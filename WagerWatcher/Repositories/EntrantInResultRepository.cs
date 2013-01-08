using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WagerWatcher.Repositories
{
    public class EntrantInResultRepository
    {
        public void Add(EntrantInResult entrantInResult)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Save(entrantInResult);
                transaction.Commit();
            }
        }

        public void Update(EntrantInResult entrantInResult)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Update(entrantInResult);
                transaction.Commit();
            }
        }

        public void Remove(EntrantInResult entrantInResult)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(entrantInResult);
                transaction.Commit();
            }
        }

        public EntrantInResult GetByID(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Get<EntrantInResult>(id);
            }
        }
    }
}
