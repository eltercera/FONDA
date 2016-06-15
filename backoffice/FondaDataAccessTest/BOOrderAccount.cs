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
        private IOrderAccountDao _accountDAO;
        private IRestaurantDAO _restaurantDAO;
        private Account _account;
        private IList<Account> _listAccounts;
        private int _number;
        private Table _table;
        private Commensal _commensal;
        private IList<DishOrder> _listOrder;
        private int _restaurantId;

        [SetUp]
        public void Init()
        {
            _facDAO = FactoryDAO.Intance;
            _number = 0;
            _table = new Table();
            _commensal = new Commensal();
            _listOrder = new List<DishOrder>();

            _listAccounts = new List<Account>();

            _restaurantId = 1;
            _account = (Account)EntityFactory.GetAccount();
            _account.Id = 2;

            _accountDAO = _facDAO.GetOrderAccountDAO();
            _restaurantDAO = _facDAO.GetRestaurantDAO();

            _restaurant = _restaurantDAO.FindById(_restaurantId);
            _accountDAO = _facDAO.GetOrderAccountDAO();
            _account = _accountDAO.FindById(_account.Id);

            
        }

        [Test]
        public void FindAccountsByRestaurantTest()
        {

            _listAccounts = _accountDAO.FindAccountByRestaurant(_restaurant.Id);
            Assert.IsNotNull(_listAccounts);
        }

        [Test(Description ="Obtiene el numero de ordenes cerradas de un Restaurante por su id")]
        public void ClosedOrdersByRestaurantIdTest()
        {
            _listAccounts = _restaurantDAO.ClosedOrdersByRestaurantId(_restaurantId);
            Assert.IsNotNull(_listAccounts);
            Assert.AreEqual(_listAccounts.Count, 8);
        }

        [Test(Description = "Obtiene el numero de ordenes abiertas de un Restaurante por su id")]
        public void OpenOrdersByRestaurantIdTest()
        {
            _listAccounts = _restaurantDAO.OpenOrdersByRestaurantId(_restaurantId);
            Assert.IsNotNull(_listAccounts);
            Assert.AreEqual(_listAccounts.Count, 2);
        }


        [Test]
        public void GenerateNumberInvoice()
        {

            _number = _accountDAO.GenerateNumberAccount(_restaurant);
            Assert.IsNotNull(_number);
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
            //_accountDAO.ResetSession();
        }


    }
}
