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
				ISession session = Session;
				ITransaction transaction = session.BeginTransaction ();
				transaction.Begin();
				session.SaveOrUpdate (entity);
				session.Flush();
				transaction.Commit ();

			}
			catch(Exception e)
			{
				throw new SaveEntityFondaDAOException (ResourceMessagesDAO.SaveEntityFondaDAOException +
                    entity.GetType().ToString(), e);
			}
				
		}

		/// <summary>
		/// Elimina una entidad en espesifico
		/// </summary>
		/// <param name="entity">La entidad</param>
		public void Delete (T entity)
		{
            try
            {
                ISession session = Session;
                ITransaction transaction = session.BeginTransaction();
                transaction.Begin();
                session.Delete(entity);
                session.Flush();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new DeleteEntityFondaDAOException (ResourceMessagesDAO.DeleteEntityFondaDAOException +
                    entity.GetType().ToString(), e);
            }

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
                throw new FindByIdFondaDAOException(ResourceMessagesDAO.FindByIdFondaDAOException +
                    id.ToString(), e);
            }
		}

		protected IList<T> FindAll(
			ICriterion restrictions = null, int max = -1, int offset = -1, Order order = null,
			string baseAlias = null)
        {
            try 
            { 
				ICriteria criteria;
				if(baseAlias == null)
					criteria = Session.CreateCriteria (typeof(T));
				else
					criteria = Session.CreateCriteria (typeof(T),baseAlias);

			    if (restrictions != null)
				    criteria.Add (restrictions);

				if (order != null)
					criteria.AddOrder(order);

			    if (max > 0)
				    criteria.SetMaxResults (max);

			    if (offset >= 0)
				    criteria.SetFirstResult (offset);

			    IList<T> result = criteria.List<T> ();

			    return result;
            }
            catch (Exception e)
            {
                throw new FindAllFondaDAOException(ResourceMessagesDAO.FindAllFondaDAOException, e);
            }
		}

        /// <summary>
        /// Obtiene un objeto a partir de una propiedad de busqueda
        /// </summary>
        /// <param name="property">propiedad para la busqueda</param>
        /// <param name="value">valor a buscar</param>
        /// <returns>El Objeto de la entidad</returns>
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
                throw new FindByFondaDAOException(ResourceMessagesDAO.FindByFondaDAOExceptionProperty + property +
                    ResourceMessagesDAO.FindByFondaDAOExceptionValue + value, e);
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

