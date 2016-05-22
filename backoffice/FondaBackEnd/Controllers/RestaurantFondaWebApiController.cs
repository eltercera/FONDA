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
        public IHttpActionResult ReservationRequest(int restaurantId, Reservation reserve)
        {
            ITableDAO _table = GetTableDAO();
            IReservationDAO _reservation = GetReservationDAO();

            IList<Reservation> listReservation = _reservation.FindByRestaurant(restaurantId);
            IList<Table> listTable = _table.TablesAvailableByDate(restaurantId, listReservation, reserve.ReserveDate);
            listTable = _table.TablesAvailableByCapacity(listTable, reserve.CommensalNumber);



            if (listTable.Count == 0)
                return BadRequest();

            Table table = listTable[0];
            return Ok(table);
        }

        [HttpPost]
        [Route("restaurante/{restauranteId}/llegada")]
        public IHttpActionResult GeopositionNotification(int restauranteId, Coordinate coords)
        {
            IRestaurantDAO _restaurant = GetRestaurantDAO();
            bool match = _restaurant.Geoposition(coords.Latitude, coords.Longitude, restauranteId);

            if (!match)
                return BadRequest();

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

        private ITableDAO GetTableDAO()
        {
            return FactoryDAO.GetTableDAO();
        }

        private IReservationDAO GetReservationDAO()
        {
            return FactoryDAO.GetReservationDAO();
        }

    }
}