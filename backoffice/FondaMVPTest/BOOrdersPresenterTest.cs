using BackOffice.Seccion.Caja;
using com.ds201625.fonda.View.BackOfficeModel.OrderAccount;
using com.ds201625.fonda.View.BackOfficePresenter.OrderAccount;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaMVPTest
{
    [TestFixture()]
    public class BOOrdersPresenterTest
    {
        private OrdersPresenter _presenter;
        private IOrdersModel orders;
        private string sessionId;

        [SetUp]
        public void Init()
        {
            _presenter = new OrdersPresenter(orders);
            sessionId = "1";
            
        }

        [Test]
        public void OrdersPresenterTest()
        {
            _presenter.GetOrders();
        }
    }
}
