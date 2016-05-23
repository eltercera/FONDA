using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FondaDataAccessTest
{
    [TestFixture]
    public class BOScheduleTest
    {
        private FactoryDAO _facDAO;
        private IScheduleDAO _scheduleDAO;
        private Schedule _schedule;
        private Schedule _result;
        private int _scheduleId;
        TimeSpan opening;
        TimeSpan closing;
        bool[] days;


        [SetUp]
        public void Init()
        {
            if (_facDAO == null)
                _facDAO = FactoryDAO.Intance;

            _scheduleDAO = _facDAO.GetScheduleDAO();

            _schedule = new Schedule();
            _schedule.OpeningTime = new TimeSpan(11, 0, 0);
            _schedule.ClosingTime = new TimeSpan(22, 0, 0);
            _schedule.Day = new List<Day>() { new Day() { Name = "Lunes" }, new Day()
            { Name = "Marte" }, new Day() { Name = "Miercoles" } };
            
            opening = new TimeSpan(8, 0, 0);
            closing = new TimeSpan(10, 0, 0);
            days = new bool[] { true, true, true, true, true, true, true };

        }

        [Test(Description = "Prueba si trae un mismo objeto de la Base de Datos")]
        [Ignore]
        public void SameSchedule()
        {

            _result = _scheduleDAO.GetSchedule(opening, closing, days);

            Assert.IsNotNull(_result);
            Assert.AreEqual(1, _result.Id);
            Assert.AreEqual(opening, _result.OpeningTime);
            Assert.AreEqual(closing, _result.ClosingTime);


        }

        [Test(Description = "Salva un objeto en la Base de Datos")]
        [Ignore]
        public void ScheduleSave()
        {
            _result = _scheduleDAO.GetSchedule(opening, closing, days);
            _scheduleDAO.Save(_result);

            Assert.IsNotNull(_result);
            Assert.AreEqual(1, _result.Id);
            Assert.AreEqual(opening, _result.OpeningTime);
            Assert.AreEqual(closing, _result.ClosingTime);

        }

        [Test(Description = "Actualiza un objeto Schedule de la Base de Datos")]
        [Ignore]
        public void ScheduleUpdate()
        {
            _schedule = _scheduleDAO.GetSchedule(opening, closing,days);
            _schedule.OpeningTime = new TimeSpan(06, 0, 0);
            _schedule.ClosingTime = new TimeSpan(18, 30, 0);
            _scheduleDAO.Save(_schedule);
            _result = _scheduleDAO.GetSchedule(opening, closing,days);

            Assert.IsNotNull(_result);
            Assert.AreEqual(1, _result.Id);
            Assert.AreEqual(opening, _result.OpeningTime);
            Assert.AreEqual(closing, _result.ClosingTime);

        }

        [TestFixtureTearDown]
        public void EndTests()
        {

        }


    }
}

