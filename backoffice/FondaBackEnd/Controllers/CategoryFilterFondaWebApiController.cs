using System;
using System.Web.Http;
using System.Linq;
using System.Collections;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.BackEnd.ActionFilters;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace com.ds201625.fonda.BackEnd.Controllers
{
    [RoutePrefix("api")]
    public class CategoryFilterFondaWebApiController : FondaWebApi
    {
        public CategoryFilterFondaWebApiController() : base() { }

        [Route("categoryFilter")]
        [HttpGet]
        public IHttpActionResult getCategoryFilter()
        {
            /// <summary>
            /// Llamar al metodo mediante la interfaz
            /// para listar todas las categorias y devolverlo al ws
            /// </summary>
            /// <returns></returns>
            IRestaurantCategoryDAO categoryDAO = FactoryDAO.GetRestaurantCategoryDAO();
            

            IList<RestaurantCategory> listCategory = categoryDAO.GetAll();


            return Ok(listCategory);


         }
    }
}
