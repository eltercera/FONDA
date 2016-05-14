using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DataAccessTests
{
    [TestFixture]
    public class BOScheduleTest
    {
        private FactoryDAO _facDAO;
        private IScheduleDAO _scheduleDAO;
        private Schedule _schedule;
        private int _scheduleId;


        [Test]
        public void ScheduleTest()
        {
            generateSchedule();
            scheduleAssertions();
        }

        private void generateSchedule(bool edit = false)
        {
            if (_schedule != null)
                return;

            if ((edit & _schedule == null) | _schedule == null)
                _schedule = new Schedule();

            _schedule.OpeningTime = new TimeSpan(7,0,0);
            _schedule.ClosingTime = new TimeSpan(15, 0, 0);
            Day _lunes = new Day() {  Name = "Lunes" };
            _schedule.Day = new List<Day>();
            _schedule.Day.Add(_lunes);
        }

        private void scheduleAssertions(bool edit = false)
        {
            Assert.IsNotNull(_schedule);
            Assert.AreEqual(_schedule.OpeningTime, new TimeSpan(7, 0, 0));
            Assert.AreEqual(_schedule.ClosingTime, new TimeSpan(15, 0, 0));
            Day _lunes = new Day() {  Name = "Lunes" };
            
            _schedule.Day = new List<Day>();
            _schedule.Day.Add(_lunes);
            Assert.AreEqual(_schedule.Day[0], _lunes);
        }

        [Test]
        public void ScheduleSave()
        {
            getScheduleDao();
            generateSchedule();
            _scheduleDAO.Save(_schedule);
            Assert.AreNotEqual(_schedule.Id, 0);
            _scheduleId = _schedule.Id;
            generateSchedule(true);
            _scheduleDAO.Save(_schedule);
            _scheduleDAO.ResetSession();
            _schedule = null;
        }

        private void getScheduleDao()
        {
            getDao();
            if (_scheduleDAO == null)
                _scheduleDAO = _facDAO.GetScheduleDAO();
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

