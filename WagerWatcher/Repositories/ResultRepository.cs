using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WagerWatcher.Repositories
{
    public class ResultRepository
    {
        public void Add(Result result)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Save(result);
                transaction.Commit();
            }
        }

        public void Update(Result result)
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
    }
}
