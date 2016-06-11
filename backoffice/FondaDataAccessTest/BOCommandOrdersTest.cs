using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
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

        IList<Account> listClosedOrders;
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
            //nA1 = 1;
            //nA2 = 2;
            //listClosedOrders.Add(nA1);
            //listClosedOrders.Add(nA2);
        }

        [Test]
        public void ClosedOrdersTest()
        {

            listClosedOrders = _orderAccountDAO.ClosedOrdersByRestaurant(_restaurant);
            Assert.IsNotNull(listClosedOrders);
        }

    }
}
