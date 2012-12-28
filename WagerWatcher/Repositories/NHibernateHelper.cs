using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace WagerWatcher.Repositories
{
    public static class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        internal static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var configuration = ConfigurationHelper.CreateConfiguration();
                    _sessionFactory = configuration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        internal static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
