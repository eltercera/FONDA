using com.ds201625.fonda.View.BackOfficeModel.OrderAccount;
using com.ds201625.fonda.View.BackOfficePresenter.OrderAccount;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace FondaMVPTest
{
    [TestFixture()]
    public class BODetailOrderPresenterTest
    {
        private MockRepository _MockRepository;
        private Mock<IDetailOrderContract> _mock;
        private IDetailOrderContract contract;
        private DetailOrderPresenter _detailOrderPresenter;
        private Mock<HttpRequestBase> _queryStringMock;
        private Mock<HttpContextBase> _contextMock;
        private NameValueCollection queryString;

        [SetUp]
        public void Init()
        {
            _MockRepository = new MockRepository(MockBehavior.Loose);
            _mock = _MockRepository.Create<IDetailOrderContract>();
            _queryStringMock = _MockRepository.Create<HttpRequestBase>();
            _contextMock = _MockRepository.Create<HttpContextBase>();

        }

        [Test(Description = "Carga la tabla con el detalle de una Orden")]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetDetailOrderTest()
        {
            Table detailOrderTable = new Table();
            _mock.Setup(x => x.DetailOrderTable).Returns(detailOrderTable);

            HtmlGenericControl successLabel = new HtmlGenericControl();
            _mock.Setup(x => x.SuccessLabel).Returns(successLabel);

            HtmlGenericControl errorLabel = new HtmlGenericControl();
            _mock.Setup(x => x.ErrorLabel).Returns(errorLabel);

            string sessionId = "1";
            _mock.Setup(x => x.SessionRestaurant).Returns(sessionId);

            string sessionAccountId = "2";
            _mock.Setup(x => x.Session).Returns(sessionAccountId);

            queryString = new NameValueCollection { { "Id", "1" } };
            _queryStringMock.Setup(x => x.QueryString).Returns(queryString);

            _contextMock.Setup(x => x.Request).Returns(_queryStringMock.Object);

            Label errorLabelMessage = new Label();
            _mock.Setup(x => x.ErrorLabelMessage).Returns(errorLabelMessage);

            contract = _mock.Object;

            _detailOrderPresenter = new DetailOrderPresenter(contract);

            _detailOrderPresenter.GetDetailOrder();

            Assert.AreEqual(3, contract.DetailOrderTable.Rows.Count);
            Assert.AreEqual(false, contract.ErrorLabel.Visible);
            Assert.AreEqual(false, contract.SuccessLabel.Visible);
            Assert.AreEqual("1", contract.SessionRestaurant);

        }

    }
}
