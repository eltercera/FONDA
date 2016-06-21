using com.ds201625.fonda;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Factory;
using FondaLogic;
using FondaLogic.Factory;
using FondaLogic.FondaCommandException.OrderAccount;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FondaBackOfficeLogicTest
{
    public class BOCommandInvoiceTest
    {
        private int _restaurantId, _profileId,_accountId, _invoiceId;
        private Command _command;
        private IList<Account> _listClosedOrders;
        private IList<Invoice> _listInvoices;
        private FactoryDAO _facDAO;
        private IOrderAccountDao _orderAccountDAO;
        private Restaurant _restaurant;
        private Invoice _invoice;
        private Account _account;
        private IInvoiceDao _invoiceDAO;
        private ICommensalDAO _commensalDAO;
        private IList<object> _listObject;
        private IList<int> _list;
        private Commensal _commensal;
        private Profile _profile;
        private CashPayment _cashPayment;
        private CreditCardPayment _creditPayment;
        private int _commensalId;


        [SetUp]
        public void Init()
        {
            _facDAO = FactoryDAO.Intance;
            _listObject = new List<object>();
            _list = new List<int>();
            _orderAccountDAO = _facDAO.GetOrderAccountDAO();
            _commensalDAO = _facDAO.GetCommensalDAO();
            _restaurant = new Restaurant();
            _listClosedOrders = new List<Account>();
            _restaurant.Id = 1;
            IRestaurantDAO _restaurantDAO = _facDAO.GetRestaurantDAO();
            _restaurant = _restaurantDAO.FindById(_restaurant.Id);
            _restaurantId = _profileId= 1;
            _accountId = 3;
            _invoiceId = 10;
            _commensalId = 20;
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
            _commensal = (Commensal) _commensalDAO.FindById(_commensalId);     
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
            _invoice = EntityFactory.GetInvoice(_cashPayment, _profile, _cashPayment.Amount, ((_cashPayment.Amount)*0.12f), null, 100, i);
           _listObject.Add(_invoice);
            _listObject.Add(_restaurant.Id);
            _listObject.Add(_accountId);
            _command = CommandFactory.GetCommandGenerateInvoice(_listObject);

            _command.Execute();
           // _invoice = _invoiceDAO.FindById();
        }

        [Test]
        public void CommandPrintInvoice()
        {
            _list.Add(_accountId);
            _list.Add(_restaurantId);
            _command = CommandFactory.GetCommandPrintInvoice(_list);

            _command.Execute();
        }

        [Test(Description ="Verifica que devuelva una lista de Invoice dado un perfil")]
        public void CommandGetInvoicesByProfileTest()
        {
            _command = CommandFactory.GetCommandGetInvoicesByProfile(_profileId);
            _command.Execute();
            _listInvoices = (List<Invoice>) _command.Receiver;

            Assert.IsNotNull(_listInvoices);
            Assert.AreEqual(3, _listInvoices.Count);
        }

        [Test]
        [ExpectedException(typeof(CommandExceptionGetInvoicesByProfile))]
        public void ErrorCommandGetInvoicesByProfileTest()
        {
            _command = CommandFactory.GetCommandGetInvoicesByProfile(null);
            _command.Execute();
            _listInvoices = (List<Invoice>)_command.Receiver;

            Assert.IsNull(_listInvoices);
        }

        [Test(Description = "")]
        public void CommandValidateProfileByCommensalTest()
        {
            List<Object> parameters = new List<object>();

            parameters.Add(_profileId);
            parameters.Add(_commensal);
            _command = CommandFactory.GetCommandValidateProfileByCommensal(parameters);
            _command.Execute();

            Assert.IsNull(_command);

        }



        [TearDown]
        public void EndTests()
        {
            //_invoiceDAO.Delete(_invoice);
            _invoiceDAO.ResetSession();
        }
    }
}
