using System;
using System.Web.Http;
using System.Linq;
using System.Collections;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.DataAccess.HibernateDAO;

using System.Collections.Generic;
using Newtonsoft.Json;

namespace com.ds201625.fonda.BackEnd.Controllers
{
    [RoutePrefix("api")]
    public class RestaurantFilterFondaWebApiController : FondaWebApi
    {
        public RestaurantFilterFondaWebApiController() : base() { }

        [Route("zone/{id}")]
        [HttpGet]
        public IHttpActionResult getRestaurantFilter( int id)
        {
            /// <summary>
            /// Llamar al metodo mediante la interfaz
            /// para listar los restaurantes que se
            /// encuentren en una zona
            /// </summary>
            /// <returns></returns>
            /// 
          IZoneDAO zoneDAO = FactoryDAO.GetZoneDAO();
          Zone zone = zoneDAO.FindById(id);

            /*if (zone == null)
                BadRequest();*/
          
          IRestaurantDAO restaurantDAO = FactoryDAO.GetRestaurantDAO();
          IList<Restaurant> listRestaurant = restaurantDAO.findByZone(zone);

          return Ok(listRestaurant);



            /*
        String zona = "Altamira";
        RestaurantCategory category1 = new RestaurantCategory();
        category1.NameCategory = "Romantico";
        RestaurantCategory category2 = new RestaurantCategory();
        category2.NameCategory = "Casual";
        RestaurantCategory category3 = new RestaurantCategory();
        category3.NameCategory = "Italiano";
        RestaurantCategory category4 = new RestaurantCategory();
        category4.NameCategory = "Americano";
        //Agregando zonas//
        Zone zone1 = new Zone();
        zone1.Name = "Altamira";
        Zone zone2 = new Zone();
        zone2.Name = "Alto Hatillo";
        Zone zone3 = new Zone();
        zone3.Name = "Bello Monte";
        Zone zone4 = new Zone();
        zone4.Name = "Boleita";
        Zone zone5 = new Zone();
        zone5.Name = "Chacao";
        Restaurant restaurant1 = new Restaurant();
        restaurant1.Name = "Friday";
        restaurant1.Address = "Principal de altamira";
        restaurant1.RestaurantCategory = category2;
        restaurant1.Zone = zone1;
        Restaurant restaurant2 = new Restaurant();
        restaurant2.Name = "El Cine";
        restaurant2.Address = "5ta transversal";
        restaurant2.RestaurantCategory = category1;
        restaurant2.Zone = zone2;
        Restaurant restaurant3 = new Restaurant();
        restaurant3.Name = "Crema Paraiso";
        restaurant3.Address = "Principal de Bello Monte";
        restaurant3.RestaurantCategory = category3;
        restaurant3.Zone = zone3;
        Restaurant restaurant4 = new Restaurant();
        restaurant4.Name = "La Casona";
        restaurant4.Address = "Boleita";
        restaurant4.RestaurantCategory = category3;
        restaurant4.Zone = zone4;
        Restaurant restaurant5 = new Restaurant();
        restaurant5.Name = "Tony's";
        restaurant5.Address = "El Rosal";
        restaurant5.RestaurantCategory = category4;
        restaurant5.Zone = zone5;
        List<Restaurant> lista = new List<Restaurant>();
        if (restaurant1.Zone.Name.Equals(zona))
        {
            lista.Add(restaurant1);
        }
        if (restaurant2.Zone.Name.Equals(zona))
        {
            lista.Add(restaurant2);
        }
        if (restaurant3.Zone.Name.Equals(zona))
        {
            lista.Add(restaurant3);
        }
        if (restaurant4.Zone.Name.Equals(zona))
        {
            lista.Add(restaurant4);
        }
        if (restaurant5.Zone.Name.Equals(zona))
        {
            lista.Add(restaurant5);
        }
        return Ok(lista);
        */
        }
    }
}