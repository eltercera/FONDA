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
    }
}
