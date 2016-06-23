using BackOffice.Seccion.Caja;
using com.ds201625.fonda.View.BackOfficeModel.OrderAccount;
using com.ds201625.fonda.View.BackOfficePresenter.OrderAccount;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace FondaMVPTest
{
    [TestFixture()]
    public class BOOrdersPresenterTest
    {
        private MockRepository _MockRepository;
        private Mock<IOrdersContract> _mock;
        private IOrdersContract contract;
        private OrdersPresenter _ordersPresenter;

        [SetUp]
        public void Init()
        {
            _MockRepository = new MockRepository(MockBehavior.Loose);
            _mock = _MockRepository.Create<IOrdersContract>();
            
        }

        [Test(Description = "Muestra el label con el mensaje de error")]
        public void ErrorLabelTest()
        {
            Label errorLabelMessage = new Label();
            _mock.Setup(x => x.ErrorLabelMessage).Returns(errorLabelMessage);

            HtmlGenericControl errorLabel = new HtmlGenericControl();
            _mock.Setup(x => x.ErrorLabel).Returns(errorLabel);

            contract = _mock.Object;

            _ordersPresenter = new OrdersPresenter(contract);

            _ordersPresenter.ErrorLabel("Ha ocurrido un error");

            Assert.AreEqual(true,_mock.Object.ErrorLabel.Visible);
            Assert.AreEqual("Ha ocurrido un error", _mock.Object.ErrorLabelMessage.Text);
        }

        [Test(Description = "Muestra el label con el mensaje de exito")]
        public void SuccessLabelTest()
        {
            Label successLabelMessage = new Label();
            _mock.Setup(x => x.SuccessLabelMessage).Returns(successLabelMessage);

            HtmlGenericControl successLabel = new HtmlGenericControl();
            _mock.Setup(x => x.SuccessLabel).Returns(successLabel);

            contract = _mock.Object;

            _ordersPresenter = new OrdersPresenter(contract);

            _ordersPresenter.SuccessLabel("Operacion exitosa");

            Assert.AreEqual(true, _mock.Object.SuccessLabel.Visible);
            Assert.AreEqual("Operacion exitosa", _mock.Object.SuccessLabelMessage.Text);
        }

        [Test(Description ="Oculta los campos para mostrar mensajes de error o de exito")]
        public void HideMessageLabelTest()
        {
            HtmlGenericControl successLabel = new HtmlGenericControl();
            _mock.Setup(x => x.SuccessLabel).Returns(successLabel);

            HtmlGenericControl errorLabel = new HtmlGenericControl();
            _mock.Setup(x => x.ErrorLabel).Returns(errorLabel);

            contract = _mock.Object;

            _ordersPresenter = new OrdersPresenter(contract);

            _ordersPresenter.HideMessageLabel();

            Assert.AreEqual(false, _mock.Object.ErrorLabel.Visible);
            Assert.AreEqual(false, _mock.Object.SuccessLabel.Visible);
        }

        [Test(Description = "Oculta los campos para mostrar mensajes de error o de exito")]
        public void GenerateTableHeader()
        {
            HtmlGenericControl successLabel = new HtmlGenericControl();
            _mock.Setup(x => x.SuccessLabel).Returns(successLabel);

            HtmlGenericControl errorLabel = new HtmlGenericControl();
            _mock.Setup(x => x.ErrorLabel).Returns(errorLabel);

            contract = _mock.Object;

            _ordersPresenter = new OrdersPresenter(contract);

            _ordersPresenter.HideMessageLabel();

            Assert.AreEqual(false, _mock.Object.ErrorLabel.Visible);
            Assert.AreEqual(false, _mock.Object.SuccessLabel.Visible);
        }


    }
}
