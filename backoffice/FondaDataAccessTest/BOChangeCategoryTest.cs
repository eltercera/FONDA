using NUnit.Framework;
using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;

namespace FondaDataAccessTest
{
    [TestFixture]
    public class BOChangeCategoryTest
    {
        private FactoryDAO _facDAO = FactoryDAO.Intance;
        private IMenuCategoryDAO _mencatDAO;
        private MenuCategory _mencat;
        bool cambio = false;
        int id = 1;

        [Test]
        public void DishChangeTest()
        {

            _mencatDAO = _facDAO.GetMenuCategoryDAO();
            _mencat = _mencatDAO.FindById(id);
            CategoryChange();

            _mencatDAO.Save(_mencat);

            ChangeCategoryAssertions();

        }

        private void CategoryChange()
        {
            _mencat.Name = "prueba";
            cambio = true;

        }

        private void ChangeCategoryAssertions()
        {

            Assert.AreEqual(_mencatDAO.FindById(1).Name, "prueba");
            Assert.IsTrue(cambio);

        }


    }
}
