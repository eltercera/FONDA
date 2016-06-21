using com.ds201625.fonda;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Factory;
using FondaLogic;
using FondaLogic.Factory;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaBackOfficeLogicTest
{
    public class BOCommandInvoiceTest
    {
        private int _restaurantId, _profileId,_accountId, _invoiceId;
        private Command _command;
        private IList<Account> _listAccount;
        private IList<Account> _listClosedOrders;
        private IList<Invoice> _listInvoices;
        private FactoryDAO _facDAO;
        private IOrderAccountDao _orderAccountDAO;
        private Restaurant _restaurant;
        private Invoice _invoice;
        private Account _account;
        private IInvoiceDao _invoiceDAO;
        private IList<object> _listObject;
        private IList<int> _list;
        private Profile _profile;
        private CashPayment _cashPayment;
        private CreditCardPayment _creditPayment;


        [SetUp]
        public void Init()
        {
            _facDAO = FactoryDAO.Intance;
            _listObject = new List<object>();
            _list = new List<int>();
            _orderAccountDAO = _facDAO.GetOrderAccountDAO();
            _restaurant = new Restaurant();
            _listClosedOrders = new List<Account>();
            _restaurant.Id = 1;
            IRestaurantDAO _restaurantDAO = _facDAO.GetRestaurantDAO();
            _restaurant = _restaurantDAO.FindById(_restaurant.Id);
            _restaurantId = _profileId= 1;
            _accountId = 3;
            _invoiceId = 10;
            _account = new Account();
            _invoice = EntityFactory.GetInvoice();
            _account.Id = 2;
            _invoiceDAO = _facDAO.GetInvoiceDao();
            IOrderAccountDao _accountDAO = _facDAO.GetOrderAccountDAO();
            IProfileDAO _profileDao = _facDAO.GetProfileDAO();
            IUserAccountDAO _uaDAO = _facDAO.GetUserAccountDAO();
            _account = _accountDAO.FindById(_account.Id);
            _listInvoices = new List<Invoice>();
            _cashPayment = EntityFactory.GetCashPayment(100);
            UserAccount ua = _uaDAO.FindById(20);
            _profile =_profileDao.FindById(_profileId);
            _invoice = _invoiceDAO.FindById(_invoiceId);
            //IBaseEntityDAO<Payment> bla = _facDAO
        }

        [Test]
        public void CommandFindInvoicesByRestaurantTest()
        {

            _command = CommandFactory.GetCommandFindInvoicesByRestaurant(_restaurant);

            _command.Execute();

            _listInvoices = (IList<Invoice>)_command.Receiver;

            Assert.IsNotNull(_listInvoices);
            Assert.AreEqual(_listInvoices[0].Id,1);
            Assert.AreEqual(_listInvoices[1].Number, 2);
        }

        [Test]
        public void CommandGenerateInvoiceTest()
        {
            InvoiceStatus i = _facDAO.GetGeneratedInvoiceStatus();
            _invoice = EntityFactory.GetInvoice(_cashPayment, _profile, 4850, 0.12f, null, 100, i);
           _listObject.Add(_invoice);
            _listObject.Add(_restaurant.Id);
            _listObject.Add(_account.Id);
            _command = CommandFactory.GetCommandGenerateInvoice(_listObject);

            _command.Execute();
           // _invoice = _invoiceDAO.FindById();
        }

        [Test]
        public void CommandPrintInvoice()
        {
            InvoiceStatus i = _facDAO.GetGeneratedInvoiceStatus();
            //_invoice = (Invoice)EntityFactory.GetInvoice(_cashPayment, _profile, 100, 4850, 0.12f, null, 100, i);
            _list.Add(_accountId);
            _list.Add(_restaurantId);
            //_listEntity.Add(_account);
            _command = CommandFactory.GetCommandPrintInvoice(_list);

            _command.Execute();
        }
    }
}
