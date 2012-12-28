using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;
using WagerWatcher.Controller;
using WagerWatcher.Model;

namespace WagerWatcher.Repositories
{
    class JockeyRepository
    {
        public static void Add(Jockey jockey)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Save(jockey);
                transaction.Commit();
            }
        }

        public void Update(Jockey jockey)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Update(jockey);
                transaction.Commit();
            }
        }

        public void Remove(Jockey jockey)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(jockey);
                transaction.Commit();
            }
        }

        public Jockey GetByID(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Get<Jockey>(id);
            }
        }        

        public static Jockey GetByName(string name)
        {
            Jockey jockey;
            using (var session = NHibernateHelper.OpenSession())
            {
                jockey = session
                    .CreateCriteria(typeof (Jockey))
                    .Add(Restrictions.Eq("JockeyName", name))
                    .UniqueResult<Jockey>();                
            }
            return jockey ?? (JockeyController.BuildJockeyForDB(name));
        }
    }
}


