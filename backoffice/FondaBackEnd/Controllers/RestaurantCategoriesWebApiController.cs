using System;
using System.Web.Http;
using System.Net.Http;
using System.Collections.Generic;
using com.ds201625.fonda.BackEndLogic;
using com.ds201625.fonda.BackEndLogic.Exceptions;
using com.ds201625.fonda.Domain;

namespace com.ds201625.fonda.BackEnd.Controllers
{
	[RoutePrefix("api")]
	/// <summary>
	/// Servicio para obtener lisra de categorias de restaurantes
	/// </summary>
	public class RestaurantCategoriesWebApiController : FondaWebApi
	{
		public RestaurantCategoriesWebApiController () { }

		[Route("RestaurantsCategories")]
		[HttpGet]
		/// <summary>
		/// GET /api/restaurantscategories?q=busqueda&max=10&page=5
		/// Filtros:
		/// q -> patron de busqueda.
		/// max -> numero de resultados maximos.
		/// page -> numero de pafina del resultado.
		/// </summary>
		/// <returns>Lista de restaurantes.</returns>
		/// <param name="filters">Filtros.</param>
		public IHttpActionResult getRestaurantsCategories([FromUri] UrlFilters.UrlFilters filters)
		{
			ICommand cmd = FacCommand.CreateGetRestaurantsCategoriesCommand ();
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

			IList<RestaurantCategory> resCatList = (IList<RestaurantCategory>) cmd.Result;

			LogDebug("Retornando Lista de " + resCatList.Count + " Categorias de restaurantes.");

			return Ok (resCatList);
			
		}
	}
}

