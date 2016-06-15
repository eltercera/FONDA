using BackOffice.Seccion.Caja;
using BackOfficeModel.OrderAccount;
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
        private com.ds201625.fonda.BackOffice.Presenter.DefaultPresenter _presenter;
        private IOrdersModel orders;
        private string sessionId;

        [SetUp]
        public void Init()
        {
            _presenter = new com.ds201625.fonda.BackOffice.Presenter.DefaultPresenter(orders);
            sessionId = "1";
            
        }

        [Test]
        public void OrdersPresenterTest()
        {
            _presenter.GetOrders(sessionId);
        }
    }
}
