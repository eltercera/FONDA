using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System;
using System.Collections.Generic;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateReservationDAO : HibernateBaseEntityDAO<Reservation>, IReservationDAO
    {
        public IList<Reservation> GetAll()
        {
            return FindAll();
        }

        public IList<Reservation> FindByRestaurant(int restaurant)
        { 
            IList<Reservation> reservations = GetAll();
            IList<Reservation> reservationsRestaurant = new List<Reservation>();

            foreach (Reservation t in reservations)
            { 
                if (t.ReserveRestaurant.Id == restaurant)
                    reservationsRestaurant.Add(t);
            }
            return reservationsRestaurant;
        }


    }
}
