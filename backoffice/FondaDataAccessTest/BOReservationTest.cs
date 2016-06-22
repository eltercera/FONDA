using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaDataAccessTest
{
//    [TestFixture]
//    public class BOReservationTest
//    {
//        private com.ds201625.fonda.DataAccess.FactoryDAO.FactoryDAO _facDAO;
//        private IReservationDAO _reservationDAO;
//        private Reservation _reservation;
//        private int _reservationId;


//        [Test]
//        public void ReservationTest()
//        {
//            generateReservation();
//            reservationAssertions();

//        }

//        [Test]
//        public void ReservationSave()
//        {
//            getReservationDao();
//            generateReservation();

//            _reservationDAO.Save(_reservation);

//            Assert.AreNotEqual(_reservation.Id, 0);
//            _reservationId = _reservation.Id;

//            generateReservation(true);

//            _reservationDAO.Save(_reservation);

//            _reservationDAO.ResetSession();

//            _reservation = null;


//        }

//        private void getReservationDao()
//        {
//            getDao();
//            if (_reservationDAO == null)
//                _reservationDAO = _facDAO.GetReservationDAO();

//        }

//        private void getDao()
//        {
//            if (_facDAO == null)
//                _facDAO = com.ds201625.fonda.DataAccess.FactoryDAO.FactoryDAO.Intance;
//        }


//        private void generateReservation(bool edit = false)
//        {
//            if (_reservation != null)
//                return;

//            if ((edit & _reservation == null) | _reservation == null)
//                _reservation = new Reservation();

//            _reservation.ReserveDate = new DateTime(2016,09,27,15,30,00);
//            _reservation.CreateDate = new DateTime(2016, 09, 15, 14, 30, 00);
//            _reservation.CommensalNumber = 3;
//            _reservation.ReserveStatus = ActiveReservationStatus.Instance;

//        }


//        private void reservationAssertions(bool edit = false)
//        {
//            Assert.IsNotNull(_reservation);
//            Assert.AreEqual(_reservation.ReserveDate, new DateTime(2016, 09, 27, 15, 30, 00));
//            Assert.AreEqual(_reservation.CreateDate, new DateTime(2016, 09, 15, 14, 30, 00));
//            Assert.AreEqual(_reservation.CommensalNumber, 3);
//            Assert.AreEqual(_reservation.ReserveStatus, ActiveReservationStatus.Instance);
//        }

//        [TestFixtureTearDown]
//        public void EndTests()
//        {

//        }

   // }
}
