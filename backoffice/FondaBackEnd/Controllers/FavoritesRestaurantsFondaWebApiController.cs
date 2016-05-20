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
    public class FavoritesRestaurantsFondaWebApiController : FondaWebApi
    {
        public FavoritesRestaurantsFondaWebApiController() : base() { }
        /// <summary>
        /// funcion que consulta lista de restaurantes favoritos
        /// de un comensal, validacion de correo y password se hace
        /// por el auth y el tokken por header
        /// </summary>
        /// <returns></returns>
        [Route("favoritesrestaurants")]
        [HttpGet]
        [FondaAuthToken]
        public IHttpActionResult getFavorites()
        {
            Commensal commensal = GetCommensal(Request.Headers);
            if (commensal == null)
                return BadRequest();

            return Ok(commensal.FavoritesRestaurants);
        }
        /// <summary>
        /// elimina un restaurante de la lista de favoritos de un
        /// commensal, recibe id int del restaurant a agregar,
        /// retorna lista de favoritos actualizada
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("deletefavorite")]
        [HttpPost]
        [FondaAuthToken]
        public IHttpActionResult deletefavorite(int id)
        {
            Commensal commensal = GetCommensal(Request.Headers);
            Restaurant restaurant = GetRestaurant(Request.Headers, id);
            commensal.RemoveFavoriteRestaurant(restaurant);
            ICommensalDAO commensalDao = FactoryDAO.GetCommensalDAO();
            try
            {
                commensalDao.Save(commensal);
            }
            catch (SaveEntityFondaDAOException e)
            {
                Console.WriteLine(e.ToString());
                return InternalServerError(e);
            }
            return Ok(commensal.FavoritesRestaurants);
        }
        /// <summary>
        /// funcion que agrega restaurante a la lista de favoritos de un 
        /// commensal, recibe id del restaurante a agregar, devuelve lista
        /// actualizada 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("addfavorite")]
        [HttpPost]
        [FondaAuthToken]
        public IHttpActionResult addfavorite(int id)
        {
            
            Commensal commensal = GetCommensal(Request.Headers);
            Restaurant restaurant = GetRestaurant(Request.Headers,id);
            ICommensalDAO commensalDao = FactoryDAO.GetCommensalDAO();
            
            bool existe = false;
            IList<Restaurant> favorites;
            if (commensal == null)
                return BadRequest();
            if (restaurant == null)
                return BadRequest();
            favorites = commensal.FavoritesRestaurants;

            foreach (var restauranteList in favorites)
            {
                if (restaurant == restauranteList)
                {
                    existe = true;
                }
            }

            if (existe == false)
            {

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
            }
            return Ok(commensal.FavoritesRestaurants);
        }



        [Route("ListaRestaurant")]
        [HttpGet]
        public IHttpActionResult getRestaurant()
        {
            IRestaurantDAO RestaurantDAO = FactoryDAO.GetRestaurantDAO();
            IList<Restaurant> listRestaurant = RestaurantDAO.GetAll();

            return Ok(listRestaurant);
        }






    }
}