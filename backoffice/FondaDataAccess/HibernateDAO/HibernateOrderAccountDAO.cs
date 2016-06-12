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

        /// <summary>
        /// Obtiene la factura de una orden
        /// </summary>
        /// <param name="account">Un objeto de tipo Account</param>
        /// <returns>Un objeto Invoice</returns>
        public IList<Account> FindAccountByRestaurant(Restaurant _restaurant)
        {
            ICriterion criterion = (Expression.Eq("Restaurant.Id", _restaurant.Id));
            try
            {
                IList<Account> _list = new List<Account>();
                //_list = (FindAll(criterion));
                return _list;
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new FondaIndexException("Not Found invoice", e);
            }
        }

        public int GenerateNumberInvoice(Restaurant _restaurant)
        {
            try
            {
                IList<Account> _list = new List<Account>();
                _list = FindAccountByRestaurant(_restaurant);
                int _length = 0;

                if (!(_list == null))
                {
                    _length = _list.Count;
                    _length = _length + 1;
                }

                return _length;
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new FondaIndexException("Not Found invoice", e);
            }
        }
    }
}
