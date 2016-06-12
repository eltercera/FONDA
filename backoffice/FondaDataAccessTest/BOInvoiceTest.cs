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

        [SetUp]
        public void Init()
        {
            if (_facDAO == null)
                _facDAO = FactoryDAO.Intance;


            IRestaurantDAO _restaurantDAO = _facDAO.GetRestaurantDAO();
            IOrderAccountDao _accountDAO = _facDAO.GetOrderAccountDAO();

            _restaurant = _restaurantDAO.FindById(_restaurantId);
            _account = _accountDAO.FindById(_accountId);


            _invoice = (Invoice)EntityFactory.GetAccount();

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

