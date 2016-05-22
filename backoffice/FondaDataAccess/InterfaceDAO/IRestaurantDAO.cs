using System.Collections.Generic;
using com.ds201625.fonda.Domain;

namespace com.ds201625.fonda.DataAccess.InterfaceDAO
{
    public interface IRestaurantDAO : INounBaseEntityDAO<Restaurant>
    {
        IList<Restaurant> GetAll();
        IList<Restaurant> findByZone(Zone zone);
        Restaurant findByTable(Table table);
        IList<Restaurant> findByCategory(RestaurantCategory category);
    }
}
