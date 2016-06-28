using com.ds201625.fonda.View.BackOfficeModel.Restaurant;
using com.ds201625.fonda.View.BackOfficePresenter.Restaurante;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace FondaMVPTest.Restaurant
{
    public class BOCategoryPresenterTest
    {

        private MockRepository _MockRepository;
        private Mock<ICategoryModel> _mock;
        private ICategoryModel contract;
        private CategoryPresenter _categoryPresenter;
        private bool valid;

        [SetUp]
        public void init()
        {
            _MockRepository = new MockRepository(MockBehavior.Loose);
            _mock = _MockRepository.Create<ICategoryModel>();
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

            _categoryPresenter = new CategoryPresenter(contract);

            _categoryPresenter.ErrorLabel("Ha ocurrido un error");

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

            _categoryPresenter = new CategoryPresenter(contract);

            _categoryPresenter.SuccessLabel("Operacion exitosa");

            Assert.AreEqual(true, _mock.Object.SuccessLabel.Visible);
            Assert.AreEqual("Operacion exitosa", _mock.Object.SuccessLabelMessage.Text);
        }

        [Test(Description = "Indica que la tabla de restaurantes se llenó correctamente")]
        public void SuccessLoadCategoryTableTest()
        {
            Table categoryTable = new Table();
            _mock.Setup(x => x.categoryRest).Returns(categoryTable);
            contract = _mock.Object;

            _categoryPresenter = new CategoryPresenter(contract);
            _categoryPresenter.LoadTable();

            Assert.AreEqual(5, contract.categoryRest.Rows.Count);
        }

        [Test]
        public void CategoryValidateTest()
        {
            Table restaurantTable = new Table();
            _mock.Setup(x => x.categoryRest).Returns(restaurantTable);
            contract = _mock.Object;

            _categoryPresenter = new CategoryPresenter(contract);
            bool valid = _categoryPresenter.CategoryValidate("Aruba");

            Assert.AreEqual(true, valid);
        }

    }
}
