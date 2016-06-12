using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Factory;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FondaDataAccessTest
{
    [TestFixture()]
    public class BOOrderAccount
    {
        private Restaurant _restaurant;
        private FactoryDAO _facDAO;
        private IOrderAccountDao _orderAccountDAO;
        private Account _account;
        private IList<Account> _listInvoices;
        private IOrderAccountDao _acccountDAO;
        private int number;
        private IDishOrderDAO _dishOrderDAO;
        private ICommensalDAO _commensalDAO;
        private Table _table;
        private Commensal _commensal;
        private IList<DishOrder> _listOrder;
        private int _orderAccountId, _number;

        [SetUp]
        public void Init()
        {
            _account = (Account)EntityFactory.GetAccount(_table, _commensal, _listOrder, _number);
            _account.Id = 2;
            _table = new Table();
            _orderAccountDAO = _facDAO.GetOrderAccountDAO();
            _restaurant = new Restaurant();
            _restaurant.Id = 1;
            IRestaurantDAO _restaurantDAO = _facDAO.GetRestaurantDAO();
            _restaurant = _restaurantDAO.FindById(_restaurant.Id);
            IOrderAccountDao _accountDAO = _facDAO.GetOrderAccountDAO();
            _account = _accountDAO.FindById(_account.Id);
            _listInvoices = new List<Account>();
            _commensal = new Commensal();
            _listOrder = new List<DishOrder>();
            _number = 0;

            
        }

        [Test]
        public void FindAccountsByRestaurantTest()
        {

            _listInvoices = _acccountDAO.FindAccountByRestaurant(_restaurant.Id);
            Assert.IsNotNull(_listInvoices);
        }
        [Test]
        public void GenerateNumberInvoice()
        {

            number = _acccountDAO.GenerateNumberAccount(_restaurant);
            Assert.IsNotNull(number);
        }

        [Test]
        public void SaveAccount()
        {

        }

        [TestFixtureTearDown]
        public void EndTests()
        {
            //if (_OrderAccountID != 0)
            //{
            //    GetOrderAccountDAO();
            //    // Eliminacion de la Persona al finalidar todo.
            //    // _orderDAO.Delete(account);

            //}
            _orderAccountDAO.ResetSession();
        }


    }
}
