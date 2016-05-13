using NUnit.Framework;
using System;
using Moq;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;

namespace DataAccess
{

    [TestFixture()]
    public class BODishOrderTest
    {

        private FactoryDAO _facDAO;
        private IDishOrderDAO _orderDAO;
        private DishOrder _dishOrder;
        private int _dishOrderID;

        /// <summary>
        /// Prueba de Dominio.
        /// crea a una orden, luego verifica
        /// si esta correctamente creada.
        /// </summary>
		[Test()]
        public void DishOrderTerst()
        {
            generateDishOrder();
            dishOrderAssertions();
        }

        [Test()]
        public void DishOrderSave()
        {
            // Se vuelve a generar una orden
            getdishOrderDao();
            generateDishOrder();

            // La guardo
            _orderDAO.Save(_dishOrder);

            // revision del ID de la DB
            Assert.AreNotEqual(_dishOrder.Id, 0);
            _dishOrderID = _dishOrder.Id;

            // Editar la orden
            generateDishOrder(true);

            // guardar la orden
            _orderDAO.Save(_dishOrder);

            // Reiniciar y borrar la orden de memoria
            _orderDAO.ResetSession();
            _dishOrder = null;

            // Buscar la orden creada en la DB
            _dishOrder = _orderDAO.FindById(_dishOrderID);

            // Verificar los cambios
            dishOrderAssertions();

        }

        private void generateDishOrder(bool edit = false)
        {
            if (_dishOrder != null & !edit)
                return;

            if ((edit & _dishOrder == null) | _dishOrder == null)
                _dishOrder = new DishOrder();
            
            Mock<Dish> chk = new Mock<Dish>();
            Dish dish = chk.Object;
            _dishOrder.Dish = dish;
            _dishOrder.Count = 5;

        }

        private void dishOrderAssertions()
        {
            Assert.IsNotNull(_dishOrder);
            Assert.AreEqual(_dishOrder.Count, 5);
        }

        private void getdishOrderDao()
        {
            getDao();
            if (_orderDAO == null)
                _orderDAO = _facDAO.GetDishOrderDAO();

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
                // Eliminacion de la Persona al finalidar todo.
                _orderDAO.Delete(_dishOrder);

            }
            _orderDAO.ResetSession();
        }
    }
}
