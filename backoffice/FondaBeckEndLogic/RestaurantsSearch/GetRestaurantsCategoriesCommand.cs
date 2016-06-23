using System;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System.Collections.Generic;
using com.ds201625.fonda.BackEndLogic.Exceptions;

namespace com.ds201625.fonda.BackEndLogic
{
	/// <summary>
	/// Comando para obtener las categorias activas
	/// con almenos un restaurant
	/// </summary>
	public class GetRestaurantsCategoriesCommand : BaseCommand
	{
		public GetRestaurantsCategoriesCommand () : base ()
		{ }

		/// <summary>
		/// Inicializa los parametros.
		/// </summary>
		/// <returns>Los parametros.</returns>
		protected override Parameter[] InitParameters ()
		{
			// recive 3 parametros
			Parameter[] parameter = new Parameter[3];

			// [0] String de busqueda.
			parameter [0] = new Parameter (typeof(string), false);

			// [1] limite de resultados.
			parameter [1] = new Parameter (typeof(int), false);

			// [2] Pagina de resultados.
			parameter [2] = new Parameter (typeof(int), false);

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

			if (GetParameter (1) != null)
				max = (int) GetParameter (1);
			if (GetParameter (2) != null)
				page = (int) GetParameter (2);

			IRestaurantCategoryDAO rcdao = FacDao.GetRestaurantCategoryDAO ();

			IList<RestaurantCategory> resCats = null;

			try {
				resCats = rcdao.FindAllWithRestaurants (q, max, page);
			} 
			catch (Exception e)
			{
				throw new FondaBackendLogicException (
					"Error al obtener lista de catogorias deRestaurantes", e);
			}

			Result = resCats;
		}
	}
}

