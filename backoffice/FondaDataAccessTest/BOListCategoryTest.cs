using NUnit.Framework;
using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System.Collections.Generic;

namespace FondaDataAccessTest
{
    [TestFixture]
    public class BOListCategoryTest
    {
        private FactoryDAO _facDAO = FactoryDAO.Intance;
        private IMenuCategoryDAO _mencatDAO;
        private IList <MenuCategory> _listmencat= new List <MenuCategory>();
        int longitud;

        [Test]
        public void DishChangeTest()
        {
            _mencatDAO = _facDAO.GetMenuCategoryDAO();
            _listmencat = _mencatDAO.GetAll();
           longitud=_listmencat.Count;
            ListCategoryAssertions();
        }

        private void ListCategoryAssertions()
        {

            Assert.NotNull(_listmencat);
            Assert.AreEqual(longitud,3);

        }
    }
}
