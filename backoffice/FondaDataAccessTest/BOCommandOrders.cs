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
    public class BOCommandOrders
    {
        private int restaurantId;
        private Command commandGetOrders;
        private IList<Account> listAccount;
        private IList<Account> listClosedOrders;
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
            listClosedOrders = new List<Account>();
            _restaurant.Id = 1;
            IRestaurantDAO _restaurantDAO = _facDAO.GetRestaurantDAO();
            _restaurant = _restaurantDAO.FindById(_restaurant.Id);
            restaurantId = 1;

        }

        [Test]
        public void ClosedOrdersTest()
        {

            listClosedOrders = _orderAccountDAO.ClosedOrdersByRestaurant(_restaurant);
            Assert.IsNotNull(listClosedOrders);
            //            Assert.AreEqual(1, _result.Id);
        }

        [Test]
        public void CommandGetOrdersTest()
        {

            commandGetOrders = CommandFactory.GetCommandGetOrders(restaurantId);
      
            commandGetOrders.Execute();

            listAccount = (IList<Account>)commandGetOrders.Receiver;

            Assert.IsNotNull(listAccount);

        }

    }
}
