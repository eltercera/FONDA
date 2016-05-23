using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Tests.DataAccess
{
    [TestFixture]
    public class BOGeopositionTableTest
    {
        private FactoryDAO factoryDAO;
        private ITableDAO _tableDAO;
        private IReservationDAO _reservationDAO;
        private IRestaurantDAO _restaurantDAO;

        [Test]
        public void TableAvailableTest()
        {
            bool validHour = false;
            bool validDay = false;
            factoryDAO = FactoryDAO.Intance;
            _tableDAO = factoryDAO.GetTableDAO();
            _restaurantDAO = factoryDAO.GetRestaurantDAO();
            _reservationDAO = factoryDAO.GetReservationDAO();
            IList<Reservation> reservations = new List<Reservation>();
            IList<Table> tables = new List<Table>();
            IList<Table> tablesAvalibles = new List<Table>();
            Restaurant _restaurant = new Restaurant();
            _restaurant = _restaurantDAO.FindById(1);
            
            Reservation _reservation = new Reservation();
            _reservation.ReserveRestaurant = _restaurant;
            _reservation.ReserveDate = new DateTime(2016, 09, 29, 13, 30, 00);
            _reservation.CreateDate = new DateTime(2016, 09, 15, 14, 30, 00);
            _reservation.CommensalNumber = 3;
            _reservation.ReserveStatus = factoryDAO.GetActiveReservationStatus();

            validHour =_restaurantDAO.ValidateHour(1, _reservation.ReserveDate);

            validDay = _restaurantDAO.ValidateDay(3, _reservation.ReserveDate);
               
                    reservations = _reservationDAO.FindByRestaurant(_restaurant.Id);
                    tables = _tableDAO.TablesAvailableByDate(3, reservations, _reservation.ReserveDate);
                    tablesAvalibles = _tableDAO.TablesAvailableByCapacity(tables, _reservation.CommensalNumber);
            
        }

        [Test]
        public void GeopositionTest() {
            factoryDAO = FactoryDAO.Intance;
            _restaurantDAO = factoryDAO.GetRestaurantDAO();
            double latitud = 10.492104;
            double longitud = -66.814397;
            bool ok = false;
            ok = _restaurantDAO.Geoposition(latitud,longitud,1);

        }

    }
}
