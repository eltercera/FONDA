using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateDayDAO : HibernateNounBaseEntityDAO<Day> , IDayDAO
    {
        /// <summary>
        /// Devuelve el dia a partir del nombre
        /// </summary>
        /// <param name="name">Nombre del dia</param>
        /// <returns>Objeto de tipo Dia</returns>
        public Day GetDay(string name)
        {
            Day day = new Day();
            switch (name)
            {
                case "Lunes":
                    day = FindById(1);
                    break;
                case "Martes":
                    day = FindById(2);
                    break;
                case "Miercoles":
                    day = FindById(3);
                    break;
                case "Jueves":
                    day = FindById(4);
                    break;
                case "Viernes":
                    day = FindById(5);
                    break;
                case "Sabado":
                    day = FindById(6);
                    break;
                case "Domingo":
                    day = FindById(7);
                    break;
                default:
                    break;
            }

            return day;
        }
    }
}
