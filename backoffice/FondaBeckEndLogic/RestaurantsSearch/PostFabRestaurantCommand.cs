using System;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System.Collections.Generic;
using com.ds201625.fonda.BackEndLogic.Exceptions;

namespace com.ds201625.fonda.BackEndLogic
{
	public class PostFabRestaurantCommand : BaseCommand
	{
		public PostFabRestaurantCommand () : base () { }

		protected override Parameter[] InitParameters ()
		{
			Parameter[] parameter = new Parameter[2];

			// [0] comensal.
			parameter [0] = new Parameter (typeof(Commensal), true);

			// [1] ide del restaurante.
			parameter [1] = new Parameter (typeof(int), true);

			return parameter;
		}

		protected override void Invoke()
		{
			Commensal commensal = (Commensal) GetParameter (0);
			int idRest = (int)GetParameter (1);

			IRestaurantDAO restDao = FacDao.GetRestaurantDAO ();
			ICommensalDAO comDao = FacDao.GetCommensalDAO ();


			Restaurant rest;

			try {
				rest = restDao.FindById (idRest);
			} 
			catch (Exception e)
			{
				throw new FondaBackendLogicException ("Error al obtener lista de zonas", e);
			}

			if (rest == null)
				throw new FondaBackendLogicException ("Id De Restaurante Invalido.");

			commensal.AddFavoriteRestaurant (rest);

			comDao.Save (commensal);

		}

	}

}

