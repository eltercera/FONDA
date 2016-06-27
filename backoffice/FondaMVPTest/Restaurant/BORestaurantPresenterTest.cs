using com.ds201625.fonda.View.BackOfficeModel.Restaurant;
using com.ds201625.fonda.View.BackOfficePresenter.Restaurante;
using Moq;
using NUnit.Framework;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace FondaMVPTest.Restaurante
{
    public class BORestaurantPresenterTest
    {
        private MockRepository _MockRepository;
        private Mock<IRestaurantModel> _mock;
        private IRestaurantModel contract;
        private RestaurantPresenter _restaurantPresenter;
        private bool valid;

        [SetUp]
        public void init()
        {
            _MockRepository = new MockRepository(MockBehavior.Loose);
            _mock = _MockRepository.Create<IRestaurantModel>();
            valid = false;
        }

        [TearDown]
        public void clean()
        {
            _MockRepository = null;
            valid = false;
        }

        [Test(Description = "Muestra el label con el mensaje de error")]
        public void ErrorLabelTest()
        {
            Label errorLabelMessage = new Label();
            _mock.Setup(x => x.ErrorLabelMessage).Returns(errorLabelMessage);

            HtmlGenericControl errorLabel = new HtmlGenericControl();
            _mock.Setup(x => x.ErrorLabel).Returns(errorLabel);

            contract = _mock.Object;

            _restaurantPresenter = new RestaurantPresenter(contract);

            _restaurantPresenter.ErrorLabel("Ha ocurrido un error");

            Assert.AreEqual(true, _mock.Object.ErrorLabel.Visible);
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

            _restaurantPresenter = new RestaurantPresenter(contract);

            _restaurantPresenter.SuccessLabel("Operacion exitosa");

            Assert.AreEqual(true, _mock.Object.SuccessLabel.Visible);
            Assert.AreEqual("Operacion exitosa", _mock.Object.SuccessLabelMessage.Text);
        }

        [Test(Description = "Indica que la tabla de restaurantes se llenó correctamente")]
        public void SuccessLoadRestaurantTableTest()
        {
            Table restaurantTable = new Table();
            _mock.Setup(x => x.restaurantTable).Returns(restaurantTable);
            contract = _mock.Object;

            _restaurantPresenter = new RestaurantPresenter(contract);
            _restaurantPresenter.LoadTable();

            Assert.AreEqual(5, contract.restaurantTable.Rows.Count);
        }

        [Test(Description = "Valida los campos del restaurante insertado (DETALLE CON DIAS CHECKADOS)")]
        public void ValidRestaurantTest()
        {
            Table restaurantTable = new Table();
            _mock.Setup(x => x.restaurantTable).Returns(restaurantTable);
            contract = _mock.Object;

            _restaurantPresenter = new RestaurantPresenter(contract);
            valid = _restaurantPresenter.ValidarRestaurant("El Tinajero", "China", "V","135584","Dolar",
                "Las mercedes", "Montalban", "10.20", "25.3", "12:00:00", "5:00:00");

            Assert.AreEqual(true, valid);
        }

        /*[Test]
        public void ButtonAddClickTest()
        {
            Table restaurantTable = new Table();
            _mock.Setup(x => x.restaurantTable).Returns(restaurantTable);
            contract = _mock.Object;

            _restaurantPresenter = new RestaurantPresenter(contract);
            _restaurantPresenter.ButtonAdd_Click();

            Assert.AreEqual(true, contract.alertSuccessAdd.Visible);
        }*/


    }
}
