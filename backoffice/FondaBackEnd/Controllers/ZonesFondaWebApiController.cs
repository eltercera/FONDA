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
	public class ZonesFondaWebApiController : FondaWebApi
	{
		public ZonesFondaWebApiController () { }

		[Route("zones")]
		[HttpGet]
		public IHttpActionResult GetZones([FromUri] UrlFilters.UrlFilters filters)
		{
			IZoneDAO zoneDao = FactoryDAO.Intance.GetZoneDAO ();

			IList<Zone> zones;

			if (filters == null)
				zones = zoneDao.FindAllLikeName ();
			else
				zones = zoneDao.FindAllLikeName (filters.Q, filters.Max, filters.Page);

			return Ok (zones);

		}
	}
}

