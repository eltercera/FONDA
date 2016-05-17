using NUnit.Framework;
using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;

namespace FondaDataAccessTest
{
    /*


    [TestFixture]

    class BOMenuCategoryTest
    {
        private FactoryDAO _facDAO;
        private IMenuCategoryDAO _mencatDAO;
        private MenuCategory _mencat;
        private int _mencatId;
        private IDishDAO _dishDAO;
        

        /// <summary>
        /// Prueba de Dominio.
        /// crea una categoria de menu.
        /// </summary>
        [Test]
        public void MenuCategoryTest()
        {
            generateMenuCategory();
            MenuCategoryAssertions();

        }

        [Test]
        public void MenuCategorySave()
        {
            getMenuCategoryDao();
            generateMenuCategory();

            _mencatDAO.Save(_mencat);

            Assert.AreNotEqual(_mencat.Id, 0);
            _mencatId = _mencat.Id;

            generateMenuCategory(true);

            _mencatDAO.Save(_mencat);

            _mencatDAO.ResetSession();

            _mencat = null;


        }



        private void getMenuCategoryDao()
        {
            getDao();
            if (_mencatDAO == null)
            {
                _mencatDAO = _facDAO.GetMenuCategoryDAO();
            }

        }

        private void getDao()
        {
            if (_facDAO == null)
                _facDAO = FactoryDAO.Intance;
        }



        private void generateMenuCategory(bool edit = false)
        {
            if (_mencat != null)
                return;

            if ((edit & _mencat == null) | _mencat == null)
                _mencat = new MenuCategory();

            _dishDAO = _facDAO.GetDishDAO();
            Dish plato = _dishDAO.FindById(1);
            Dish plato2 = _dishDAO.FindById(2);
            _mencat.Name = "pastas";
            _mencat.ListDish.Add(plato);
            _mencat.ListDish.Add(plato2);
            _mencat.Status = ActiveSimpleStatus.Instance;





        }



        private void MenuCategoryAssertions(bool edit = false)
        {

            Assert.IsNotNull(_mencat);
            Assert.AreEqual(_mencat.Name, "pastas");
            Assert.IsNotNull(_mencat.ListDish);
            Assert.AreEqual(_mencat.Status, ActiveSimpleStatus.Instance);
            //Assert.AreEqual(_mencat.RecordStatus, null);

        }

    }
     
    */
}

