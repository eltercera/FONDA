using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using NUnit.Framework;


namespace DataAccessTests
{
    [TestFixture]
    public class BODayTest
    {
        private FactoryDAO _facDAO;
        private IDayDAO _dayDAO;
        private Day _day;
        private int _dayId;


        [Test]
        public void DayTest()
        {
            generateDay();
            dayAssertions();
        }

        private void generateDay(bool edit = false)
        {
            if (_day != null)
                return;

            if ((edit & _day == null) | _day == null)
                _day = new Day();
            _day.Name = "Martes";

        }

        private void dayAssertions(bool edit = false)
        {
            Assert.IsNotNull(_day);
            Assert.AreEqual(_day.Name, "Martes");
        }

        [Test]
        public void DaySave()
        {
            getDayDao();
            generateDay();
            _dayDAO.Save(_day);
            Assert.AreNotEqual(_day.Id, 0);
            _dayId = _day.Id;
            generateDay(true);
            _dayDAO.Save(_day);
            _dayDAO.ResetSession();
            _day = null;
        }

        private void getDayDao()
        {
            getDao();
            if (_dayDAO == null)
                _dayDAO = _facDAO.GetDayDAO();
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

