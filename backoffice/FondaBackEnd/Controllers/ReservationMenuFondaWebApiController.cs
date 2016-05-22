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
    public class ReservationMenuFondaWebApiController : FondaWebApi
    {
        public ReservationMenuFondaWebApiController() : base() { }

        [Route("menuCategory")]
        [HttpGet]
        public IHttpActionResult getMenuCategory(Restaurant restaurant)
        {
            /// <summary>
            /// Llamar al metodo mediante la interfaz
            /// para listar todas las categorias y devolverlo al ws
            /// </summary>
            /// <returns></returns>

            IMenuCategoryDAO menuDao = FactoryDAO.GetMenuCategoryDAO();


            IList<MenuCategory> listCategory = menuDao.GetAll();


            return Ok(listCategory);


        }


        //[Route("dishes")]
        //[HttpGet]
        //public IHttpActionResult getDish(MenuCategory category)
        //{
        //    /// <summary>
        //    /// Llamar al metodo mediante la interfaz
        //    /// para listar todas las categorias y devolverlo al ws
        //    /// </summary>
        //    /// <returns></returns>
        //    IDishDAO dishDao = FactoryDAO.GetDishDAO();

        //    Dish dish = new Dish();
            
        //    IList<Dish> listDish = dishDao.FindById(dish.Id);


        //    return Ok(listDish);


        //}
    }
}
