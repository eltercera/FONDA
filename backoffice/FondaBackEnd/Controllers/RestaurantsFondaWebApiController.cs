using System;
using System.Web.Http;
using System.Net.Http;
using com.ds201625.fonda.BackEnd.Controllers.UrlFilters;
using System.Collections.Generic;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.BackEndLogic;
using com.ds201625.fonda.BackEndLogic.Exceptions;

namespace com.ds201625.fonda.BackEnd.Controllers
{

	[RoutePrefix("api")]
	/// <summary>
	/// Servicio para obtener una lista de restaurantes filtrada
	/// </summary>
	public class RestaurantsFondaWebApiController : FondaWebApi
	{
		public RestaurantsFondaWebApiController ()
		{
		}

		[Route("restaurants")]
		[HttpGet]
		/// <summary>
		/// GET /api/restaurnats?q=busqueda&max=10&page=5&zone=16&category=59
		/// Filtros:
		/// q -> patron de busqueda.
		/// max -> numero de resultados maximos.
		/// page -> numero de pafina del resultado.
		/// zone -> id de zona al filtrar.
		/// category -> id de categoria a filtrar.
		/// </summary>
		/// <returns>Lista de restaurantes.</returns>
		/// <param name="filters">Filtros.</param>
		public IHttpActionResult GetRestaurants([FromUri] RestaurantsUrlFilters filters)
		{

			ICommand cmd = FacCommand.CreateGetRestaurantsCommand ();
			if ( filters != null)
			{
				try
				{
					cmd.SetParameter(0, filters.Q);
					cmd.SetParameter(1, filters.Zone);
					cmd.SetParameter(2, filters.Category);
					cmd.SetParameter(3, filters.Max);
					cmd.SetParameter(4, filters.Page);
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

			IList<Restaurant> restaurants = (IList<Restaurant>) cmd.Result;


			LogDebug("Retornando Lista de " + restaurants.Count + " Restaurantes.");

			return Ok (restaurants);
		}

	}
}

