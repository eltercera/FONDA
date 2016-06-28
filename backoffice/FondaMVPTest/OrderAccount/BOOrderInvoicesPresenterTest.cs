using com.ds201625.fonda.View.BackOfficeModel.OrderAccount;
using com.ds201625.fonda.View.BackOfficePresenter.OrderAccount;
using Moq;
using NUnit.Framework;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace FondaMVPTest
{
    [TestFixture()]
    public class BOOrderInvoicesPresenterTest
    {
        private MockRepository _MockRepository;
        private Mock<IOrderInvoicesContract> _mock;
        private IOrderInvoicesContract contract;
        private OrderInvoicesPresenter _orderInvoicesPresenter;

        [SetUp]
        public void Init()
        {
            _MockRepository = new MockRepository(MockBehavior.Loose);
            _mock = _MockRepository.Create<IOrderInvoicesContract>();

        }


        [Test(Description = "Caso de error, cuando la tabla de facturas no tiene un Id de Restaurante")]
        public void ErrorGetOrdersTest()
        {
            Table invoicesTable = new Table();
            _mock.Setup(x => x.OrderInvoicesTable).Returns(invoicesTable);

            HtmlGenericControl errorLabel = new HtmlGenericControl();
            _mock.Setup(x => x.ErrorLabel).Returns(errorLabel);

            Label errorLabelMessage = new Label();
            _mock.Setup(x => x.ErrorLabelMessage).Returns(errorLabelMessage);

            contract = _mock.Object;

            _orderInvoicesPresenter = new OrderInvoicesPresenter(contract);

            _orderInvoicesPresenter.GetInvoices();

            Assert.AreEqual(0, contract.OrderInvoicesTable.Rows.Count);
            Assert.AreEqual(true, contract.ErrorLabel.Visible);

        }

        [Test(Description = "Carga la tabla con las ordenes")]
        public void GetOrdersTest()
        {
            Table orderTable = new Table();
            _mock.Setup(x => x.OrderInvoicesTable).Returns(orderTable);

            HtmlGenericControl successLabel = new HtmlGenericControl();
            _mock.Setup(x => x.SuccessLabel).Returns(successLabel);

            HtmlGenericControl errorLabel = new HtmlGenericControl();
            _mock.Setup(x => x.ErrorLabel).Returns(errorLabel);

            string sessionId = "1";
            _mock.Setup(x => x.SessionRestaurant).Returns(sessionId);

            string sessionAccountId = "2";
            _mock.Setup(x => x.SessionAccountId).Returns(sessionAccountId);

            Label errorLabelMessage = new Label();
            _mock.Setup(x => x.ErrorLabelMessage).Returns(errorLabelMessage);

            contract = _mock.Object;

            _orderInvoicesPresenter = new OrderInvoicesPresenter(contract);

            _orderInvoicesPresenter.GetInvoices();

            Assert.AreEqual(3, contract.OrderInvoicesTable.Rows.Count);
            Assert.AreEqual(false, contract.ErrorLabel.Visible);
            Assert.AreEqual(false, contract.SuccessLabel.Visible);
            Assert.AreEqual("1", contract.SessionRestaurant);

        }
    }
}
