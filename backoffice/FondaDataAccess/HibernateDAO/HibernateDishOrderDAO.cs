using System;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System.Collections.Generic;
using com.ds201625.fonda.DataAccess.FondaDAOExceptions;
using FondaResources.OrderAccount;
using com.ds201625.fonda.DataAccess.Exceptions;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateDishOrderDAO : HibernateBaseEntityDAO<DishOrder>, IDishOrderDAO
    {
        private FactoryDAO.FactoryDAO _facDAO = FactoryDAO.FactoryDAO.Intance;
        public IList<DishOrder> GetAll()
        {
            return FindAll();
        }

        /// <summary>
        /// Obtiene una lista de platos de una orden
        /// </summary>
        /// <param name="account">Un objeto de tipo Account</param>
        /// <returns>Una List de platos</returns>
        /// 
        public IList<DishOrder> GetDishesByAccount(int _accountId)
        {
            try
            {
                IOrderAccountDao _accountDAO = _facDAO.GetOrderAccountDAO();
                //Buscar los platos de una orden
                IList<DishOrder> dishOrder = GetAll();
                IList<DishOrder> _dishOrder = new List<DishOrder>();
                IList<Account> _listAccount = _accountDAO.GetAll();
                Account _account = _accountDAO.FindById(_accountId);

                return _account.ListDish;
            }
            catch (ArgumentOutOfRangeException e)
            {
                GetDishesByAccountFondaDAOException exception =
        new GetDishesByAccountFondaDAOException(
            OrderAccountResources.MessageGetDishesByAccountFondaDAOException,
            e);
                //Logger
                throw exception;
            }
            catch (Exception e)
            {
                GetDishesByAccountFondaDAOException exception =
        new GetDishesByAccountFondaDAOException(
            OrderAccountResources.MessageGetDishesByAccountFondaDAOException,
            e);
                //Logger
                throw exception;
            }


        }
    }
}
