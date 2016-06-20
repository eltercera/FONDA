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
        #region Fields

        private FactoryDAO _facDAO;
        private IInvoiceDao _invoiceDAO;
        private IOrderAccountDao _accountDAO;
        private IProfileDAO _profileDao;
        private IRestaurantDAO _restaurantDAO;
        private Restaurant _restaurant;
        private Invoice _invoice;
        private Account _account;
        private CashPayment _cashPayment;
        private CreditCardPayment _creditPayment;
        private Profile _profile;
        private IList<Invoice> _listInvoices;
        private int _number, _accountId, _restaurantId, _profileId;
        private float _amount, _tax;

        #endregion

        [SetUp]
        public void Init()
        {
            _facDAO = FactoryDAO.Intance;

            //Llama a interfaces DAO
            _restaurantDAO = _facDAO.GetRestaurantDAO();
            _accountDAO = _facDAO.GetOrderAccountDAO();
            _invoiceDAO = _facDAO.GetInvoiceDao();

            //Inicializa variables
            _accountId = 2;
            _restaurantId = 1;
            _profileId = 1;
            _tax = _amount * 0.12F;

            //Consigue eventos de la Base de Datos
            _restaurant = _restaurantDAO.FindById(_restaurantId);
            _account = _accountDAO.FindById(_accountId);
            _profile = _profileDao.FindById(_profileId);

            _number = _invoiceDAO.GenerateNumberInvoice(_restaurant);

            //Instancia objetos a utilizar
            _cashPayment = EntityFactory.GetCashPayment(_amount);
            _invoice = EntityFactory.GetInvoice(
                _cashPayment, _profile, _amount, _tax, _restaurant.Currency, _number);

            
            _listInvoices = new List<Invoice>();
        }

        [Test]
        public void FindInvoiceByRestaurantTest()
        {

            _listInvoices = _invoiceDAO.FindInvoicesByRestaurant(_restaurant);
            Assert.IsNotNull(_listInvoices);
            Assert.AreEqual(_listInvoices[0].Id, 1);
            Assert.AreEqual(_listInvoices[1].Id, 2);
            Assert.AreEqual(_listInvoices[2].Number, 3);
        }

        [Test]
        public void GenerateNumberInvoice()
        {

            _number = _invoiceDAO.GenerateNumberInvoice(_restaurant);
            //Hay 6 facturas insertadas 
            Assert.IsNotNull(_number);
            Assert.AreEqual(_number,7);
        }

        [Test]
        [Ignore("Probar los cambios realizados")]
        public void FindGenerateInvoiceByAccountTest()
        {

            _invoice = _invoiceDAO.FindGenerateInvoiceByAccount(_account);
            Assert.IsNotNull(_invoice);
            Assert.AreEqual(_invoice.Id,2);
            Assert.AreEqual(_invoice.Number, 2);
        }

        [Test]
        [Ignore("Probar los cambios realizados")]
        public void FindInvoicesByAccountTest()
        {

            _listInvoices = _invoiceDAO.FindInvoicesByAccount(_accountId);
            Assert.IsNotNull(_listInvoices);
            Assert.AreEqual(_listInvoices[0].Id,2);
        }

        [Test]
        public void SaveInvoiceTest()
        {
            _invoiceDAO.Save(_invoice);

        }


        [TearDown]
        public void EndTests()
        {

        }
    }
}

