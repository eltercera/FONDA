using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace com.ds201625.fonda.BackEnd.Controllers
{
    [RoutePrefix("api")]
    public class RestaurantFondaWebApiController : FondaWebApi
    {
        public RestaurantFondaWebApiController() : base() { }

        [HttpPost]
        [Route("restaurante/{restaurantId}/reserva")]
        public IHttpActionResult ReservationRequest(int restaurantId)
        {
            return Ok();
        }

        [HttpPost]
        [Route("restaurante/{restauranteId}/llegada")]
        public IHttpActionResult GeopositionNotification(int restauranteId)
        {
            return Ok();
        }

        private Restaurant GetRestaurant(int restaurantId)
        {
            IRestaurantDAO _restaurantDAO = GetRestaurantDAO();
            Restaurant _restaurant = _restaurantDAO.FindById(restaurantId);
            return _restaurant;
        }

        private IRestaurantDAO GetRestaurantDAO()
        {
            return FactoryDAO.GetRestaurantDAO(); 
        }


    }
}