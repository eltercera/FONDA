using NUnit.Framework;
using System;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.Domain;
using System.Collections.Generic;
using com.ds201625.fonda.Factory;

namespace FondaDataAccessTest
{
    
    
    [TestFixture()]
    public class BOInvoiceTests
    {
        private IList<Invoice> _listInvoices;
        private FactoryDAO _facDAO;
        private Restaurant _restaurant;
        private Invoice _invoice;
        private Account _account;
        private IInvoiceDao _invoiceDAO;
        private int _number, _accountId, _restaurantId;
        private Table _table;
        private Commensal _commensal;
        private IList<DishOrder> _listOrder;
        private int _orderAccountId;

        [SetUp]
        public void Init()
        {
            _facDAO = FactoryDAO.Intance;
            _number = 0;
            _table = new Table();
            _commensal = new Commensal();
            _listOrder = new List<DishOrder>();
            _restaurantId = 1;
            _account = (Account)EntityFactory.GetAccount(_table, _commensal, _listOrder, _number);
            _account.Id = 2;
            IRestaurantDAO _restaurantDAO = _facDAO.GetRestaurantDAO();
            IOrderAccountDao _accountDAO = _facDAO.GetOrderAccountDAO();

            _restaurant = _restaurantDAO.FindById(_restaurantId);
            _account = _accountDAO.FindById(_accountId);


            _invoice = (Invoice)EntityFactory.GetInvoice();

            _invoiceDAO = _facDAO.GetInvoiceDao();
            _listInvoices = new List<Invoice>();
        }

        [Test]
        public void FindInvoiceByRestaurantTest()
        {

            _listInvoices = _invoiceDAO.FindInvoiceByRestaurant(_restaurant);
            Assert.IsNotNull(_listInvoices);
        }

        [Test]
        public void GenerateNumberInvoice()
        {

            _number = _invoiceDAO.GenerateNumberInvoice(_restaurant);
            Assert.IsNotNull(_number);
        }

        [Test]
        public void FindGenerateInvoiceByAccountTest()
        {

            _invoice = _invoiceDAO.FindGenerateInvoiceByAccount(_account);
            Assert.IsNotNull(_invoice);
        }

        [Test]
        public void SaveInvoiceTest()
        {


        }


        [TestFixtureTearDown]
        public void EndTests()
        {
            //if (_invoiceId != 0)
            //{
            //    //getInvoiceDao();
            //    // Eliminacion de la Persona al finalidar todo.
            //    //_personDAO.Delete(_person);
            //}
            _invoiceDAO.ResetSession();
        }
    }
}

