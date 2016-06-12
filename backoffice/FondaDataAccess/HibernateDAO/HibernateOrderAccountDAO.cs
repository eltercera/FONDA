using System;
using NHibernate;
using NHibernate.Criterion;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System.Collections.Generic;
using com.ds201625.fonda.DataAccess.FondaDAOExceptions;
using com.ds201625.fonda.DataAccess.FactoryDAO;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateOrderAccountDAO : HibernateBaseEntityDAO<Account>, IOrderAccountDao
    {
        private FactoryDAO.FactoryDAO _facDAO = FactoryDAO.FactoryDAO.Intance;
        /// <summary>
        /// Obtiene la orden de un comensal
        /// </summary>
        /// <param name="commensal">Un objeto de tipo Commensal</param>
        /// <returns>Un objeto Account</returns>
        public Account FindByCommensal(Commensal commensal)
        {
            ICriterion criterion = Expression.And(Expression.Eq("Commensal", commensal), Expression.Eq("Status", OpenAccountStatus.Instance));
            try
            {
                return (Account)(FindAll(criterion)[0]);
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new FondaIndexException("Not Found order account", e);
            }
        }

        /// <summary>
        /// Obtiene las ordenes de un Restaurante
        /// </summary>
        /// <param name="restaurant">Un objeto de tipo Restaurant</param>
        /// <returns>Una lista de Account</returns>
        public IList<Account> FindByRestaurant(Restaurant restaurant)
        {
            ICriterion criterion = Expression.Eq("Status", OpenAccountStatus.Instance);
            try
            {
                IList<Account> list = new List<Account>();
                list = (FindAll(criterion));
                return list;
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new FondaIndexException("No se encontraron ordenes", e);
            }
        }

        /// <summary>
        /// Obtiene todas las ordenes del Sistema
        /// </summary>
        /// <returns>Una lista de Account</returns>
        public IList<Account> GetAll()
        {
            return FindAll();
        }

        /// <summary>
        /// Obtiene las ordenes cerradas de un Restaurante
        /// </summary>
        /// <param name="restaurant">Un objeto de tipo Restaurant</param>
        /// <returns>Una lista de Close Account</returns>

        public IList<Account> ClosedOrdersByRestaurant(Restaurant restaurant)
        {
            ICriterion criterion = Expression.Eq("Status", ClosedAccountStatus.Instance);
            try
            {
                IList<Account> list = new List<Account>();
                list = (FindAll(criterion));
                return list;
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new FondaIndexException("No se encontraron ordenes cerradas", e);
            }

        }
    }
}
