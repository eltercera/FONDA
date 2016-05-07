using NUnit.Framework;
using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;

namespace DataAccess
{

    [TestFixture]

    public class BODishTest
    {
        private FactoryDAO _facDAO;
        private IDishDAO _dishDAO;
        private Dish _dish;
        private int _dishId;

        /// <summary>
        /// Prueba de Dominio.
        /// crea un plato.
        /// </summary>
        [Test]
        [Ignore]
        public void DishTest()
        {
            generateDish();
            dishAssertions();

        }

        [Test]
        [Ignore]
        public void DishSave()
        {
            getDishDao();
            generateDish();

              _dishDAO.Save(_dish);

            Assert.AreNotEqual(_dish.Id, 0);
            _dishId = _dish.Id;

            generateDish(true);

            _dishDAO.Save(_dish);

            _dishDAO.ResetSession();

            _dish = null;


        }

        private void getDishDao()
        {
            getDao();
            if (_dishDAO == null)
                _dishDAO = _facDAO.GetDishDAO();

        }

        private void getDao()
        {
            if (_facDAO == null)
                _facDAO = FactoryDAO.Intance;
        }



        private void generateDish(bool edit = false)
        {
            if (_dish != null)
                return;

            if ((edit & _dish == null) | _dish == null)
                _dish = new Dish();

            _dish.Name = "Pasta";
            _dish.Description = "con carne";
            _dish.Cost = 195;
            _dish.Image = null;
            _dish.Suggestion = true;
            _dish.Status = ActiveSimpleStatus.Instance;

        }



        private void dishAssertions(bool edit = false)
        {

            Assert.IsNotNull(_dish);
            Assert.AreEqual(_dish.Name, "Pasta");
            Assert.AreEqual(_dish.Description, "con carne");
            Assert.AreEqual(_dish.Cost, 195);
            Assert.AreEqual(_dish.Image, null);
            Assert.AreEqual(_dish.Status, ActiveSimpleStatus.Instance);
            Assert.AreEqual(_dish.Suggestion, true);
        }

    }
}
