using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Web;
using com.ds201625.fonda.DataAccess.HibernateDAO.FluentMappings;

namespace com.ds201625.fonda.DataAccess.HibernateDAO.Session
{
	/// <summary>
	/// Manages the NHibernate session, please note SysCache2 has been added as the L2 cache provider.
	/// </summary>
	public class NHibernateSessionManager
	{
		private static ISessionFactory _factory;


		private static ISessionFactory GetFactory<T>() where T : ICurrentSessionContext
		{

			Configuration config = new Configuration ().Configure ();
			ISessionFactory f = Fluently.Configure (config)
				.Mappings (m => m.FluentMappings
					.AddFromAssemblyOf<PersonMap> ()
				)
				.ExposeConfiguration (cfg => new SchemaUpdate (cfg)
					.Execute (false, true))
				.Diagnostics (diag => diag.Enable ().OutputToConsole ())
				.CurrentSessionContext<T>().BuildSessionFactory ();
			return f;
		}


		/// <summary>
		/// Gets the current session.
		/// </summary>
		public static ISession GetCurrentSession()
		{
			if (_factory == null)
				_factory = HttpContext.Current != null ? GetFactory<WebSessionContext>() : GetFactory<ThreadStaticSessionContext>();

			if (CurrentSessionContext.HasBind(_factory))
				return _factory.GetCurrentSession();

			var session = _factory.OpenSession();
			CurrentSessionContext.Bind(session);

			return session;
		}


		/// <summary>
		/// Closes the session.
		/// </summary>
		public static void CloseSession()
		{
			if (_factory != null && CurrentSessionContext.HasBind(_factory))
			{
				var session = CurrentSessionContext.Unbind(_factory);
				session.Close();
				//_factory = null;
			}
		}


		/// <summary>
		/// Commits the session.
		/// </summary>
		/// <param name="session">The session.</param>
		public static void CommitSession(ISession session)
		{
			try
			{
				session.Transaction.Commit();
			}
			catch (Exception)
			{
				session.Transaction.Rollback();
				throw;
			}
		}

	}
}

