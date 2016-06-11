using System;
using System.Web.Http;
using System.Net.Http;
using com.ds201625.fonda.BackEnd.Controllers.UrlFilters;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System.Collections.Generic;
using com.ds201625.fonda.Domain;

namespace com.ds201625.fonda.BackEnd.Controllers
{

	[RoutePrefix("api")]
	public class RestaurantsFondaWebApiController : FondaWebApi
	{
		public RestaurantsFondaWebApiController ()
		{
		}

		[Route("restaurants")]
		[HttpGet]
		public IHttpActionResult GetRestaurants([FromUri] RestaurantsUrlFilters filters)
		{

			IRestaurantDAO dao = FactoryDAO.GetRestaurantDAO ();

			IList<Restaurant> restaurants;

			if (filters == null)
				restaurants = dao.FindByFilters ();
			else
				restaurants = dao.FindByFilters (
					filters.Q, filters.Zone, filters.Category, filters.Max, filters.Page);

			return Ok (restaurants);
		}

	}
}

