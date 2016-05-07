using System;
using System.Web.Http;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.BackEnd.ActionFilters;

namespace com.ds201625.fonda.BackEnd.Controllers
{
	[RoutePrefix("api/token")]
	public class TokenFondaWebApiController : ApiController
	{
		public TokenFondaWebApiController () : base () {}

		[FondaAuthToken]
		[Route]
		[HttpGet]
		public Token getToken()
		{
			return null;
		}

	}
}

