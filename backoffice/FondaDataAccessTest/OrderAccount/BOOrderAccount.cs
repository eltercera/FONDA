﻿using com.ds201625.fonda.DataAccess.Exceptions;
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
        #region fields
        private Restaurant _restaurant;
        private FactoryDAO _facDAO;
        private IOrderAccountDao _accountDAO;
        private IInvoiceDao _invoiceDAO;
        private IRestaurantDAO _restaurantDAO;
        private Account _account;
        private IList<Account> _listAccounts;
        private int _number, _invoiceId;
        private Table _table;
        private Commensal _commensal;
        private IList<DishOrder> _listOrder;
        private IList<Invoice> _listInvoice;
        private int _restaurantId, _accountId, _profileId;
        private Profile _profile;
        private CashPayment _cashPayment;
        private CreditCardPayment _creditPayment;
        private Invoice _invoice;
        private ICreditCardPaymentDAO creditDao;
        private ICashPaymentDAO _cashPaymentDAO;
        #endregion

        #region Initialzation
        [SetUp]
        public void Init()
        {
            _facDAO = FactoryDAO.Intance;
            _number = 0;
            _table = new Table();
            _commensal = new Commensal();
            _listOrder = new List<DishOrder>();

            _listAccounts = new List<Account>();

            _restaurantId = _accountId = 1;
            _account = (Account)EntityFactory.GetAccount();
            _account.Id = 2;
            _profileId= _invoiceId = 1;

            _accountDAO = _facDAO.GetOrderAccountDAO();
            _invoiceDAO = _facDAO.GetInvoiceDao();
            _restaurantDAO = _facDAO.GetRestaurantDAO();

            _restaurant = _restaurantDAO.FindById(_restaurantId);
            _account = _accountDAO.FindById(_account.Id);
           // _cashPayment2 = (CashPayment)EntityFactory.GetCashPayment(4850f);
            _creditPayment = (CreditCardPayment)EntityFactory.GetCreditCardPayment(4850f, 1234,0);

            _cashPayment = (CashPayment)EntityFactory.GetCashPayment(4850f);
            //_creditCardPayment = (CreditCardPayment)EntityFactory.GetCreditCardPayment(_amount, _lastCardDigits);
            _cashPaymentDAO = _facDAO.GetCashPaymentDAO();
            IProfileDAO _profileDao = _facDAO.GetProfileDAO();
            _profile = _profileDao.FindById(_profileId);
            creditDao = _facDAO.GetCreditCardPaymentDAO();

            _invoice = _invoiceDAO.FindById(_invoiceId);
        }
        #endregion

        #region Pruebas de DataAccess/HibernateOrderAccount/FindAccountsByRestaurant
        [Test(Description = "Busca las cuentas por restaurante")]
        public void FindAccountsByRestaurantTest()
        {

            _listAccounts = _accountDAO.FindAccountByRestaurant(_restaurant.Id);
            Assert.IsNotNull(_listAccounts);
        }

        [Test(Description = "Busca la excepcion cunado consulta las cuentas por restaurante")]
        [ExpectedException(typeof(FindAccountByRestaurantFondaDAOException))]
        public void FindAccountsByRestaurantExceptionTest()
        {

            _listAccounts = _accountDAO.FindAccountByRestaurant(0);
            Assert.AreEqual(_listAccounts.Count,0);
        }

        #endregion

        #region Pruebas de DataAccess/HibernateOrderAccount/ChangeStatusAccount
        [Test(Description = "Prueba que cambia el estatus de una cuenta")]
        public void ChangeStatusAccountTest()
        {
            _account = _accountDAO.FindById(_accountId); //1
            _accountDAO.ChangeStatusAccount(_account);
            _account = _accountDAO.FindById(_accountId);
            Assert.AreEqual(_account.Status, ClosedAccountStatus.Instance);
        }

        [Test(Description = "Busca la excepcion cunado cambia el estatus de una cuenta")]
        [ExpectedException(typeof(ChangeStatusAccountFondaDAOException))]
        public void ChangeStatusAccountTestExceptionTest()
        {

            _account = _accountDAO.FindById(0);
            _accountDAO.ChangeStatusAccount(_account);
            _account = _accountDAO.FindById(0);
            Assert.AreEqual(_account.Status, ClosedAccountStatus.Instance);
        }

        #endregion

        #region Pruebas de DataAccess/HibernateOrderAccount/CancelInvoiceTest
        [Test(Description = "Cuando cambia el estatus de una factura a cancelado")]
        public void CancelInvoiceTest()
        {
            _invoice = _invoiceDAO.FindById(2);
            _invoice = _accountDAO.CancelInvoice(_invoice, 3);
            Assert.AreEqual(_invoice.Status, CanceledInvoiceStatus.Instance);
        }


        [Test(Description = "Busca la excepcion cuando el estatus de una factura a cancelado")]
        [ExpectedException(typeof(CancelInvoiceFondaDAOException))]
        public void CancelInvoiceExceptionTest()
        {
            _invoice = _invoiceDAO.FindById(2);
            _invoice = _accountDAO.CancelInvoice(_invoice, 0);
            Assert.AreEqual(_invoice.Id, 2 );
        }

        #endregion

        #region Pruebas de DataAccess/HibernateOrderAccount/CancelInvoiceTest
        [Test(Description = "Prueba que guarda la invoice de una cuenta")]
        public void SaveInvoicesByAccountTest()
        {
            InvoiceStatus i = _facDAO.GetGeneratedInvoiceStatus();
            _invoice = (Invoice)EntityFactory.GetInvoice(_creditPayment, _profile, 5000, (5000)*0.12f, _restaurant.Currency, 500, i);
            _invoice= _accountDAO.SaveInvoice(_invoice, _accountId, _restaurantId);
            Assert.IsNotNull(_invoice);
            Assert.AreEqual(_invoice.Currency,_restaurant.Currency);
        }

        [Test(Description = "Prueba que guarda la invoice de una cuenta")]
        [ExpectedException(typeof(SaveInvoiceFondaDAOException))]
        public void SaveInvoicesByAccountExceptionTest()
        {
            InvoiceStatus i = _facDAO.GetGeneratedInvoiceStatus();
            _invoice = (Invoice)EntityFactory.GetInvoice(null, _profile, 4850, (4850) * 0.12f, _restaurant.Currency, 100, i);
            _accountDAO.SaveInvoice(_invoice, _accountId, _restaurantId);
        }
        #endregion

        #region Pruebas de DataAccess/HibernateOrderAccount/GenerateNumberAccount
        [Test(Description = "Prueba el numero generado de la cuenta (Numero único de cuenta por restaurante)")]
        public void GenerateNumberAccount()
        {

            _number = _accountDAO.GenerateNumberAccount(_restaurant);
            Assert.IsNotNull(_number);
        }
        [Test(Description = "Prueba el numero generado de la cuenta (Numero único de cuenta por restaurante)")]
        [ExpectedException(typeof(GenerateNumberAccountFondaDAOException))]
        public void GenerateNumberExceptionAccount()
        {

            _number = _accountDAO.GenerateNumberAccount(null);
            Assert.IsNotNull(_number);
        }
        #endregion Pruebas de DataAccess/HibernateOrderAccount/CloseCashRegisterTest

        #region Pruebas de DataAccess/HibernateOrderAccount/CloseCashRegisterTest
        [Test(Description = "Prueba para el cierre de caja")]
        public void CloseCashRegisterTest()
        {
            float _total = _accountDAO.CloseCashRegister(_restaurant.Id);
            Assert.IsNotNull(_total);
            Assert.AreEqual(_total, 13900);
        }
        [Test(Description = "Prueba para el cierre de caja")]
        [ExpectedException(typeof(CloseCashRegisterFondaDAOException))]
        public void CloseCashRegisterExceptionTest()
        {
            float _total = _accountDAO.CloseCashRegister(0);
            Assert.IsNotNull(_total);
            Assert.AreEqual(_total, 13900);
        }
        #endregion

        #region Pruebas de DataAccess/HibernateRestaurantDAO/ClosedOrdersByRestaurantIdTest
        [Test(Description = "Obtiene el numero de ordenes cerradas de un Restaurante por su id")]
        public void ClosedOrdersByRestaurantIdTest()
        {
            _listAccounts = _restaurantDAO.ClosedOrdersByRestaurantId(_restaurantId);
            Assert.IsNotNull(_listAccounts);
            Assert.AreEqual(_listAccounts.Count, 8);
        }
        [Test(Description = "Prueba la excepcion al Obtener el numero de ordenes cerradas de un Restaurante por su id")]
        [ExpectedException(typeof(ClosedOrdersByRestaurantFondaDAOException))]
        public void ClosedOrdersByRestauranExceptionTest()
        {
            _listAccounts = _restaurantDAO.ClosedOrdersByRestaurantId(0);
            Assert.IsNotNull(_listAccounts);
            Assert.AreEqual(_listAccounts.Count, 8);
        }
        #endregion

        #region Pruebas de DataAccess/HibernateRestaurantDAO/OpenOrdersByRestaurantIdTest
        [Test(Description = "Obtiene el numero de ordenes abiertas de un Restaurante por su id")]
        public void OpenOrdersByRestaurantIdTest()
        {
            _listAccounts = _restaurantDAO.OpenOrdersByRestaurantId(_restaurantId);
            Assert.IsNotNull(_listAccounts);
            Assert.AreEqual(_listAccounts.Count, 2);
        }
        [Test(Description = "Obtiene el numero de ordenes abiertas de un Restaurante por su id")]
        [ExpectedException(typeof(OpenOrdersByRestaurantIdFondaDAOException))]
        public void OpenOrdersByRestaurantExceptionTest()
        {
            _listAccounts = _restaurantDAO.OpenOrdersByRestaurantId(0);
            Assert.IsNotNull(_listAccounts);
            Assert.AreEqual(_listAccounts.Count, 2);
        }
        #endregion

        #region DataAccess/HibernateOrderAccount/GetOrderAccount

        [Test]
        public void GetOrderAccountTest()
        {
            Account _result = _accountDAO.GetOrderAccountByInvoice(_invoice,1); //invoice 1
            Assert.IsNotNull(_result);
            Assert.AreEqual(_result.Id,2);
        }

        [Test]
        [ExpectedException(typeof(GetOrderAccountFondaDAOException))]
        public void GetOrderAccountExceptionTest()
        {
            Account _result = _accountDAO.GetOrderAccountByInvoice(_invoice, 0);
            Assert.IsNotNull(_result);
        }

        #endregion


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
