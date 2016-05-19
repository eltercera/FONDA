using System;
using NHibernate;
using com.ds201625.fonda.DataAccess.HibernateDAO.Session;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.Domain;
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
		/// <param name="entity">La entidad</param>
		public void Save (T entity)
		{
			try
			{
				ITransaction transaction = Session.BeginTransaction ();
				Session.SaveOrUpdate (entity);
				transaction.Commit ();
			}
			catch(Exception e)
			{
				throw new SaveEntityFondaDAOException (
					"Excepción al guardar un objeto de la entidad " + entity.GetType().ToString(),
					e);
			}
				
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

		protected IList<T> FindAll(ICriterion restrictions = null, int max = -1, int offset = -1){
			ICriteria criteria = Session.CreateCriteria (typeof(T));

			if (restrictions != null)
				criteria.Add (restrictions);

			if (max > 0)
				criteria.SetMaxResults (max);

			if (offset > 0)
				criteria.SetFirstResult (offset);

			IList<T> result = criteria.List<T> ();

			return result;
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

