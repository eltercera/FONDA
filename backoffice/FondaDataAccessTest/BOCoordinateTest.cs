using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using NUnit.Framework;


namespace DataAccessTests
{
    [TestFixture]
    public class BOCoordinateTest
    {
        private FactoryDAO _facDAO;
        private ICoordinateDAO _coordinateDAO;
        private Coordinate _coordinate;
        private int _coordinateId;

        [SetUp]
        private void generateCoordinate(bool edit = false)
        {
            if (_coordinate != null)
                return;

            if ((edit & _coordinate == null) | _coordinate == null)
                _coordinate = new Coordinate();

            _coordinate.Latitude = 10.497600;
            _coordinate.Longitude = -66.813324;

        }

        [Test]
        public void CoordinateTest()
        {
            generateCoordinate();
            coordinateAssertions();

        }


        private void coordinateAssertions(bool edit = false)
        {
            Assert.IsNotNull(_coordinate);
            //Assert.AreEqual(_coordinate.Latitude, 2);
            //Assert.AreEqual(_coordinate.Longitude, 3);
        }

        [Test]
        public void CoordinateSave()
        {
            getCoordinateDao();
            generateCoordinate();

            _coordinateDAO.Save(_coordinate);

            Assert.AreNotEqual(_coordinate.Id, 0);
            _coordinateId = _coordinate.Id;
            generateCoordinate(true);
            _coordinateDAO.Save(_coordinate);
            _coordinateDAO.ResetSession();
            _coordinate = null;

        }

        private void getCoordinateDao()
        {
            getDao();
            if (_coordinateDAO == null)
                _coordinateDAO = _facDAO.GetCoordinateDAO();

        }

        private void getDao()
        {
            if (_facDAO == null)
                _facDAO = FactoryDAO.Intance;
        }

        [TestFixtureTearDown]
        public void EndTests()
        {

        }

    }
}
