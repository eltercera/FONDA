using System;
using com.ds201625.fonda.Domain;
using System.Net;
using System.Web.Http;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.DataAccess.Exceptions;

namespace com.ds201625.fonda.BackEnd.Controllers
{
	[RoutePrefix("api")]
	public class CommensalWebApiController : FondaWebApi
	{
		public CommensalWebApiController () { }


		[HttpPost]
		[Route("commensal")]
		public IHttpActionResult PostCommensal(Commensal commensal)
		{
			Console.WriteLine ("..................");

			if (commensal == null | commensal.Id != 0)
				throw new HttpResponseException (HttpStatusCode.BadRequest);

			ICommensalDAO commensalDao = GetCommensalDao ();
			try
			{
				commensalDao.Save (commensal);
			}
			catch (SaveEntityFondaDAOException e)
			{
				Console.WriteLine (e.ToString ());
				return InternalServerError (e);
			}

			return Created ("",commensal);
		}

		private ICommensalDAO GetCommensalDao()
		{
			return FactoryDAO.GetCommensalDAO ();
		}

	}
}

