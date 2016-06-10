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
    public class AddFavoritesRestaurantsFondaWebApiController : FondaWebApi
    {
        public AddFavoritesRestaurantsFondaWebApiController() : base() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idcommensal"></param>
        /// <param name="idrestaurant"></param>
        /// <returns></returns>

        [Route("addfavorite/{idcommensal}/{idrestaurant}")]
        [HttpGet]
        ///[FondaAuthToken]
        public IHttpActionResult addfavorite(int idcommensal, int idrestaurant)
        {

            Commensal commensal = (Commensal)GetCommensalDao().FindById(idcommensal);
            ICommensalDAO commensalDao = FactoryDAO.GetCommensalDAO();
            Restaurant restaurant = GetRestaurantDao().FindById(idrestaurant);
            bool existe = false;
            IList<Restaurant> favorites;
            if (commensal == null)
                return BadRequest();
            if (restaurant == null)
                return BadRequest();
            commensal.RemoveFavoriteRestaurant(restaurant);
            commensal.AddFavoriteRestaurant(restaurant);
            try
            {
                commensalDao.Save(commensal);
            }
            catch (SaveEntityFondaDAOException e)
            {
                Console.WriteLine(e.ToString());
                return InternalServerError(e);
            }

            return Ok(commensal);
        }


        private IRestaurantDAO GetRestaurantDao()
        {
            return FactoryDAO.GetRestaurantDAO();
        }
        private ICommensalDAO GetCommensalDao()
        {
            return FactoryDAO.GetCommensalDAO();
        }




    }
}