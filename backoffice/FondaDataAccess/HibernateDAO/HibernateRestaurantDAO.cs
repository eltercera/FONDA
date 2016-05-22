using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System;
using System.Collections.Generic;
using NHibernate.Criterion;
using NHibernate;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateRestaurantDAO: HibernateNounBaseEntityDAO<Restaurant>, IRestaurantDAO
    {
        FactoryDAO.FactoryDAO _facDAO = FactoryDAO.FactoryDAO.Intance;

        /// <summary>
        /// Devuelve todos los restaurantes
        /// </summary>
        /// <returns>Una lista de restaurantes</returns>
        public IList<Restaurant> GetAll()
        {
            return FindAll();
        }

        /// <summary>
        /// Metodo para devolver todos los restaurantes 
        /// que se encuentran en una zona
        /// </summary>
        /// <param name="zone"></param>
        /// <returns></returns>
        public IList<Restaurant> findByZone(Zone zone)
        {
            ICriterion criterion = Expression.Eq("Zone", zone);
            return (FindAll(criterion));
        }

        /// <summary>
        /// Genera un nuevo Restaurante a partir de los datos suministrados por el usuario
        /// </summary>
        /// <param name="Name">Nombre del Restaurante</param>
        /// <param name="Logo">Logo del Restaurante</param>
        /// <param name="Nationality">Nacionalidad</param>
        /// <param name="Rif">Rif del Restaurante</param>
        /// <param name="Address">Direccion fisica del Restaurante</param>
        /// <param name="Category">Tipo de comida del Restaurante</param>
        /// <param name="Currency">Tipo de moneda del Restaurante</param>
        /// <param name="Zone">Ubicacion del Restaurante</param>
        /// <param name="Long">Longitud para Coordenada</param>
        /// <param name="Lat">Latitud para Coordenada</param>
        /// <param name="OpeningTime">Hora de apertura</param>
        /// <param name="ClosingTime">Hora de cierre</param>
        /// <param name="Days">Dias laborables</param>
        /// <returns></returns>
        public Restaurant GenerateRestaurant(string Name, string Logo, char Nationality, string Rif, string Address,
                string Category, string Currency, string Zone, double Long, double Lat,
                TimeSpan OpeningTime, TimeSpan ClosingTime, bool[] Days)
        {

            IRestaurantCategoryDAO _restcatDAO = _facDAO.GetRestaurantCategoryDAO();
            ICurrencyDAO _currencyDAO = _facDAO.GetCurrencyDAO();
            IZoneDAO _zoneDAO = _facDAO.GetZoneDAO();
            IScheduleDAO _scheduleDAO = _facDAO.GetScheduleDAO();


            Coordinate coordinate = new Coordinate();
            coordinate.Latitude = Lat;
            coordinate.Longitude = Long;

            Restaurant restaurant = new Restaurant();
            restaurant.Name = Name;
            restaurant.Logo = Logo;
            restaurant.Nationality = Nationality;
            restaurant.Ssn = Rif;
            restaurant.Address = Address;
            restaurant.RestaurantCategory = _restcatDAO.GetRestaurantCategory(Category);
            restaurant.Currency = _currencyDAO.GetCurrency(Currency);
            restaurant.Zone = _zoneDAO.GetZone(Zone);
            restaurant.Coordinate = coordinate;
            restaurant.Schedule = _scheduleDAO.GetSchedule(OpeningTime, ClosingTime, Days);
            restaurant.Status = _facDAO.GetActiveSimpleStatus();

            return restaurant;


        }

        /// <summary>
        /// Modifica un Restaurante
        /// </summary>
        /// <param name="idRestaurant">Id del Restaurante a modificar</param>
        /// <param name="newRestaurant">Datos a modificar del Restaurante</param>
        /// <returns>Restaurante resultante</returns>
        public Restaurant ModifyRestaurant(int idRestaurant, Restaurant newRestaurant)
        {
            IRestaurantDAO _restaurantDAO = _facDAO.GetRestaurantDAO();

            // Consigue el Restaurante a modificar en la Base de Datos
            com.ds201625.fonda.Domain.Restaurant _restaurant = _restaurantDAO.FindById(idRestaurant);

            // Cambia los valores suministrados por el usuario
            _restaurant.Name = newRestaurant.Name;
            _restaurant.Logo = newRestaurant.Logo;
            _restaurant.Nationality = newRestaurant.Nationality;
            _restaurant.Ssn = newRestaurant.Ssn;
            _restaurant.Address = newRestaurant.Address;
            _restaurant.RestaurantCategory = newRestaurant.RestaurantCategory;
            _restaurant.Currency = newRestaurant.Currency;
            _restaurant.Zone = newRestaurant.Zone;
            _restaurant.Coordinate = newRestaurant.Coordinate;
            _restaurant.Schedule = newRestaurant.Schedule;
            _restaurant.Status = _facDAO.GetActiveSimpleStatus();

            return _restaurant;
        }

        public Restaurant findByTable(Table table)
        {
            ICriteria crit = Session.CreateCriteria(typeof(Restaurant));
            // Inner Join
            crit.CreateAlias("Tables", "sm");
            crit.Add(Restrictions.Eq("sm.Id", table.Id));
            return (Restaurant)crit.List()[0];
        }

    }
}
