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
        private Command _command;
        private IList<Invoice> _listInvoices;
        private FactoryDAO _facDAO;
        private Restaurant _restaurant;
        private Invoice _invoice;
        private Account _account;
        private IInvoiceDao _invoiceDAO;
        private int _restaurantId;

        [SetUp]
        public void Init()
        {
                _facDAO = FactoryDAO.Intance;

            _restaurant = new Restaurant();
            _restaurant.Id = 1;
            IRestaurantDAO _restaurantDAO = _facDAO.GetRestaurantDAO();
            _restaurant = _restaurantDAO.FindById(_restaurant.Id);
            _restaurantId = 1;

            _account = (Account)EntityFactory.GetAccount();
            _invoice = (Invoice)EntityFactory.GetInvoice();
            _account.Id = 2;
            _invoiceDAO = _facDAO.GetInvoiceDao();
            IOrderAccountDao _accountDAO = _facDAO.GetOrderAccountDAO();
            _account = _accountDAO.FindById(_account.Id);
            _listInvoices = new List<Invoice>();
        }

        [Test]
        public void CommandGetGenerateInvoiceTest()
        {
            _command = CommandFactory.GetCommandGenerateInvoice(_account);

            _command.Execute();

            _invoice = (Invoice)_command.Receiver;

            Assert.IsNotNull(_invoice);
            Assert.AreEqual(_invoice.Id, 2);
            Assert.AreEqual(_invoice.Number, 2);

        }

        [Test]
        public void CommandFindInvoicesByAccountTest()
        {
            _command = CommandFactory.GetCommandFindInvoicesByAccount(_account);

            _command.Execute();

            _listInvoices = (IList<Invoice>)_command.Receiver;

            Assert.IsNotNull(_invoice);

            Assert.AreEqual(_listInvoices[0].Id, 2);

        }

    }
}
