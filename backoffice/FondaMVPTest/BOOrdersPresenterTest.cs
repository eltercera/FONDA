using BackOffice.Seccion.Caja;
using com.ds201625.fonda.Resources.FondaResources.OrderAccount;
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

        [Test(Description = "Caso de error, cuando la tabla de ordenes no tiene un Id de Restaurante")]
        public void ErrorGetOrdersTest()
        {
            Table orderTable = new Table();
            _mock.Setup(x => x.OrdersTable).Returns(orderTable);

            HtmlGenericControl errorLabel = new HtmlGenericControl();
            _mock.Setup(x => x.ErrorLabel).Returns(errorLabel);

            Label errorLabelMessage = new Label();
            _mock.Setup(x => x.ErrorLabelMessage).Returns(errorLabelMessage);

            contract = _mock.Object;

            _ordersPresenter = new OrdersPresenter(contract);

            _ordersPresenter.GetOrders();

            Assert.AreEqual(0, contract.OrdersTable.Rows.Count);
            Assert.AreEqual(true, contract.ErrorLabel.Visible);

        }

        [Test(Description = "Carga la tabla con la ordenes abiertas de un Restaurante")]
        public void GetOrdersTest()
        {
            Table orderTable = new Table();
            _mock.Setup(x => x.OrdersTable).Returns(orderTable);

            HtmlGenericControl successLabel = new HtmlGenericControl();
            _mock.Setup(x => x.SuccessLabel).Returns(successLabel);

            HtmlGenericControl errorLabel = new HtmlGenericControl();
            _mock.Setup(x => x.ErrorLabel).Returns(errorLabel);

            string sessionId = "1";
            _mock.Setup(x => x.SessionRestaurant).Returns(sessionId);

            Label errorLabelMessage = new Label();
            _mock.Setup(x => x.ErrorLabelMessage).Returns(errorLabelMessage);

            contract = _mock.Object;

            _ordersPresenter = new OrdersPresenter(contract);

            _ordersPresenter.GetOrders();

            Assert.AreEqual(3, contract.OrdersTable.Rows.Count);
            Assert.AreEqual(false, contract.ErrorLabel.Visible);
            Assert.AreEqual(false, contract.SuccessLabel.Visible);
            Assert.AreEqual("1", contract.SessionRestaurant);

        }

        [Test(Description = "Caso de error, metodo para cerrar la caja de un Restaurante")]
        public void ErrorCloseTest()
        {

            HtmlGenericControl errorLabel = new HtmlGenericControl();
            _mock.Setup(x => x.ErrorLabel).Returns(errorLabel);

            string sessionId = "1";
            _mock.Setup(x => x.SessionRestaurant).Returns(sessionId);

            Label errorLabelMessage = new Label();
            _mock.Setup(x => x.ErrorLabelMessage).Returns(errorLabelMessage);

            contract = _mock.Object;

            _ordersPresenter = new OrdersPresenter(contract);

            _ordersPresenter.Close();


            Assert.AreEqual(true, contract.ErrorLabel.Visible);
            Assert.AreEqual(OrderAccountResources.MessageMVPExceptionOrdersTable, contract.ErrorLabelMessage.Text);
            Assert.AreEqual("1", contract.SessionRestaurant);

        }

        [Test(Description = "Metodo para cerrar la caja de un Restaurante")]
        public void CloseTest()
        {

            HtmlGenericControl errorLabel = new HtmlGenericControl();
            _mock.Setup(x => x.ErrorLabel).Returns(errorLabel);

            string sessionId = "2";
            _mock.Setup(x => x.SessionRestaurant).Returns(sessionId);

            Label errorLabelMessage = new Label();
            _mock.Setup(x => x.ErrorLabelMessage).Returns(errorLabelMessage);

            contract = _mock.Object;

            _ordersPresenter = new OrdersPresenter(contract);

            _ordersPresenter.Close();


            Assert.AreEqual(true, contract.ErrorLabel.Visible);
            Assert.AreEqual(OrderAccountResources.MessageMVPExceptionOrdersTable, contract.ErrorLabelMessage.Text);

        }


    }
}
