using System;
using NHibernate;
using com.ds201625.fonda.DataAccess.HibernateDAO.Session;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.Domain;
using NHibernate.Criterion;
using NHibernate;
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
				ISession session = Session;
				ITransaction transaction = session.BeginTransaction ();
				transaction.Begin();
				session.SaveOrUpdate (entity);
				session.Flush();
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
			ISession session = Session;
			ITransaction transaction = session.BeginTransaction ();
			transaction.Begin();
			session.Delete (entity);
			session.Flush();
			transaction.Commit ();

		}

		/// <summary>
		/// Obtiene un objeto a partir de su identificador
		/// </summary>
		/// <param name="id">Identificador de la entidad.</param>
		/// <returns> Objeto de la entidad.</returns>
		public T FindById (int id)
		{
            try
            {
				ISession session = Session;
				ITransaction transaction = session.BeginTransaction ();
				transaction.Begin();
				T ret = session.Get<T>(id);
				transaction.Commit ();
	            return ret;
            }
            catch (Exception e)
            {
                throw new FindByIdFondaDAOException (
                    "Excepción al consultar por el Id " + id.ToString(),
                    e);
            }
		}

		protected IList<T> FindAll(ICriterion restrictions = null, int max = -1, int offset = -1)
        {
            try 
            { 
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
            catch (Exception e)
            {
                throw new FindAllFondaDAOException(
                    "Excepción consultar lista de Entitys",
                    e);
            }
		}

		protected T FindBy (string property, object value)
		{
            try
            {
                ICriteria criteria = Session.CreateCriteria(typeof(T))
                    .Add(Restrictions.Eq(property, value));
                criteria.SetMaxResults(1);

                IList<T> result = criteria.List<T>();

                if (result.Count == 0)
                    return default(T);
                return result[0];
            }
            catch (Exception e)
            {
                throw new FindByFondaDAOException(
                    "Excepción consultar por restrictions property " + property +" y value "+ value,
                    e);
            }
		}

		protected ISession Session
		{
			get
			{
				return NHibernateSessionManager.GetCurrentSession();
			}
		}

		public void ResetSession()
		{
			NHibernateSessionManager.CloseSession();
		}
	}
}

