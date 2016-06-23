using NUnit.Framework;
using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System.Collections.Generic;
using com.ds201625.fonda.Factory;
using com.ds201625.fonda.DataAccess.Exceptions;

namespace FondaDataAccessTest
{

    [TestFixture()]
    public class BODishOrderTest
    {
        #region field
        private int accountId, _number;
        private IList<DishOrder> _listDishOrder;
        private Account _account;
        private Table _table;
        private Commensal _commensal;
        private DishOrder _dishOrder;
        private FactoryDAO _facDAO;
        private IDishOrderDAO _dishOrderDAO;
        #endregion

        #region Setup
        [SetUp]
        public void Init()
        {
            if (_facDAO == null)
                _facDAO = FactoryDAO.Intance;

            _dishOrderDAO = _facDAO.GetDishOrderDAO();
            _number = 0;
            _table = new Table();
            _commensal = new Commensal();
            _dishOrder = new DishOrder();
            _listDishOrder = new List<DishOrder>();
            _account = EntityFactory.GetAccount(_table,_commensal,_listDishOrder,_number);
            _account.Id = 1;
            accountId = 1;


        }
        #endregion

        #region Pruebas de DataAccess/HibernateOrderAccount/FindAccountsByRestaurant
        [Test(Description = "Busca los platillos de una orden")]
        public void DishOrderTest()
        {

            _listDishOrder = _dishOrderDAO.GetDishesByAccount(accountId);
            Assert.IsNotNull(_listDishOrder);
        }

        [Test(Description = "Prueba  la excepcion al buscar los platillos de una orden")]
        [ExpectedException(typeof(GetDishesByAccountFondaDAOException))]
        public void DishOrderExceptionTest()
        {

            _listDishOrder = _dishOrderDAO.GetDishesByAccount(0);
            Assert.IsNotNull(_listDishOrder);
        }
        #endregion
    }
}
