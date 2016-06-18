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
using com.ds201625.fonda.Factory;
using com.ds201625.fonda.BackEndLogic.Exceptions;


namespace com.ds201625.fonda.BackEndLogic.FavoriteManagement
{
    /// <summary>
    /// Get All Restaurant Command.
    /// </summary>
    class GetAllRestaurantCommand : BaseCommand
    {  
        /// <summary>
        /// constructor obtener todos los restaurant command
        /// </summary>
        public GetAllRestaurantCommand() : base() { }

        /// <summary>
        /// metodo que inicializa los parametros
        /// </summary>
        /// <returns>paramters</returns>
        protected override Parameter[] InitParameters()
        {
            // Requiere 0 Parametros
            Parameter[] paramters = new Parameter[0];
            return paramters;
        }

        /// <summary>
        /// metodo invoke que ejecuta la obtencion de todos los restaurantes
        /// </summary>
		protected override void Invoke()
		{
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceMessages.BeginLogger,System.Reflection.MethodBase.GetCurrentMethod().Name);
            IList<Restaurant> listRestaurant;
			try
			{
                // Obtiene el dao que se requiere
                IRestaurantDAO RestaurantDAO = FacDao.GetRestaurantDAO();
                // Ejecucion del obtener.	
                listRestaurant = (IList<Restaurant>)RestaurantDAO.GetAll();
                foreach (var restaurant in listRestaurant)
                {
                    restaurant.RestaurantCategory = new RestaurantCategory
                    
                    {
                        Name = restaurant.RestaurantCategory.Name,
                        Id = restaurant.RestaurantCategory.Id

                    };
                Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                  ResourceMessages.Restaurant + restaurant.Name + ResourceMessages.Slash +
                  restaurant.RestaurantCategory,System.Reflection.MethodBase.GetCurrentMethod().Name);
                }
                
               
			}
            catch (FindAllFondaDAOException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetAllRestaurantsCommandException(ResourceMessages.GetAllRestaurantException, e);
            }
            catch (InvalidTypeOfParameterException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetAllRestaurantsCommandException(ResourceMessages.ParametersGetAllRestException, e);
            }
            catch (ParameterIndexOutOfRangeException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetAllRestaurantsCommandException(ResourceMessages.ParametersGetAllRestException, e);
            }
            catch (RequieredParameterNotFoundException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetAllRestaurantsCommandException(ResourceMessages.ParametersGetAllRestException, e);
            }
            catch (NullReferenceException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetAllRestaurantsCommandException(ResourceMessages.GetAllRestaurantException, e);
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetAllRestaurantsCommandException(ResourceMessages.GetAllRestaurantException, e);
            }
            
			// Guardar el resultado.
            Result = listRestaurant;
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, 
                Result.ToString(),System.Reflection.MethodBase.GetCurrentMethod().Name);
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceMessages.EndLogger,System.Reflection.MethodBase.GetCurrentMethod().Name);
		}
	}
}