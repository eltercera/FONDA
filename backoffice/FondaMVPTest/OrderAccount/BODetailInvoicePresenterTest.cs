using com.ds201625.fonda.View.BackOfficeModel.OrderAccount;
using com.ds201625.fonda.View.BackOfficePresenter.OrderAccount;
using Moq;
using NUnit.Framework;
using System.Collections.Specialized;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace FondaMVPTest
{
    [TestFixture]
    public class BODetailInvoicePresenterTest
    {
        private MockRepository _MockRepository;
        private Mock<IDetailInvoiceContract> _mock;
        private IDetailInvoiceContract contract;
        private DetailInvoicePresenter _detailInvoicePresenter;
        private Mock<HttpRequestBase> _queryStringMock;
        private Mock<HttpContextBase> _contextMock;
        private NameValueCollection queryString;

        [SetUp]
        public void Init()
        {
            _MockRepository = new MockRepository(MockBehavior.Loose);
            _mock = _MockRepository.Create<IDetailInvoiceContract>();
            _queryStringMock = _MockRepository.Create<HttpRequestBase>();
            _contextMock = _MockRepository.Create<HttpContextBase>();

            Label date = new Label();
            _mock.Setup(x => x.DateInvoice).Returns(date);

            Label accountNumber = new Label();
            _mock.Setup(x => x.NumberAccount).Returns(accountNumber);

            Label name = new Label();
            _mock.Setup(x => x.UserName).Returns(name);

            Label lastname = new Label();
            _mock.Setup(x => x.UserLastName).Returns(lastname);

            Label ssn = new Label();
            _mock.Setup(x => x.UserId).Returns(ssn);

            Label subtotal = new Label();
            _mock.Setup(x => x.SubTotalInvoice).Returns(subtotal);

            Label tax = new Label();
            _mock.Setup(x => x.IvaInvoice).Returns(tax);

            Label total = new Label();
            _mock.Setup(x => x.TotalInvoice).Returns(total);

            Label tip = new Label();
            _mock.Setup(x => x.TipInvoice).Returns(tip);

        }


        [Test(Description = "Carga la tabla con el detalle de la factura de una Orden")]
        public void GetDetailInvoiceTest()
        {
            Table orderTable = new Table();
            _mock.Setup(x => x.DetailInvoiceTable).Returns(orderTable);

            HtmlGenericControl successLabel = new HtmlGenericControl();
            _mock.Setup(x => x.SuccessLabel).Returns(successLabel);

            HtmlGenericControl errorLabel = new HtmlGenericControl();
            _mock.Setup(x => x.ErrorLabel).Returns(errorLabel);

            string sessionId = "1";
            _mock.Setup(x => x.SessionRestaurant).Returns(sessionId);

            string sessionAccountId = "2";
            _mock.Setup(x => x.SessionIdAccount).Returns(sessionAccountId);

            string sessionNumberAccount = "2";
            _mock.Setup(x => x.SessionNumberInvoice).Returns(sessionNumberAccount);

            queryString = new NameValueCollection { { "Id", "1" } };
            _queryStringMock.Setup(x => x.QueryString).Returns(queryString);

            _contextMock.Setup(x => x.Request).Returns(_queryStringMock.Object);

            Label errorLabelMessage = new Label();
            _mock.Setup(x => x.ErrorLabelMessage).Returns(errorLabelMessage);

            contract = _mock.Object;

            _detailInvoicePresenter = new DetailInvoicePresenter(contract);

            _detailInvoicePresenter.GetDetailInvoice();

            Assert.AreEqual(0, contract.DetailInvoiceTable.Rows.Count);
            Assert.AreEqual(true, contract.ErrorLabel.Visible);
            Assert.AreEqual(true, contract.SuccessLabel.Visible);
            Assert.AreEqual("1", contract.SessionRestaurant);

        }

        [Test(Description = "Llena los campos del detalle de la factura")]
        public void PrintInvoiceTest()
        {
            Table detailInvoiceTable = new Table();
            _mock.Setup(x => x.DetailInvoiceTable).Returns(detailInvoiceTable);

            HtmlGenericControl successLabel = new HtmlGenericControl();
            _mock.Setup(x => x.SuccessLabel).Returns(successLabel);

            HtmlGenericControl errorLabel = new HtmlGenericControl();
            _mock.Setup(x => x.ErrorLabel).Returns(errorLabel);

            Label errorLabelMessage = new Label();
            _mock.Setup(x => x.ErrorLabelMessage).Returns(errorLabelMessage);

            string sessionId = "1";
            _mock.Setup(x => x.SessionRestaurant).Returns(sessionId);

            contract = _mock.Object;

            _detailInvoicePresenter = new DetailInvoicePresenter(contract);

            _detailInvoicePresenter.PrintInvoice();

            Assert.AreEqual(0, contract.DetailInvoiceTable.Rows.Count);
            Assert.AreEqual(true, contract.ErrorLabel.Visible);
            Assert.AreEqual(true, contract.SuccessLabel.Visible);
            Assert.AreEqual("1", contract.SessionRestaurant);
            Assert.IsNullOrEmpty(contract.UserLastName.Text);
            Assert.IsNullOrEmpty(contract.UserName.Text);
            Assert.IsNullOrEmpty(contract.TotalInvoice.Text);
            Assert.IsNullOrEmpty(contract.IvaInvoice.Text);

        }


    }
}
