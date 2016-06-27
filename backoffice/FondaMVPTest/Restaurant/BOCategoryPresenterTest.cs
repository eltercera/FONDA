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
        //Variables para el test
        private MockRepository _MockRepository;
        private Mock<ICategoryModel> _mock;
        private ICategoryModel contract;
        private CategoryPresenter _categoryPresenter;
        private bool valid;

        /// <summary>
        /// Metodo que inicializa mock y las variables que se necesitan 
        /// para empezar el test
        /// Mock = contrato entre la vista y el presentador
        /// </summary>
        [SetUp]
        public void init()
        {
            _MockRepository = new MockRepository(MockBehavior.Loose);
            _mock = _MockRepository.Create<ICategoryModel>();
            valid = false;
        }

        /// <summary>
        /// Metodo para limpiar las variables una vez el test
        /// haya culminado
        /// </summary>
        [TearDown]
        public void clean()
        {
            _MockRepository = null;
            valid = false;
        }


        /// <summary>
        /// Metodo para cargar los restaurantes que se encuentran
        /// en la bd, comprueba que existan elementos.
        /// </summary>
        [Test(Description = "Indica que la tabla de categorias se llenó correctamente")]
        public void SuccessLoadCategoryTableTest()
        {
            Table categoryTable = new Table();
            _mock.Setup(x => x.categoryRest).Returns(categoryTable);
            contract = _mock.Object;

            _categoryPresenter = new CategoryPresenter(contract);
            _categoryPresenter.LoadTable();

            Assert.AreEqual(5, contract.categoryRest.Rows.Count);
        }

        /// <summary>
        /// Metodo que valida que el nombre de la categoria se encuentre
        /// en el patron alfabetico definido
        /// </summary>
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
