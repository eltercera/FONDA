using System;
using System.Web.Http;
using com.ds201625.fonda.Domain;
using System.Collections.Generic;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System.Web;
using Newtonsoft.Json;
using System.Net;
using com.ds201625.fonda.DataAccess.Exceptions;


namespace com.ds201625.fonda.BackEnd.Controllers
{

    [RoutePrefix("api")]
    public class MenuCategoryWebApiController : FondaWebApi
    {
        public MenuCategoryWebApiController() : base() { }

        [Route("MenuCategory")]

        [HttpGet]

        public IHttpActionResult getMenuCategory(int id)
        {
            IMenuCategoryDAO catmenuDAO = FactoryDAO.GetMenuCategoryDAO();
            IRestaurantDAO restaurantDAO = FactoryDAO.GetRestaurantDAO();
            Restaurant restaurant = restaurantDAO.FindById(id);


            IList<MenuCategory> listMenuC = restaurant.MenuCategories;

            return Ok(listMenuC);

        }


    }
}