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
        private int _restaurantCategoryId;


        [Test]
        public void RestaurantCategoryTest()
        {
            generateRestaurantCategory();
            RestaurantCategoryAssertions();
        }

        private void generateRestaurantCategory(bool edit = false)
        {
            if (_restaurantCategory != null)
                return;

            if ((edit & _restaurantCategory == null) | _restaurantCategory == null)
                _restaurantCategory = new RestaurantCategory();
             _restaurantCategory.Name = "China";
            // _restaurantCategory.Name = "Japonesa";
            //_restaurantCategory.Name = "Mexicana";
            //_restaurantCategory.Name = "Criolla";
            //_restaurantCategory.Name = "Chatarra";
        }

        private void RestaurantCategoryAssertions(bool edit = false)
        {
            Assert.IsNotNull(_restaurantCategory);
            Assert.AreEqual(_restaurantCategory.Name, "China");
        }

        [Test]
        public void TableSave()
        {
            generateRestaurantCategory();
            getRestaurantCategoryDAO();
            _restaurantCategoryDAO.Save(_restaurantCategory);
            Assert.AreNotEqual(_restaurantCategory.Id, 0);
            _restaurantCategoryId = _restaurantCategory.Id;
            generateRestaurantCategory(true);
            _restaurantCategoryDAO.Save(_restaurantCategory);
            _restaurantCategoryDAO.ResetSession();
            _restaurantCategory = null;
        }

        private void getRestaurantCategoryDAO()
        {
            getDao();
            if (_restaurantCategoryDAO == null)
                _restaurantCategoryDAO = _facDAO.GetRestaurantCategoryDAO();
        }

        private void getDao()
        {
            if (_facDAO == null)
                _facDAO = FactoryDAO.Intance;
        }

        [TestFixtureTearDown]
        public void EndTests()
        {

        }

    }
}
