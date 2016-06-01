using System;
using com.ds201625.fonda.Domain;
using System.Net;
using System.Web.Http;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.DataAccess.Exceptions;

namespace com.ds201625.fonda.BackEnd.Controllers
{
	[RoutePrefix("api")]
	/// <summary>
	/// Commensal web API controller.
	/// </summary>
	public class CommensalWebApiController : FondaWebApi
	{
		public CommensalWebApiController () { }


		[HttpPost]
		[Route("commensal")]
		/// <summary>
		/// Posts de un commensal.
		/// </summary>
		/// <returns>El commensal.</returns>
		/// <param name="commensal">Commensal creado.</param>
		public IHttpActionResult PostCommensal(Commensal commensal)
		{
			Logger.Debug ("Inicio de solicitud de creacion de Commensa (" + commensal + ")");
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

		/// <summary>
		/// Obtinene el DAO necesario.
		/// </summary>
		/// <returns>The commensal DAO.</returns>
		private ICommensalDAO GetCommensalDao()
		{
			return FactoryDAO.GetCommensalDAO ();
		}

	}
}

