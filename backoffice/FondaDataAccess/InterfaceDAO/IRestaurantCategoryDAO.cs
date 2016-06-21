using System.Collections.Generic;
using com.ds201625.fonda.Domain;

namespace com.ds201625.fonda.DataAccess.InterfaceDAO
{
	public interface IRestaurantCategoryDAO : INounBaseEntityDAO <RestaurantCategory>
    {
        IList<RestaurantCategory> GetAll();

        RestaurantCategory GetRestaurantCategory(string name);

		#region 3era entrega

		IList<RestaurantCategory> FindAllWithRestaurants (
			string query = null, int max = -1, int page = 1);

		#endregion
    }
}
