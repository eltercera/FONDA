using System;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System.Collections.Generic;
using com.ds201625.fonda.DataAccess.FondaDAOExceptions;

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
                IList<DishOrder> _dishOrder = new List<DishOrder>();
                Account _account = _accountDAO.FindById(_accountId);

                return _account.ListDish;
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new FondaIndexException("Not Found Dish Order", e);
            }


        }
    }
}
