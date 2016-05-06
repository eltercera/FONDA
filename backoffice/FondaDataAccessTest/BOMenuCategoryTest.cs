using NUnit.Framework;
using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;

namespace DataAccess
{



    [TestFixture]

    class BOMenuCategoryTest
    {
        private FactoryDAO _facDAO;
        private IMenuCategoryDAO _mencatDAO;
        private MenuCategory _mencat;
        private int _mencatId;

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
            _mencat.Name = "pastas";
            _mencat.ListDish = null;
            _mencat.Status = ActiveSimpleStatus.Instance;
            _mencat.RecordStatus = null;


        }



        private void MenuCategoryAssertions(bool edit = false)
        {

            Assert.IsNotNull(_mencat);
            Assert.AreEqual(_mencat.Name, "pastas");
            Assert.AreEqual(_mencat.ListDish, null);
            Assert.AreEqual(_mencat.Status, ActiveSimpleStatus.Instance);
            Assert.AreEqual(_mencat.RecordStatus, null);

        }

    }

}

