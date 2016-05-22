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
    public class BOReservationTest
    {
        private com.ds201625.fonda.DataAccess.FactoryDAO.FactoryDAO _facDAO;
        private IReservationDAO _reservationDAO;
        private Reservation _reservation;
        private int _reservationId;


        [Test]
        public void ReservationTest()
        {
            generateReservation();
            reservationAssertions();

        }

        [Test]
        public void ReservationSave()
        {
            getReservationDao();
            generateReservation();

            _reservationDAO.Save(_reservation);

            Assert.AreNotEqual(_reservation.Id, 0);
            _reservationId = _reservation.Id;

            generateReservation(true);

            _reservationDAO.Save(_reservation);

            _reservationDAO.ResetSession();

            _reservation = null;


        }

        private void getReservationDao()
        {
            getDao();
            if (_reservationDAO == null)
                _reservationDAO = _facDAO.GetReservationDAO();

        }

        private void getDao()
        {
            if (_facDAO == null)
                _facDAO = com.ds201625.fonda.DataAccess.FactoryDAO.FactoryDAO.Intance;
        }


        private void generateReservation(bool edit = false)
        {
            if (_reservation != null)
                return;

            if ((edit & _reservation == null) | _reservation == null)
                _reservation = new Reservation();

            _reservation.ReserveDate = new DateTime(2016,09,27,15,30,00);
            _reservation.CreateDate = new DateTime(2016, 09, 15, 14, 30, 00);
            _reservation.CommensalNumber = 3;
            _reservation.ReserveStatus = ActiveReservationStatus.Instance;

            //Restaurant _restaurant = new Restaurant();
            //_restaurant.Id = 1;
            //_restaurant.Name = "Tierra Mar";
            //_restaurant.Logo = "C:/";
            //_restaurant.Nationality = 'V';
            //_restaurant.Ssn = "123456";
            //_restaurant.Address = "Av. El ejercito con puente de San Juan";
            //_restaurant.Status = _facDAO.GetActiveSimpleStatus();
            //_reservation.ReserveRestaurant = _restaurant;
            

            //UserAccount _commensal = new UserAccount();
            //_commensal.SesionTokens = null;
            //_commensal.FavoritesRestaurants = null;
            //_commensal.Profiles = null;
            //_commensal.Id = 1;
            //_commensal.Email = "josefg19@gmail.com";
            //_commensal.Password = "12345";
            //_commensal.Status = ActiveSimpleStatus.Instance;
            //_reservation.ReserveUser = _commensal;

        }


        private void reservationAssertions(bool edit = false)
        {
            //UserAccount _commensal = new UserAccount();
            //_commensal.SesionTokens = null;
            //_commensal.FavoritesRestaurants = null;
            //_commensal.Profiles = null;
            //_commensal.Id = 1;
            //_commensal.Email = "josefg19@gmail.com";
            //_commensal.Password = "12345";
            //_commensal.Status = ActiveSimpleStatus.Instance;
            //_reservation.ReserveUser = _commensal;

            //Restaurant _restaurant = new Restaurant();
            //_restaurant.Id = 1;
            //_restaurant.Name = "Tierra Mar";
            //_restaurant.Logo = "C:/";
            //_restaurant.Nationality = 'V';
            //_restaurant.Ssn = "123456";
            //_restaurant.Address = "Av. El ejercito con puente de San Juan";
            //_restaurant.Status = _facDAO.GetActiveSimpleStatus();
            //_reservation.ReserveRestaurant = _restaurant;

            Assert.IsNotNull(_reservation);
            Assert.AreEqual(_reservation.ReserveDate, new DateTime(2016, 09, 27, 15, 30, 00));
            Assert.AreEqual(_reservation.CreateDate, new DateTime(2016, 09, 15, 14, 30, 00));
            Assert.AreEqual(_reservation.CommensalNumber, 3);
            Assert.AreEqual(_reservation.ReserveStatus, ActiveReservationStatus.Instance);
            //Assert.AreEqual(_reservation.ReserveUser, _commensal);
            //Assert.AreEqual(_reservation.ReserveRestaurant, _restaurant);

        }

        [TestFixtureTearDown]
        public void EndTests()
        {

        }

    }
}
