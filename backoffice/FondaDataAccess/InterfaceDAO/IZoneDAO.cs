using com.ds201625.fonda.Domain;
using System.Collections.Generic;

namespace com.ds201625.fonda.DataAccess.InterfaceDAO
{
	public interface IZoneDAO : INounBaseEntityDAO<Zone>
    {
        IList<Zone> allZone();
        Zone GetZone(string name);

		#region 3era entrega

		IList<Zone> FindAllWithRestaurants (string query = null, int max = -1, int page = 1);

		#endregion
    }
}
