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
        private int _number;
        private Table _table;
        private Commensal _commensal;
        private IList<DishOrder> _listOrder;
        private IList<Invoice> _listInvoice;
        private int _restaurantId, _accountId, _profileId;
        private Profile _profile;
        private CashPayment _cashPayment2;
        private CashPayment _cashPayment;
        private CreditCardPayment _creditPayment;
        private Invoice _invoice;
        private ICreditCardPaymentDAO creditDao;
        private ICashPaymentDAO _cashPaymentDAO;
        #endregion
        #region setup
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
            _profileId = 1;

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
        }
        #endregion
        [Test(Description = "Busca las cuentas por restaurante")]
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

        [Test(Description ="Obtiene una lista de facturas generadas por una Orden")]
        public void FindInvoicesByAccountTest()
        {
            _listInvoice = _invoiceDAO.FindInvoicesByAccount(_accountId);

            Assert.IsNotNull(_listInvoice);
            Assert.AreEqual(1, _listInvoice.Count);

        }

        [Test(Description = "Prueba el numero generado de la cuenta (Numero único de cuenta por restaurante)")]
        public void GenerateNumberAccount()
        {

            _number = _accountDAO.GenerateNumberAccount(_restaurant);
            Assert.IsNotNull(_number);
        }

        [Test(Description = "Prueba para el cierre de caja")]
        public void CloseCashRegisterTest()
        {
            float _total = _accountDAO.CloseCashRegister(_restaurant.Id);
            Assert.IsNotNull(_total);
            Assert.AreEqual(_total, 13900);
        }

        [Test(Description = "Prueba que guarda la invoice de una cuenta")]
        public void SaveInvoicesByAccountTest()
        {
            InvoiceStatus i = _facDAO.GetGeneratedInvoiceStatus();
            _invoice = (Invoice)EntityFactory.GetInvoice(_creditPayment, _profile, 4850, 0.12f, _restaurant.Currency, 100, i);
            //_invoiceDAO.Save(_invoice);
            _accountDAO.SaveInvoice(_invoice,_accountId,_restaurantId);
        }
        [Test(Description = "Prueba que cambia el estatus de una cuenta")]
        public void ChangeStatusAccountTest()
        {
            _account = _accountDAO.FindById(_accountId);
            _accountDAO.ChangeStatusAccount(_account);
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
