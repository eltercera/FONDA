using System;
using System.Web.Http;
using System.Linq;
using System.Collections;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.BackEnd.ActionFilters;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.DataAccess.Exceptions;
using System.Collections.Generic;

namespace com.ds201625.fonda.BackEnd.Controllers
{
    [RoutePrefix("api")]
    public class HistoryFavoritesRestaurantsFondaWebApiController : FondaWebApi
    {
        public HistoryFavoritesRestaurantsFondaWebApiController() : base() { }

        [Route("ListaRestaurant")]
        [HttpGet]
        public IHttpActionResult getRestaurant()
        {
            IRestaurantDAO RestaurantDAO = FactoryDAO.GetRestaurantDAO();
            IList<Restaurant> listRestaurant = RestaurantDAO.GetAll();

            foreach (var restaurant in listRestaurant)
            {
                restaurant.RestaurantCategory = new RestaurantCategory
                {
                    Name = restaurant.RestaurantCategory.Name,
                    Id = restaurant.RestaurantCategory.Id
                };    

            }

            return Ok(listRestaurant);
        }

        private IRestaurantDAO GetRestaurantDao()
        {
            return FactoryDAO.GetRestaurantDAO();
        }
        private ICommensalDAO GetCommensalDao()
        {
            return FactoryDAO.GetCommensalDAO();
        }



        [Route("findRestaurantFavorites/{id}")]
        [HttpGet]
        public IHttpActionResult findRestaurantFavorites(int id)
        {
            Commensal commensal = (Commensal)GetCommensalDao().FindById(id);

            foreach (var restaurant in commensal.FavoritesRestaurants)
            {
                restaurant.RestaurantCategory = new RestaurantCategory
                {
                    Name = restaurant.RestaurantCategory.Name,
                    Id = restaurant.RestaurantCategory.Id
                };

            }

            return Ok(commensal.FavoritesRestaurants);

        }

        [Route("findCommensalEmail/{email}")]
        [HttpGet]
        public IHttpActionResult findCommensalEmail(string email)
        {

            UserAccount comm = GetCommensalDao().FindByEmail(email);
            return Ok(comm);

        }






    }
}