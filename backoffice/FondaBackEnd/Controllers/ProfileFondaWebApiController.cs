using System;
using System.Web.Http;
using System.Linq;
using System.Collections;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.BackEnd.ActionFilters;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;

namespace com.ds201625.fonda.BackEnd.Controllers
{
	[RoutePrefix("api")]
	public class ProfileFondaWebApiController : FondaWebApi
	{
		public ProfileFondaWebApiController () : base () {}

		[Route("profiles")]
		[HttpGet]
		[FondaAuthToken]
		public IHttpActionResult getProfiles()
		{
			Commensal commensal = GetCommensal (Request.Headers);
			if (commensal == null)
				return BadRequest ();

			return Ok(commensal.Profiles);
		}

	}
}

