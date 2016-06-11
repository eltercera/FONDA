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
        private FactoryDAO _facDAO;
        private IOrderAccountDao _orderAccountDAO;
        private Restaurant _restaurant;
        private Account _account;

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

        }

        [Test]
        public void ClosedOrdersTest()
        {

            _listClosedOrders = _orderAccountDAO.ClosedOrdersByRestaurant(_restaurant);
            Assert.IsNotNull(_listClosedOrders);
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
        public void CommandGetOrderTest()
        {
            _command = CommandFactory.GetCommandGetOrder(_orderId);

            _command.Execute();

            _account = (Account)_command.Receiver;

            Assert.IsNotNull(_account);

        }

    }
}
