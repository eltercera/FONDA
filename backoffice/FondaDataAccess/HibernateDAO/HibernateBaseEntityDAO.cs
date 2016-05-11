using System;
using NHibernate;
using com.ds201625.fonda.DataAccess.HibernateDAO.Session;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using NHibernate.Criterion;
using System.Collections.Generic;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
	public class HibernateBaseEntityDAO <T> : IBaseEntityDAO<T>
        where T : Entity
	{

		/// <summary>
		/// Persiste o actualiza una entidad
		/// </summary>
		/// <param name="entity"> La entidad </param>
		public void Save (T entity)
		{
			ITransaction transaction = Session.BeginTransaction ();
			Session.SaveOrUpdate (entity);
			transaction.Commit ();
		}

		/// <summary>
		/// Elimina una entidad en espesifico
		/// </summary>
		/// <param name="entity">La entidad</param>
		public void Delete (T entity)
		{
			ITransaction transaction = Session.BeginTransaction ();
			Session.Delete (entity);
			transaction.Commit ();
		}

		/// <summary>
		/// Obtiene un objeto a partir de su identificador
		/// </summary>
		/// <param name="id">Identificador de la entidad.</param>
		/// <returns> Objeto de la entidad.</returns>
		public T FindById (int id)
		{
			return Session.Get<T> (id);
		}

		protected T FindBy (string property, object value)
		{
			ICriteria criteria = Session.CreateCriteria (typeof (T))
				.Add (Restrictions.Eq (property, value));
			criteria.SetMaxResults (1);

			IList<T> result = criteria.List<T> ();

			if (result.Count == 0)
				return default (T);
			return result [0];
		}

		protected ISession Session
		{
			get
			{
				return FactorySession.GetCurrentSession ();
			}
		}

		public void ResetSession()
		{
			FactorySession.ResetCurrentSession ();
		}
	}
}

