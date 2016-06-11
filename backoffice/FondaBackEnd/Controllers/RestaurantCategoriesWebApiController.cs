using System;
using System.Web.Http;
using System.Net.Http;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System.Collections.Generic;
using com.ds201625.fonda.Domain;

namespace com.ds201625.fonda.BackEnd.Controllers
{
	[RoutePrefix("api")]
	public class RestaurantCategoriesWebApiController : FondaWebApi
	{
		public RestaurantCategoriesWebApiController () { }

		[Route("RestaurantsCategories")]
		[HttpGet]
		public IHttpActionResult getRestaurantsCategories([FromUri] UrlFilters.UrlFilters filters)
		{
			IRestaurantCategoryDAO resCatDao = FactoryDAO.Intance.GetRestaurantCategoryDAO ();

			IList<RestaurantCategory> categories;

			if (filters == null)
				categories = resCatDao.FindAllLikeName ();
			else
				categories = resCatDao.FindAllLikeName (filters.Q, filters.Max, filters.Page);

			return Ok (categories);
			
		}
	}
}

