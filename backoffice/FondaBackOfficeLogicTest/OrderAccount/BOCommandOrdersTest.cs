using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using FondaLogic;
using FondaLogic.Factory;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Tests.DataAccess
{
    [TestFixture()]
    public class BOCommandOrdersTest
    {
        private int _restaurantId, _orderId;
        private Command _command;
        private IList<Account> _listAccount;
        private IList<Account> _listClosedOrders;
        private IList<DishOrder> _listDishOrder;
        private IList<Invoice> _listInvoices;
        private FactoryDAO _facDAO;
        private IOrderAccountDao _orderAccountDAO;
        private Restaurant _restaurant;
        private Invoice _invoice;
        private Account _account;
        private IInvoiceDao _invoiceDAO;
        private string _totalOrders;
        private List<int> parameters;
        List<Object> result;
        private string _currency;

        [SetUp]
        public void Init()
        {
            if (_facDAO == null)
                _facDAO = FactoryDAO.Intance;

            _orderAccountDAO = _facDAO.GetOrderAccountDAO();
            _restaurant = new Restaurant();
            _listClosedOrders = new List<Account>();
            _restaurant.Id = 1;
            IRestaurantDAO _restaurantDAO = _facDAO.GetRestaurantDAO();
            _restaurant = _restaurantDAO.FindById(_restaurant.Id);
            _restaurantId = _orderId = 1;

            _account = new Account();
            _invoice = new Invoice();
            _account.Id = 2;
            _invoiceDAO = _facDAO.GetInvoiceDao();
            IOrderAccountDao _accountDAO = _facDAO.GetOrderAccountDAO();
            _account = _accountDAO.FindById(_account.Id);
            _listInvoices = new List<Invoice>();
            _totalOrders = null;
            parameters = new List<int> { _orderId, _restaurantId };
            _listDishOrder = new List<DishOrder>();
            result = null;
            _currency = null;
        }

        [Test]
        public void CommandGetOrdersTest()
        {

            _command = CommandFactory.GetCommandGetOrders(_restaurantId);

            _command.Execute();

            _listAccount = (IList<Account>)_command.Receiver;

            Assert.IsNotNull(_listAccount);

        }

        [Test]
        [Ignore("Esta prueba es engañosa, no existe ningun restaurant con Id 100")]
        public void CommandGetOrdersNullTest()
        {
            _command = CommandFactory.GetCommandGetOrders(100);

            _command.Execute();

            IList<Account> list = (IList<Account>)_command.Receiver;

            Assert.IsNotNull(list);
            Assert.Greater(list.Count, 0);
        }



        [Test]
        public void CommandGetOrderTest()
        {
            _command = CommandFactory.GetCommandGetOrder(_orderId);

            _command.Execute();

            _account = (Account)_command.Receiver;

            Assert.IsNotNull(_account);

        }

        [Test]
        public void CommandCloseCashRegisterTest()
        {
            _command = CommandFactory.GetCommandCloseCashRegister(_restaurantId);

            _command.Execute();

            _totalOrders = (string)_command.Receiver;

            Assert.IsNotNull(_totalOrders);
            Assert.AreEqual(_totalOrders, "€ 13900");
        }

        [Test]
        public void CommandGetDetailOrderTest()
        {
            _command = CommandFactory.GetCommandGetDetailOrder(parameters);

            _command.Execute();

            result = (List<Object>)_command.Receiver;
            _listDishOrder = (IList<DishOrder>)result[0];
            _account = (Account)result[1];
            _currency = (string)result[2];

            Assert.IsNotNull(result);
            Assert.AreEqual(_listDishOrder.Count, 2);
            Assert.AreEqual(_currency, "€");
        }

    }
}
