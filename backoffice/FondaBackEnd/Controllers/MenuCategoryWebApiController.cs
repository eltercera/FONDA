using System;
using System.Web.Http;
using com.ds201625.fonda.Domain;
using System.Collections.Generic;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.BackEnd.ActionFilters;
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

        /// <summary>
        /// Llamar al metodo mediante la interfaz 
        /// para listar las categorias del menu y 
        /// devolverlo al web service
        /// </summary>
        /// <returns>La lista de categorias</returns>
        [Route("menuCategory")]
        [HttpGet]
        [FondaAuthToken]
        public IHttpActionResult getMenuCategory()
        {
            IMenuCategoryDAO catmenuDAO = FactoryDAO.GetMenuCategoryDAO();
            IList<MenuCategory> _listMenCat = catmenuDAO.GetAll();
            return Ok(_listMenCat);

        }


    }
}