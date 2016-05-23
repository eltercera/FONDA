using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System.Collections.Generic;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateDayDAO : HibernateNounBaseEntityDAO<Day> , IDayDAO
    {
        /// <summary>
        /// Devuelve el dia a partir del nombre
        /// </summary>
        /// <param name="name">Nombre del dia</param>
        /// <returns>Objeto de tipo Dia</returns>
        public IList<Day> GetDay(bool[] days)
        {
            IList<Day> listDays = new List<Day>();
            for (int i = 0; i < days.Length; i++)
            {
                Day day = new Day();
                if(i.Equals(0) && days[i])
                {
                    day = FindById(1);
                    listDays.Add(day);
                }
                else if (i.Equals(1) && days[i])
                {
                    day = FindById(2);
                    listDays.Add(day);
                }
                else if(i.Equals(2) && days[i])
                {
                    day = FindById(3);
                    listDays.Add(day);
                }
                else if (i.Equals(3) && days[i])
                {
                    day = FindById(4);
                    listDays.Add(day);
                }
                else if (i.Equals(4) && days[i])
                {
                    day = FindById(5);
                    listDays.Add(day);
                }
                else if (i.Equals(5) && days[i])
                {
                    day = FindById(6);
                    listDays.Add(day);
                }
                else if (i.Equals(6) && days[i])
                {
                    day = FindById(7);
                    listDays.Add(day);

                }

            }

            return listDays;
        }
    }
}
