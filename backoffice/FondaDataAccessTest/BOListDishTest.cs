using NUnit.Framework;
using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System.Collections.Generic;

namespace FondaDataAccessTest
{
    [TestFixture]
    public class BOListDishTest
    {
        private FactoryDAO _facDAO = FactoryDAO.Intance;
        private IDishDAO _dishDAO;
        private IList<Dish> _listdish = new List<Dish>();
        int longitud;

        [Test]
        public void DishChangeTest()
        {
            _dishDAO = _facDAO.GetDishDAO();
            _listdish = _dishDAO.GetAll();
            longitud = _listdish.Count;
            ListDishAssertions();
        }

        private void ListDishAssertions()
        {

            Assert.NotNull(_listdish);
            Assert.AreEqual(longitud, 16);

        }
    }
 }

     
