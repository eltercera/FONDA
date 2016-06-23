using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.FondaBackEndLogic.Exceptions;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using FondaBeckEndLogic;
using com.ds201625.fonda.BackEndLogic.Exceptions;


namespace com.ds201625.fonda.BackEndLogic.FavoriteManagement
{
    /// <summary>
    /// Get Favorite Restaurant Command.
    /// </summary>
    class GetFavoriteRestaurantCommand : BaseCommand
    {
        private Commensal favorites;
        private Commensal commensal;
        private ICommensalDAO commensalDAO;

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
            
            // Obtencion de parametros
            commensal = (Commensal)GetParameter(0);
            // Obtiene el dao que se requiere
            commensalDAO = FacDao.GetCommensalDAO();

            if (commensal.Id <= 0)
                throw new Exception(ResourceMessages.InvalidInformation);

          // Ejecucion del Buscar.		
			try
			{
                favorites = (Commensal)commensalDAO.FindById(commensal.Id);//PREGUNTAR POR SI PUEDO HACER COMENSAL.ID
                foreach (var restaurant in favorites.FavoritesRestaurants) 
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
            catch (InvalidTypeOfParameterException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetFavoriteRestaurantFondaCommandException(ResourceMessages.ParametersGetFavRestException, e);
            }
            catch (ParameterIndexOutOfRangeException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetFavoriteRestaurantFondaCommandException(ResourceMessages.ParametersGetFavRestException, e);
            }
            catch (RequieredParameterNotFoundException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetFavoriteRestaurantFondaCommandException(ResourceMessages.ParametersGetFavRestException, e);
            }
            catch (FindByIdFondaDAOException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetFavoriteRestaurantFondaCommandException(ResourceMessages.GetFavoriteRestaurantException, e);
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetFavoriteRestaurantFondaCommandException(ResourceMessages.GetFavoriteRestaurantException, e);
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