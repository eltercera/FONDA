using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.FondaBackEndLogic.Exceptions;
using FondaLogic.Log;
using FondaBeckEndLogic;


namespace com.ds201625.fonda.BackEndLogic.FavoriteManagement
{
    /// <summary>
    /// Get Favorite Restaurant Command.
    /// </summary>
    class GetFavoriteRestaurantCommand : BaseCommand
    {
        /// <summary>
        /// constructor obtener Favorite restaurant command
        /// </summary>
        public GetFavoriteRestaurantCommand() : base() { }

        /// <summary>
        /// metodo que inicializa los parametros
        /// </summary>
        /// <returns>paramters</returns>
		protected override Parameter[] InitParameters ()
		{
            // Requiere 1 Parametros
            Parameter[] paramters = new Parameter[1];

            // [0] El Commensal
            paramters[0] = new Parameter(typeof(Commensal), true);

            return paramters;
		}

        /// <summary>
        /// metodo invoke que ejecuta el buscar restaurant favoritos de un comensal
        /// </summary>
		protected override void Invoke()
		{
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceMessages.BeginLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            Commensal favorites;
            // Obtencion de parametros
            Commensal commensal = (Commensal)GetParameter(0);
            // Obtiene el dao que se requiere
            ICommensalDAO commensalDAO = FacDao.GetCommensalDAO();

            if ((commensal.Id < 0) || (commensal.Id == 0))
                throw new Exception(ResourceMessages.InvalidInformation);

          // Ejecucion del Buscar.		
			try
			{
                favorites = (Commensal)commensalDAO.FindById(commensal.Id);//PREGUNTAR POR SI PUEDO HACER COMENSAL.ID
                foreach (var restaurant in favorites.FavoritesRestaurants) //PREGUNTAR POR EL NEW RESTAURANT
                {
                    restaurant.RestaurantCategory = new RestaurantCategory
                    {
                        Name = restaurant.RestaurantCategory.Name,
                        Id = restaurant.RestaurantCategory.Id
                    };
                    Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                  ResourceMessages.FavoriteRestaurant + restaurant.Name + ResourceMessages.Slash + favorites.Email,
                 System.Reflection.MethodBase.GetCurrentMethod().Name);
                }
			}
            catch (FindByIdFondaDAOException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetFavoriteRestaurantFondaCommandException(ResourceMessages.GetFavoriteRestaurant, e);
            }
            catch (NullReferenceException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetFavoriteRestaurantFondaCommandException(ResourceMessages.GetFavoriteRestaurant, e);
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetFavoriteRestaurantFondaCommandException(ResourceMessages.GetFavoriteRestaurant, e);
            }
            // Guardar el resultado.
            Result = favorites;
            //logger
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, 
                Result.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceMessages.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
		}
	}
}