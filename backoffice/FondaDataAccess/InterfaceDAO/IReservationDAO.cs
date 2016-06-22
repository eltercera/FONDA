using System.Collections.Generic;
using com.ds201625.fonda.Domain;

namespace com.ds201625.fonda.DataAccess.InterfaceDAO
{
    public interface IReservationDAO : IBaseEntityDAO<Reservation>
    {
         IList<Reservation> GetAll();
        IList<Reservation> FindReservationsByTable(int tableId);
        IList<Reservation> FindReservationsByRestaurant(int restaurantId);
    }
}
