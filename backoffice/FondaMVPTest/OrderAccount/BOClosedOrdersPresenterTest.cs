using com.ds201625.fonda.View.BackOfficeModel.OrderAccount;
using com.ds201625.fonda.View.BackOfficePresenter.OrderAccount;
using Moq;
using NUnit.Framework;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace FondaMVPTest
{
    [TestFixture]
    public class BOClosedOrdersPresenterTest
    {
        private MockRepository _MockRepository;
        private Mock<IClosedOrdersContract> _mock;
        private IClosedOrdersContract contract;
        private ClosedOrdersPresenter _closedOrdersPresenter;

        [SetUp]
        public void Init()
        {
            _MockRepository = new MockRepository(MockBehavior.Loose);
            _mock = _MockRepository.Create<IClosedOrdersContract>();

        }

        [Test(Description = "Caso de error, cuando la tabla de ordenes no tiene un Id de Restaurante")]
        public void ErrorGetClosedOrdersTest()
        {
            Table closedOrderTable = new Table();
            _mock.Setup(x => x.ClosedOrdersTable).Returns(closedOrderTable);

            HtmlGenericControl successLabel = new HtmlGenericControl();
            _mock.Setup(x => x.SuccessLabel).Returns(successLabel);

            HtmlGenericControl errorLabel = new HtmlGenericControl();
            _mock.Setup(x => x.ErrorLabel).Returns(errorLabel);

            Label errorLabelMessage = new Label();
            _mock.Setup(x => x.ErrorLabelMessage).Returns(errorLabelMessage);

            contract = _mock.Object;

            _closedOrdersPresenter = new ClosedOrdersPresenter(contract);

            _closedOrdersPresenter.GetClosedOrders();

            Assert.AreEqual(1, contract.ClosedOrdersTable.Rows.Count);
            Assert.AreEqual(true, contract.ErrorLabel.Visible);

        }

        [Test(Description = "Carga la tabla con la ordenes cerradas de un Restaurante")]
        public void GetClosedOrdersTest()
        {
            Table orderTable = new Table();
            _mock.Setup(x => x.ClosedOrdersTable).Returns(orderTable);

            HtmlGenericControl successLabel = new HtmlGenericControl();
            _mock.Setup(x => x.SuccessLabel).Returns(successLabel);

            HtmlGenericControl errorLabel = new HtmlGenericControl();
            _mock.Setup(x => x.ErrorLabel).Returns(errorLabel);

            string sessionId = "1";
            _mock.Setup(x => x.SessionRestaurant).Returns(sessionId);

            Label errorLabelMessage = new Label();
            _mock.Setup(x => x.ErrorLabelMessage).Returns(errorLabelMessage);

            contract = _mock.Object;

            _closedOrdersPresenter = new ClosedOrdersPresenter(contract);

            _closedOrdersPresenter.GetClosedOrders();

            Assert.AreEqual(9, contract.ClosedOrdersTable.Rows.Count);
            Assert.AreEqual(false, contract.ErrorLabel.Visible);
            Assert.AreEqual(false, contract.SuccessLabel.Visible);
            Assert.AreEqual("1", contract.SessionRestaurant);

        }


    }
}
