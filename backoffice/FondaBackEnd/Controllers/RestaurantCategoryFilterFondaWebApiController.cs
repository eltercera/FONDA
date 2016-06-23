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
    public class RestaurantCategoryFilterFondaWebApiController : FondaWebApi
    {
        public RestaurantCategoryFilterFondaWebApiController() : base() { }

        [Route("category/{id}")]
        [HttpGet]
        public IHttpActionResult getRestaurantFilter( int id)
        {
            /// <summary>
            /// Llamar al metodo mediante la interfaz
            /// para listar los restaurantes que se
            /// encuentren en una categoria
            /// </summary>
            /// <returns></returns>
            /// 
          IRestaurantCategoryDAO categoryDAO = FactoryDAO.GetRestaurantCategoryDAO();
          RestaurantCategory category = categoryDAO.FindById(id);

            /*if (zone == null)
                BadRequest();*/
          
          IRestaurantDAO restaurantDAO = FactoryDAO.GetRestaurantDAO();
          IList<Restaurant> listRestaurant = restaurantDAO.findByCategory(category);

          return Ok(listRestaurant);



        }
    }
}