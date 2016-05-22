using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateScheduleDAO : HibernateBaseEntityDAO<Schedule> , IScheduleDAO
    {
        FactoryDAO.FactoryDAO _facDAO = FactoryDAO.FactoryDAO.Intance;

        /// <summary>
        /// Devuelve la lista de todos los horarios de la Base de Datos
        /// </summary>
        /// <returns>Lista de tipo Schedule</returns>
        public IList<Schedule> GetAll()
        {
            return FindAll();
        }

        /// <summary>
        /// Devuelve un horario de la Base de Datos
        /// </summary>
        /// <param name="openingTime"></param>
        /// <param name="closingTime"></param>
        /// <returns></returns>
        public Schedule GetSchedule(TimeSpan OpeningTime, TimeSpan ClosingTime, bool[] Days)
        {

            IDayDAO _dayDAO = _facDAO.GetDayDAO();

            Schedule schedule = new Schedule();
            schedule.OpeningTime = OpeningTime;
            schedule.ClosingTime = ClosingTime;

            IList<Day> listDays = _dayDAO.GetDay(Days);
            schedule.Day = listDays;

            
            return schedule;
        }
    }
}
