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
        //[FondaAuthToken]
        public IHttpActionResult getFavorites()
        {

            Commensal commensal = GetCommensal(Request.Headers);
            if (commensal == null)
                return BadRequest();
            IList<Restaurant> lista = commensal.FavoritesRestaurants.ToList();
            foreach (var restaurant in lista)
            {
                restaurant.Coordinate = null;
                restaurant.Currency = null;
                restaurant.MenuCategories = null;
                restaurant.Zone=null;
                restaurant.Tables = null;
                restaurant.Schedule = null;
                
                return Ok(restaurant.Name);
            }
            return Ok(lista);
        }
        /// <summary>
        /// elimina un restaurante de la lista de favoritos de un
        /// commensal, recibe id int del restaurant a agregar,
        /// retorna lista de favoritos actualizada
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("deletefavorite/{idcommensal}/{idrestaurant}")]
        [HttpGet]
        //[FondaAuthToken]
        public IHttpActionResult deletefavorite(int idcommensal,int idrestaurant)
        {
            Commensal commensal = (Commensal)GetCommensalDao().FindById(idcommensal);
            ICommensalDAO commensalDao = FactoryDAO.GetCommensalDAO();
            Restaurant restaurant = GetRestaurantDao().FindById(idrestaurant);
            commensal.RemoveFavoriteRestaurant(restaurant);
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
        /// <summary>
        /// funcion que agrega restaurante a la lista de favoritos de un 
        /// commensal, recibe id del restaurante a agregar, devuelve lista
        /// actualizada 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("addfavorite/{idcommensal}/{idrestaurant}")]
        [HttpGet]
        ///[FondaAuthToken]
        public IHttpActionResult addfavorite(int idcommensal,int idrestaurant)
        {
            
            Commensal commensal = (Commensal)GetCommensalDao().FindById(idcommensal);
            ICommensalDAO commensalDao = FactoryDAO.GetCommensalDAO();
            Restaurant restaurant = GetRestaurantDao().FindById(idrestaurant);
            //commensal.AddFavoriteRestaurant(restaurant);
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



        [Route("ListaRestaurant")]
        [HttpGet]
        public IHttpActionResult getRestaurant()
        {
            IRestaurantDAO RestaurantDAO = FactoryDAO.GetRestaurantDAO();
            IList<Restaurant> listRestaurant = RestaurantDAO.GetAll();

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