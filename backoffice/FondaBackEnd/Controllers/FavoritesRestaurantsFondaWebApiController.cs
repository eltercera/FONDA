using com.ds201625.fonda.BackEnd.ActionFilters;
using com.ds201625.fonda.BackEnd.Log;
using com.ds201625.fonda.BackEndLogic;
using com.ds201625.fonda.BackEndLogic.Exceptions;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Factory;
using com.ds201625.fonda.FondaBackEnd.Exceptions;
using com.ds201625.fonda.FondaBackEndLogic.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace com.ds201625.fonda.BackEnd.Controllers
{
    [RoutePrefix("api")]

    /// <summary>
    /// favorites restaurants fonda web API controller.
    /// </summary>
    public class FavoritesRestaurantsFondaWebApiController : FondaWebApi
    {
        /// <summary>
        /// constructor de restaurant favoritos fonda web API controller.
        /// </summary>
        public FavoritesRestaurantsFondaWebApiController() : base() { }

        /// <summary>
        /// elimina un restaurante de la lista de favoritos de un
        /// commensal, recibe id int del restaurant a agregar,
        /// retorna lista de favoritos actualizada
        /// </summary>
        /// <param name="idCommensal"></param>
        /// <param name="idRestaurant"></param>
        /// <returns></returns>
        
        [Route("deletefavorite/{idCommensal}/{idRestaurant}")]
        [HttpGet]
        //[FondaAuthToken]
        public IHttpActionResult deletefavorite(int idcommensal, int idrestaurant)
        {
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                GeneralRes.BeginLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            
            Commensal result;   //PREGUNTAR SI ES PRIVADA O CUANDO SON STATIC
            try
            {
                Commensal commensal = EntityFactory.GetCommensal();
                commensal.Id = idcommensal;                     

                //Creación del restaurant con id
                Restaurant restaurant = new Restaurant();  
                restaurant.Id = idrestaurant;                    

                // Obtención del commando
                ICommand command = FacCommand.DeleteFavoriteRestaurantCommand();

                // Agregacion de parametros
                command.SetParameter(0, commensal);
                command.SetParameter(1, restaurant);

                // Ejecucion del commando
                command.Run();

                // Obtención de respuesta
                result = (Commensal)command.Result;
                Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    GeneralRes.RestDeletedFromFav + commensal.Id + GeneralRes.Slash + restaurant.Name,
                   System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (DeleteFavoriteRestaurantCommandException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new DeleteFavoriteRestaurantFondaWebApiControllerException(GeneralRes.DeleteFavRestException, e);
             
            }
            catch (InvalidTypeOfParameterException e)
            {
                // Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new DeleteFavoriteRestaurantFondaWebApiControllerException("Parametros ivalidos al intentar eliminar" +
                    "un restarant favorito", e);
            }
            catch (ParameterIndexOutOfRangeException e)
            {
                // Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new DeleteFavoriteRestaurantFondaWebApiControllerException("Parametros fuera de rango al intentar eliminar" +
                    "un restarant favorito", e);
            }
            catch (RequieredParameterNotFoundException e)
            {
                // Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new DeleteFavoriteRestaurantFondaWebApiControllerException("Se requieren parametros para eliminar" +
                    "un restaurant favorito", e);
            }
            catch (NullReferenceException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new DeleteFavoriteRestaurantFondaWebApiControllerException(GeneralRes.DeleteFavRestException, e);
            }
            catch (Exception e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new DeleteFavoriteRestaurantFondaWebApiControllerException(GeneralRes.DeleteFavRestException, e);
            }
            
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, 
                GeneralRes.EndLogger,System.Reflection.MethodBase.GetCurrentMethod().Name);

            return Ok(result);
        }

        /// <summary>
        /// metodo que agrega un restaurant favorito de un comensal
        /// </summary>
        /// <param name="idCommensal"></param>
        /// <param name="idRestaurant"></param>
        /// <returns></returns>

        [Route("addfavorite/{idCommensal}/{idRestaurant}")]
        [HttpGet]
        ///[FondaAuthToken]
        public IHttpActionResult addfavorite(int idcommensal, int idrestaurant)
        {
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, 
                GeneralRes.BeginLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            
            Commensal result;
            try
            {
                //Creación del commensal con id
                Commensal commensal = EntityFactory.GetCommensal();
                commensal.Id = idcommensal;                      

                //Creación del restaurant con id
                Restaurant restaurant = EntityFactory.GetRestaurant();
                restaurant.Id = idrestaurant;                      

                // Obtención del commando
                ICommand command = FacCommand.CreateFavoriteRestaurantCommand();

                // Agregacion de parametros
                command.SetParameter(0, commensal);
                command.SetParameter(1, restaurant);

                // Ejecucion del commando
                command.Run();

                // Obtención de respuesta
                result = (Commensal)command.Result;

                Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   GeneralRes.RestAddedToFav + commensal.Id + GeneralRes.Slash + restaurant.Name,
                  System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (CreateFavoriteRestaurantCommandException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new AddFavoriteRestaurantFondaWebApiControllerException(GeneralRes.AddFavRestException, e);
            }
            catch (InvalidTypeOfParameterException e)
            {
                // Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new AddFavoriteRestaurantFondaWebApiControllerException("Parametros ivalidos al intentar crear" +
                    "un restarant favorito", e);
            }
            catch (ParameterIndexOutOfRangeException e)
            {
                // Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new AddFavoriteRestaurantFondaWebApiControllerException("Parametros fuera de rango al intentar crear" +
                    "un restarant favorito", e);
            }
            catch (RequieredParameterNotFoundException e)
            {
                // Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new AddFavoriteRestaurantFondaWebApiControllerException("Se requieren parametros para crear" +
                    "un restaurant favorito", e);
            }
            catch (NullReferenceException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new AddFavoriteRestaurantFondaWebApiControllerException(GeneralRes.AddFavRestException, e);
            }
            catch (Exception e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new AddFavoriteRestaurantFondaWebApiControllerException(GeneralRes.AddFavRestException, e);
            }
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, 
                GeneralRes.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return Ok(result);
        }

        /// <summary>
        /// metodo que lista todos los restaurant
        /// </summary>
        /// <returns></returns>
       
        [Route("ListaRestaurant")]
        [HttpGet]
        public IHttpActionResult getRestaurant()
        {
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                GeneralRes.BeginLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            
            IList<Restaurant> result;
            try
            {
                // Obtención del commando
                ICommand command = FacCommand.GetAllRestaurantCommand();
                // Ejecucion del commando
                command.Run();
                result = (IList<Restaurant>)command.Result;

                Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                 GeneralRes.Restaurant,System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (GetAllRestaurantsCommandException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetAllRestaurantsFondaWebApiControllerException(GeneralRes.GetRestFavException, e);
            }
            catch (InvalidTypeOfParameterException e)
            {
                // Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetAllRestaurantsFondaWebApiControllerException("Parametros ivalidos al intentar obtener" +
                    "los restaurantes disponibles", e);
            }
            catch (ParameterIndexOutOfRangeException e)
            {
                // Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetAllRestaurantsFondaWebApiControllerException("Parametros fuera de rango al intentar crear" +
                    "los restaurantes disponibles", e);
            }
            catch (RequieredParameterNotFoundException e)
            {
                // Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetAllRestaurantsFondaWebApiControllerException("Se requieren parametros para crear" +
                    "los restaurantes disponibles", e);
            }
            catch (NullReferenceException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetAllRestaurantsFondaWebApiControllerException(GeneralRes.GetRestFavException, e);
            }
            catch (Exception e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetAllRestaurantsFondaWebApiControllerException(GeneralRes.GetRestFavException, e);
            }
           
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, 
                GeneralRes.EndLogger,System.Reflection.MethodBase.GetCurrentMethod().Name);

            return Ok(result);
           
        }


        private IRestaurantDAO GetRestaurantDao()   //ESTO NO SE DEBERIA QUITAR

        {
            return FactoryDAO.GetRestaurantDAO();
        }
        private ICommensalDAO GetCommensalDao()
        {
            return FactoryDAO.GetCommensalDAO();
        }

        /// <summary>
        /// metodo que lista los restaurant favoritos de un commensal
        /// </summary>
        /// <param name="idCommensal"></param>
        /// <returns></returns>
        
        [Route("findRestaurantFavorites/{idCommensal}")]
        [HttpGet]
        public IHttpActionResult findRestaurantFavorites(int idCommensal)
        {
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, 
                GeneralRes.BeginLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            
            Commensal result;
            try
            {
                //Creación del commensal con id
                Commensal commensal = EntityFactory.GetCommensal();  
                commensal.Id = idCommensal;                      

                // Obtención del commando
                ICommand command = FacCommand.GetFavoriteRestaurantCommand();

                // Agregacion de parametros
                command.SetParameter(0, commensal);

                // Ejecucion del commando
                command.Run();

                // Obtención de respuesta
                result = (Commensal)command.Result;

                Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                 GeneralRes.FavoriteRestaurant + commensal.Email,
                System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (GetFavoriteRestaurantFondaCommandException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new FindFavoriteRestaurantFondaWebApiControllerException(GeneralRes.GetFavoriteRestaurant, e);
                
            }
            catch (InvalidTypeOfParameterException e)
            {
                // Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new FindFavoriteRestaurantFondaWebApiControllerException("Parametros ivalidos al intentar obtener" +
                    "los restaurantes favorito de un commensal", e);
            }
            catch (ParameterIndexOutOfRangeException e)
            {
                // Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new FindFavoriteRestaurantFondaWebApiControllerException("Parametros fuera de rango al intentar obtener" +
                    "los restaurantes favorito de un commensal", e);
            }
            catch (RequieredParameterNotFoundException e)
            {
                // Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new FindFavoriteRestaurantFondaWebApiControllerException("Se requieren parametros para obtener" +
                    "los restaurantes favorito de un commensal", e);
            }
            catch (NullReferenceException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new FindFavoriteRestaurantFondaWebApiControllerException(GeneralRes.GetFavoriteRestaurant, e);
            }
            catch (Exception e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new FindFavoriteRestaurantFondaWebApiControllerException(GeneralRes.GetFavoriteRestaurant, e);
            }                 

          Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, 
              GeneralRes.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

          return Ok(result.FavoritesRestaurants);
        }

        /// <summary>
        /// metodo que busca la existencia de un commensal
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>

        [Route("findCommensalEmail/{email}")]
        [HttpGet]
        public IHttpActionResult findCommensalEmail(string email)
        {
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                GeneralRes.BeginLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
             
            UserAccount result;
            try
            {
                UserAccount commensal = EntityFactory.GetUserAccount();
                commensal.Email = email;
                // Obtención del commando
                ICommand command = FacCommand.GetCommensalEmailCommand();
                // Agregacion de parametros
                command.SetParameter(0, commensal);

                // Ejecucion del commando
                command.Run();

                // Obtención de respuesta
                result = (UserAccount)command.Result;

                Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                GeneralRes.CommensalEmail + commensal.Email, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (GetCommensalEmailCommandException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new FindByEmailUserAccountFondaWebApiControllerException(GeneralRes.GetCommensalEmailException,
                    e);
            }
            catch (InvalidTypeOfParameterException e)
            {
                // Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new FindByEmailUserAccountFondaWebApiControllerException("Parametros ivalidos al intentar obtener" +
                    "el email de un commensal", e);
            }
            catch (ParameterIndexOutOfRangeException e)
            {
                // Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new FindByEmailUserAccountFondaWebApiControllerException("Parametros fuera de rango al intentar obtener" +
                    "el email de un commensal", e);
            }
            catch (RequieredParameterNotFoundException e)
            {
                // Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new FindByEmailUserAccountFondaWebApiControllerException("Se requieren parametros para obtener" +
                    "el email de un commensal", e);
            }
            catch (NullReferenceException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new FindByEmailUserAccountFondaWebApiControllerException(GeneralRes.GetCommensalEmailException, 
                    e);
            }
            catch (Exception e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new FindByEmailUserAccountFondaWebApiControllerException(GeneralRes.GetCommensalEmailException,
                    e);
            }

            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, 
                GeneralRes.EndLogger,System.Reflection.MethodBase.GetCurrentMethod().Name);

            return Ok(result);
        }
    }
}