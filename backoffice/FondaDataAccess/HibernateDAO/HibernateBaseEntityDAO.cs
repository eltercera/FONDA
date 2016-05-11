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
				return FacrotySession.GetCurrentSession ();
			}
		}

		public void ResetSession()
		{
			FacrotySession.ResetCurrentSession ();
		}
	}
}

