using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessTests
{
    [TestFixture]
    public class BOTableTest
    {
        private com.ds201625.fonda.DataAccess.FactoryDAO.FactoryDAO _facDAO;
        private ITableDAO _tableDAO;
        private Table _table;
        private int _tableId;
        private IRestaurantDAO _restaurantDAO;


        [Test]
        public void TableTest()
        {
            generateTable();
            tableAssertions();

        }

        [Test]
        public void TableSave()
        {
            getTableDao();
            generateTable();

            _tableDAO.Save(_table);

            Assert.AreNotEqual(_table.Id, 0);
            _tableId = _table.Id;

            generateTable(true);

            _tableDAO.Save(_table);

            _tableDAO.ResetSession();

            _table = null;


        }

        private void getTableDao()
        {
            getDao();
            if (_tableDAO == null)
                _tableDAO = _facDAO.GetTableDAO();

        }

        private void getDao()
        {
            if (_facDAO == null)
                _facDAO = com.ds201625.fonda.DataAccess.FactoryDAO.FactoryDAO.Intance;
        }


        private void generateTable(bool edit = false)
        {
            if (_table != null)
                return;

            if ((edit & _table == null) | _table == null)
                _table = new Table();

            FactoryDAO factoryDAO = FactoryDAO.Intance;
            IRestaurantDAO _restaurantDAO = factoryDAO.GetRestaurantDAO();
            com.ds201625.fonda.Domain.Restaurant _restaurant = _restaurantDAO.FindById(1);
            _restaurantDAO.FindById(1);

            _table.Capacity = 2;
            //FreeTableStatus :(
            _table.Restaurant = _restaurant;
            _table.Status = _facDAO.GetFreeTableStatus();

        }


        private void tableAssertions(bool edit = false)
        {
            Assert.IsNotNull(_table);
            Assert.AreEqual(_table.Capacity, 2);
            //FreeTableStatus :(
            //Assert.AreEqual(_table.Status, FreeTableStatus.Instance);
        }

        [TestFixtureTearDown]
        public void EndTests()
        {

        }

    }
}
