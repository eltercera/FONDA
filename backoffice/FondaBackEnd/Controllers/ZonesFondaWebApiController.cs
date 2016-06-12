using System;
using System.Web.Http;
using System.Net.Http;
using System.Collections.Generic;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.BackEndLogic;
using com.ds201625.fonda.BackEndLogic.Exceptions;

namespace com.ds201625.fonda.BackEnd.Controllers
{
	[RoutePrefix("api")]
	/// <summary>
	/// Servicio para obtener una lista de zonas
	/// </summary>
	public class ZonesFondaWebApiController : FondaWebApi
	{
		public ZonesFondaWebApiController () { }

		[Route("zones")]
		[HttpGet]
		/// <summary>
		/// GET /api/zones?q=busqueda&max=10&page=5
		/// Filtros:
		/// q -> patron de busqueda.
		/// max -> numero de resultados maximos.
		/// page -> numero de pafina del resultado.
		/// </summary>
		/// <returns>Lista de zonas.</returns>
		/// <param name="filters">Filtros.</param>
		public IHttpActionResult GetZones([FromUri] UrlFilters.UrlFilters filters)
		{
			ICommand cmd = FacCommand.CreateGetZonesCommand ();
			if ( filters != null)
			{
				try
				{
					cmd.SetParameter(0, filters.Q);
					cmd.SetParameter(1, filters.Max);
					cmd.SetParameter(2, filters.Page);
				} 
				catch (ParameterIndexOutOfRangeException e)
				{
					LogException (e);
					return InternalServerError (e);
				}
				catch (InvalidTypeOfParameterException e)
				{
					LogException (e);
					return InternalServerError (e);
				}
				catch (Exception e)
				{
					LogException (e, "Error desconocido");
					return InternalServerError (e);
				}
			}

			try 
			{
				cmd.Run();
			}
			catch (FondaBackendLogicException e)
			{
				LogException (e);
				return InternalServerError (e);
			}
			catch (Exception e)
			{
				LogException (e, "Error desconocido");
				return InternalServerError (e);
			}

			IList<Zone> zones = (IList<Zone>) cmd.Result;


			LogDebug("Retornando Lista de " + zones.Count + " zonas.");

			return Ok (zones);
		}
	}
}

