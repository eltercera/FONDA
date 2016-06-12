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
    class HibernateOrderAccountDAO : HibernateBaseEntityDAO<Account>, IOrderAccountDao
    {
        private FactoryDAO.FactoryDAO _facDAO;
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
        /// Obtiene las cuentas de un Restaurante
        /// </summary>
        /// <param name="idRestaurant">Un ID de Restaurant tipo int</param>
        /// <returns>Una List de Accounts</returns>
        public IList<Account> FindAccountByRestaurant(int _idRestaurant)
        {
            Restaurant _restaurant;
            IRestaurantDAO _restaurantDAO = _facDAO.GetRestaurantDAO();
            
            try
            {
                _restaurant = _restaurantDAO.FindById(_idRestaurant);
                IList<Account> _list = new List<Account>();
                _list = _restaurant.Accounts;
                return _list;
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new FondaIndexException("Not Found invoice", e);
            }
        }

        /// <summary>
        /// Obtiene el numero unico de la orden
        /// </summary>
        /// <param name="Restaurant">Un objeto Restaurant</param>
        /// <returns>Un int que es el numero unico de Cuenta</returns>

        public int GenerateNumberAccount(Restaurant _restaurant)
        {
            try
            {
                IList<Account> _list = new List<Account>();
                _list = FindAccountByRestaurant(_restaurant.Id);
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
