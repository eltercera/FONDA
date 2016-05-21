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
        public Schedule GetSchedule(TimeSpan openingTime, TimeSpan closingTime)
        {
            Schedule schedule = new Schedule();
            IList<Schedule> listSchedule = GetAll();
            foreach(Schedule sch in listSchedule)
            {
                if (openingTime.Equals(sch.OpeningTime) && closingTime.Equals(sch.ClosingTime))
                    schedule = sch;
            }

            return schedule;
        }
    }
}
