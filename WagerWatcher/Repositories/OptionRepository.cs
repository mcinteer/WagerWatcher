using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WagerWatcher.Repositories
{
    class OptionRepository
    {
        public void Add(FixedOption option)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Save(option);
                transaction.Commit();
            }
        }


        public void Update(FixedOption option)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Update(option);
                transaction.Commit();
            }
        }

        public void Remove(FixedOption option)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(option);
                transaction.Commit();
            }
        }

        public FixedOption GetByID(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Get<FixedOption>(id);
            }
        }
    }
}
