using System;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System.Collections.Generic;
using com.ds201625.fonda.BackEndLogic.Exceptions;

namespace com.ds201625.fonda.BackEndLogic
{
	/// <summary>
	/// Comando para obtener una lista de restaurantes
	/// </summary>
	public class GetRestaurantsCommand : BaseCommand
	{
		public GetRestaurantsCommand () : base ()
		{ }

		/// <summary>
		/// Inicializa los parametros.
		/// </summary>
		/// <returns>Los parametros.</returns>
		protected override Parameter[] InitParameters ()
		{
			// recive 3 parametros
			Parameter[] parameter = new Parameter[5];

			// [0] String de busqueda.
			parameter [0] = new Parameter (typeof(string), false);

			// [1] Id de la zona
			parameter [1] = new Parameter (typeof(int), false);

			// [1] Id de la categoria de restaurant
			parameter [2] = new Parameter (typeof(int), false);

			// [1] limite de resultados.
			parameter [3] = new Parameter (typeof(int), false);

			// [2] Pagina de resultados.
			parameter [4] = new Parameter (typeof(int), false);

			return parameter;
		}

		/// <summary>
		/// Ejecucion del parametro.
		/// </summary>
		protected override void Invoke()
		{
			string q = (string) GetParameter (0);
			int max = -1;
			int page = 1;
			int idZone = 0;
			int idRestCat = 0;

			if (GetParameter (1) != null)
				idZone = (int) GetParameter (1);
			if (GetParameter (2) != null)
				idRestCat = (int) GetParameter (2);
			if (GetParameter (3) != null)
				max = (int) GetParameter (3);
			if (GetParameter (4) != null)
				page = (int) GetParameter (4);

			IRestaurantDAO restDao = FacDao.GetRestaurantDAO ();

			IList<Restaurant> restaurants = null;

			try {
				restaurants = restDao.FindByFilters (q, idZone, idRestCat, max, page);
			} 
			catch (Exception e)
			{
				throw new FondaBackendLogicException ("Error al obtener lista de Restaurantes", e);
			}

			Result = restaurants;
		}
	}
}

