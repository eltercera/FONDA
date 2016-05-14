using System;
using System.Data;
using NHibernate;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings;
namespace com.ds201625.fonda.DataAccess.HibernateDAO.Session
{
	public class FactorySession
	{
		private static ISession _session;

		private static ISession GetSession ()
		{
			Configuration config = new Configuration().Configure();
			ISessionFactory sessionFactory = Fluently.Configure (config)
				.Mappings (m => m.FluentMappings
					.AddFromAssemblyOf<PersonMap>()
				)
				.ExposeConfiguration(cfg => new SchemaExport(cfg)
					.Execute(true, true, false))
				.Diagnostics(diag => diag.Enable().OutputToConsole())
				.BuildSessionFactory();

			return sessionFactory.OpenSession ();
		}

		public static ISession GetCurrentSession ()
		{
			if (_session == null)
				_session = GetSession ();
			return _session;
		}

		public static void ResetCurrentSession ()
		{
			if (_session == null)
				return;

			_session.Clear ();
			_session.Close ();
			_session = null;
		}
	}
}

