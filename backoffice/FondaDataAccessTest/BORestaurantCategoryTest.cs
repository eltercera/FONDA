using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using NUnit.Framework;


namespace FondaDataAccessTest
{
    [TestFixture]
    public class BORestaurantCategoryTest
    {
        private FactoryDAO _facDAO;
        private IRestaurantCategoryDAO _restaurantCategoryDAO;
        private RestaurantCategory _restaurantCategory;
        private RestaurantCategory _result;

        [SetUp]
        public void Init()
        {
            if (_facDAO == null)
                _facDAO = FactoryDAO.Intance;

            _restaurantCategoryDAO = _facDAO.GetRestaurantCategoryDAO();

            _restaurantCategory = new RestaurantCategory();
            _restaurantCategory.Name = "Mexicana";
        }

        [Test(Description ="Prueba si trae un mismo objeto de la Base de Datos a partir del nombre")]
        [Ignore]
        public void SameRestaurantCategory()
        {
            string name = _restaurantCategory.Name;
            _result = _restaurantCategoryDAO.GetRestaurantCategory(name);

            Assert.IsNotNull(_result);
            Assert.AreEqual(1, _result.Id);

        }

        [Test(Description ="Salva un objeto en la Base de Datos")]
        public void RestaurantCategorySave()
        {
            _result = _restaurantCategoryDAO.GetRestaurantCategory(_restaurantCategory.Name);
            _restaurantCategoryDAO.Save(_result);

            Assert.IsNotNull(_result);
            Assert.AreEqual(1, _result.Id);
            Assert.AreEqual("Mexicana", _result.Name);

        }

        [Test(Description = "Actualiza un objeto Currency de la Base de Datos")]
        [Ignore]
        public void RestaurantCategoryUpdate()
        {
            _restaurantCategory = _restaurantCategoryDAO.GetRestaurantCategory(_restaurantCategory.Name);
            _restaurantCategory.Name = "China";
            _restaurantCategoryDAO.Save(_restaurantCategory);
            _result = _restaurantCategoryDAO.GetRestaurantCategory(_restaurantCategory.Name);

            Assert.IsNotNull(_result);
            Assert.AreEqual(1, _result.Id);
            Assert.AreEqual("China", _result.Name);
        }

        [Test(Description ="Elimina un objeto Currency de la Base de Datos")]
        [Ignore]
        public void CurrencyDelete()
        {
            _restaurantCategory = _restaurantCategoryDAO.GetRestaurantCategory(_restaurantCategory.Name);
            _restaurantCategoryDAO.Delete(_restaurantCategory);
            _result = _restaurantCategoryDAO.GetRestaurantCategory(_restaurantCategory.Name);

            Assert.IsNull(_result);
        }

        [TestFixtureTearDown]
        public void EndTests()
        {

        }

    }
}
