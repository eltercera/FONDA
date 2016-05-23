using NUnit.Framework;
using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;

namespace FondaDataAccessTest
{
    [TestFixture]
    public class BOChangeDishTest
    {
        private FactoryDAO _facDAO= FactoryDAO.Intance;
        private IDishDAO _dishDAO;
        private Dish _dish;
        bool cambio=false;
        int id = 1;

        [Test]
        public void DishChangeTest()
        {

            _dishDAO =_facDAO.GetDishDAO();
            _dish =_dishDAO.FindById(id);
            DishChange();

            _dishDAO.Save(_dish);

            dishAssertions();

        }

        private void selectdish(int id) { 
            

        }

        private void DishChange()
        {
            _dish.Name = "prueba";
            _dish.Cost = 1000;
            cambio = true;

        }

         private void dishAssertions(){

             Assert.AreEqual(_dishDAO.FindById(1).Name, "prueba");
             Assert.AreEqual(_dishDAO.FindById(1).Cost, 1000);
             Assert.IsTrue(cambio);
         
         }



    }
}
