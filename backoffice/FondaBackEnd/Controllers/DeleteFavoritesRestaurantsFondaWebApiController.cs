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
    public class DeleteFavoritesRestaurantsFondaWebApiController : FondaWebApi
    {
        public DeleteFavoritesRestaurantsFondaWebApiController() : base() { }

      
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
        public IHttpActionResult deletefavorite(int idcommensal, int idrestaurant)
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
        /// 
        /// </summary>
        /// <param name="idcommensal"></param>
        /// <param name="idrestaurant"></param>
        /// <returns></returns>

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