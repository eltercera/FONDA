using System.Collections.Generic;
using com.ds201625.fonda.Domain;
using System;

namespace com.ds201625.fonda.DataAccess.InterfaceDAO
{
    public interface IRestaurantDAO : INounBaseEntityDAO<Restaurant>
    {
        IList<Restaurant> GetAll();

        Restaurant GenerateRestaurant(string Name, string Logo, char Nationality, string Rif, string Address,
                string Category, string Currency, string Zone, double Long, double Lat,
                TimeSpan OpeningTime, TimeSpan ClosingTime, bool[] Days);

        Restaurant ModifyRestaurant(int idRestaurant, Restaurant newRestaurant);

        IList<Restaurant> findByZone(Zone zone);

        //Restaurant findByTable(Table table);
        IList<Restaurant> findByCategory(RestaurantCategory category);

        bool Geoposition(double _latitudUser, double _longitudUser, int _idRestaurant);
        bool ValidateHour(int _idRestaurant, DateTime _hour);
        bool ValidateDay(int _idRestaurant, DateTime _hour);

		#region 3era entrega

		IList<Restaurant> FindByFilters (
			string query = null, int idZone = 0, int  idCategory = 0, int max = -1, int page = 1);

		#endregion
    }
}
