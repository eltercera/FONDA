using com.ds201625.fonda.Domain;

namespace com.ds201625.fonda.DataAccess.InterfaceDAO
{
    public interface IRestaurantDAO : INounBaseEntityDAO<Restaurant>
    {
        Restaurant findByTable(Table table);
    }
}
