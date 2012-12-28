using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;
using WagerWatcher.Controller;
using WagerWatcher.Model;

namespace WagerWatcher.Repositories
{
    public class ClassRepository
    {
        public static void Add(Class cClass)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Save(cClass);
                transaction.Commit();
            }
        }

        public void Update(Class cClass)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Update(cClass);
                transaction.Commit();
            }
        }

        public void Remove(Class cClass)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(cClass);
                transaction.Commit();
            }
        }

        public Class GetByID(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Get<Class>(id);
            }
        }        

        public static Class GetByDesc(string desc)
        {
            Class cClass;
            using (var session = NHibernateHelper.OpenSession())
            {
                cClass = session
                    .CreateCriteria(typeof (Class))
                    .Add(Restrictions.Eq("ClassDesc", desc))
                    .UniqueResult<Class>();                
            }
            return cClass ?? (ClassController.BuildClassForDB(desc));
        }
    }
}