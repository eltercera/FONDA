using com.ds201625.fonda.DataAccess.FondaDAOExceptions;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System;
using System.Collections.Generic;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateReservationDAO : HibernateBaseEntityDAO<Reservation>, IReservationDAO
    {
        /// <summary>
        /// Devuelve todas las reservaciones
        /// </summary>
        /// <returns>Una lista de reservaciones</returns>
        public IList<Reservation> GetAll()
        {
            return FindAll();
        }


    }

}

