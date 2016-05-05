using NUnit.Framework;
using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;

namespace com.ds201625.fonda.Tests.DataAccess
{
    /*
    [TestFixture()]
    class BODishOrderTest
    {

        private FactoryDAO _facDAO;

        private IDishOrderDAO _orderDAO;
        private DishOrder _dishOrder;
        private int _dishOrderID;

        /// <summary>
        /// Prueba de Dominio.
        /// crea a una orden, luego verifica
        /// estan correctamente asignados.
        /// </summary>
		[Test()]
        public void PersonDomainTerst()
        {
            generateDishOrder();
            dishOrderAssertions();
        }

        private void generateDishOrder(bool edit = false)
        {
            if (_dishOrder != null & !edit)
                return;

            if ((edit & _dishOrder == null) | _dishOrder == null)
                _dishOrder = new DishOrder();

            string editadd = "";

            if (edit)
                editadd = "Editado";

            _dishOrder.Dish = new Dish();
            _dishOrder.Dish.Cost = 500;
            _dishOrder.Dish.Name = "Pasta Marinera"+editadd;
            _dishOrder.Count = 5;

        }

        private void dishOrderAssertions(bool edit = false)
        {
            string editadd = "";
            if (edit)
                editadd = "Editado";

            Assert.IsNotNull( _dishOrder );
            Assert.AreEqual( _dishOrder.Count, 5 );
            Assert.AreEqual( _dishOrder.Dish.Name, "Pasta Marinera" + editadd);
            Assert.AreEqual( _dishOrder.Dish.Cost, 500 );
        }

        private void getdishOrderDao()
        {
            getDao();
            if (_orderDAO == null)
                _orderDAO = _facDAO.GetOrderAccountDAO();

        }

        private void getDao()
        {
            if (_facDAO == null)
                _facDAO = FactoryDAO.Intance;
        }

        [TestFixtureTearDown]
        public void EndTests()
        {
            if (_dishOrderID != 0)
            {
                getdishOrderDao();
                
            }
            _orderDAO.ResetSession();
        }*/
}
