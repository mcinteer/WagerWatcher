using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;

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

        public static BetType GetBetTypeByXMLDesc(string desc)
        {
            BetType betType;
            using (var session = NHibernateHelper.OpenSession())
            {
                betType = session
                    .CreateCriteria(typeof (BetType))
                    .Add(Restrictions.Eq("XmlDesc", desc))
                    .UniqueResult<BetType>();
            }
            return betType;
        }

    }
}
