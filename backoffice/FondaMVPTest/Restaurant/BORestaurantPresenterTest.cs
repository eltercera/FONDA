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
        //Variables para el test
        private MockRepository _MockRepository;
        private Mock<IRestaurantModel> _mock;
        private IRestaurantModel contract;
        private RestaurantPresenter _restaurantPresenter;
        private bool valid;

        /// <summary>
        /// Metodo que inicializa mock y las variables que se necesitan para empezar el test
        /// Mock = contrato entre la vista y el presentador
        /// </summary>
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

        /// <summary>
        /// Metodo para generar el label de error al generar
        /// un restaurante
        /// </summary>
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

        /// <summary>
        /// Metodo que generar el label de exito cuando se genera
        /// correctamente un restaurante
        /// </summary>
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

        /// <summary>
        /// Metodo para cargar los restaurantes que se encuentran
        /// en la bd, comprueba que existan elementos.
        /// </summary>
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

        /// <summary>
        /// Metodo que valida que los atributos del restaurante a generar
        /// se encuentren en el patron definido
        /// Tiene un detalle con los dias "checkados
        /// </summary>
        [Test(Description = "Valida los campos del restaurante insertado")]
        public void ValidRestaurantTest()
        {
            Table restaurantTable = new Table();
            _mock.Setup(x => x.restaurantTable).Returns(restaurantTable);
            contract = _mock.Object;
            contract.day1Add.Checked = false;
            contract.day2Add.Checked = true;
            contract.day3Add.Checked = true;
            contract.day4Add.Checked = true;
            contract.day5Add.Checked = true;
            contract.day6Add.Checked = true;
            contract.day7Add.Checked = false;

            _restaurantPresenter = new RestaurantPresenter(contract);
            valid = _restaurantPresenter.ValidarRestaurant("El Tinajero", "China", "V","135584","Dolar",
                "Las mercedes", "Montalban", "10.20", "25.3", "12:00:00", "5:00:00");

            Assert.AreEqual(true, valid);
        }

        [Test]
        public void ButtonAddClickTest()
        {
            Table restaurantTable = new Table();
            _mock.Setup(x => x.restaurantTable).Returns(restaurantTable);
            contract = _mock.Object;
            contract.nameAdd.Text= "Sanduchef";
            //contract.imageAdd.PostedFile = "C:/";
            contract.categoryAdd.Text = "China";
            contract.nationalityAdd.Text = "V";
            contract.rifAdd.Text = "22587";
            contract.addressAdd.Text = "5ta trasversal";
            contract.currencyAdd.Text = "Bolivar Fuerte";
            contract.zoneAdd.Text = "La Castellana";
            contract.longAdd.Text = "14.5";
            contract.latAdd.Text = "174.2";
            contract.openingTimeAdd.Text = "1:00:00";
            contract.closingTimeAdd.Text = "5:00:00";
            contract.day1Add.Checked = false;
            contract.day2Add.Checked = true;
            contract.day3Add.Checked = true;
            contract.day4Add.Checked = true;
            contract.day5Add.Checked = true;
            contract.day6Add.Checked = true;
            contract.day7Add.Checked = false;


            _restaurantPresenter = new RestaurantPresenter(contract);
            _restaurantPresenter.ButtonAdd_Click();

            Assert.AreEqual(true, contract.alertSuccessAdd.Visible);
        }

        [Test]
        public void FillDropDownTest()
        {
            Table restaurantTable = new Table();
            _mock.Setup(x => x.restaurantTable).Returns(restaurantTable);
            contract = _mock.Object;

            _restaurantPresenter = new RestaurantPresenter(contract);
            _restaurantPresenter.FillDropdown();

            Assert.NotNull(contract.categoryAdd.Items);
        }
                

    }
}
