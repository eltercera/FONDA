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
using System.Net;
using System.Web.Http;

namespace com.ds201625.fonda.BackEnd.Controllers
{   
    [RoutePrefix("api")]

    /// <summary>
    /// favorites restaurants fonda web API controller.
    /// </summary>
    public class FavoritesRestaurantsFondaWebApiController : FondaWebApi
    {
        private Commensal commensal;
        private Restaurant restaurant;
        private ICommand command;

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
        /// <returns>result</returns>
        
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
                
                commensal = EntityFactory.GetCommensal();
                commensal.Id = idcommensal;                     

                //Creación del restaurant con id
                restaurant = EntityFactory.GetRestaurant();
                restaurant.Id = idrestaurant;                    

                // Obtención del commando
                command = FacCommand.DeleteFavoriteRestaurantCommand();

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
                DeleteFavoriteRestaurantFondaWebApiControllerException error = new DeleteFavoriteRestaurantFondaWebApiControllerException(GeneralRes.DeleteFavRestException, e);
                return InternalServerError(error);
            }
            catch (NullReferenceException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                DeleteFavoriteRestaurantFondaWebApiControllerException error = new DeleteFavoriteRestaurantFondaWebApiControllerException(GeneralRes.DeleteFavRestException, e);
                return InternalServerError(error);
            }
            catch (Exception e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                DeleteFavoriteRestaurantFondaWebApiControllerException error = new DeleteFavoriteRestaurantFondaWebApiControllerException(GeneralRes.DeleteFavRestException, e);
                return InternalServerError(error);
            }

            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                result.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, 
                GeneralRes.EndLogger,System.Reflection.MethodBase.GetCurrentMethod().Name);

            return Ok(result);
        }

        /// <summary>
        /// metodo que agrega un restaurant favorito de un comensal
        /// </summary>
        /// <param name="idCommensal"></param>
        /// <param name="idRestaurant"></param>
        /// <returns>result</returns>

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
                if (idcommensal == 13)
                {
                    throw new AddFavoriteRestaurantFondaWebApiControllerException("Error al refistrar"+GeneralRes.AddFavRestException);
                }
                //Creación del commensal con id
                commensal = EntityFactory.GetCommensal();
                commensal.Id = idcommensal;                      

                //Creación del restaurant con id
                restaurant = EntityFactory.GetRestaurant();
                restaurant.Id = idrestaurant;                      

                // Obtención del commando
                command = FacCommand.CreateFavoriteRestaurantCommand();

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
                AddFavoriteRestaurantFondaWebApiControllerException error = new AddFavoriteRestaurantFondaWebApiControllerException(GeneralRes.AddFavRestException, e); 
                return InternalServerError(error);
            }
            catch (NullReferenceException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                AddFavoriteRestaurantFondaWebApiControllerException error = new AddFavoriteRestaurantFondaWebApiControllerException(GeneralRes.AddFavRestException, e);
                return InternalServerError(error);
            }
            catch (Exception e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                AddFavoriteRestaurantFondaWebApiControllerException error = new AddFavoriteRestaurantFondaWebApiControllerException(GeneralRes.AddFavRestException, e);
                return InternalServerError(error);
            }

            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                result.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, 
                GeneralRes.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return Ok(result);
        }

        /// <summary>
        /// metodo que lista todos los restaurant
        /// </summary>
        /// <returns>result</returns>
       
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
                command = FacCommand.GetAllRestaurantCommand();
                // Ejecucion del commando
                command.Run();
                result = (IList<Restaurant>)command.Result;

                Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                 GeneralRes.Restaurant,System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (GetAllRestaurantsCommandException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                GetAllRestaurantsFondaWebApiControllerException error = new GetAllRestaurantsFondaWebApiControllerException(GeneralRes.GetAllRestaurantsException, e);
                return InternalServerError(error);
            }
            catch (NullReferenceException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                GetAllRestaurantsFondaWebApiControllerException error = new GetAllRestaurantsFondaWebApiControllerException(GeneralRes.GetAllRestaurantsException, e);
                return InternalServerError(error);
            }
            catch (Exception e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                GetAllRestaurantsFondaWebApiControllerException error = new GetAllRestaurantsFondaWebApiControllerException(GeneralRes.GetAllRestaurantsException, e);
                return InternalServerError(error);
            }

            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                result.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, 
                GeneralRes.EndLogger,System.Reflection.MethodBase.GetCurrentMethod().Name);

            return Ok(result);
           
        }

        /// <summary>
        /// metodo que lista los restaurant favoritos de un commensal
        /// </summary>
        /// <param name="idCommensal"></param>
        /// <returns>result.FavoritesRestaurants</returns>
        
        [Route("findRestaurantFavorites/{idCommensal}")]
        [HttpGet]
        public IHttpActionResult findRestaurantFavorites(int idCommensal)
        {
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, 
                GeneralRes.BeginLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            
            Commensal result;
            try
            {
                if (idCommensal == 13)
                {
                //Creación del commensal con id
                   throw new  FindFavoriteRestaurantFondaWebApiControllerException("Error al consultar favoritos"+GeneralRes.GetFavoriteRestaurantException);
                }
                //Creación del commensal con id
                commensal = EntityFactory.GetCommensal();  
                commensal.Id = idCommensal;                      

                // Obtención del commando
                 command = FacCommand.GetFavoriteRestaurantCommand();

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
               FindFavoriteRestaurantFondaWebApiControllerException error = new FindFavoriteRestaurantFondaWebApiControllerException(GeneralRes.GetFavoriteRestaurantException, e);
               return InternalServerError(error);    
            }
            catch (NullReferenceException e)
            {
               Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
               FindFavoriteRestaurantFondaWebApiControllerException error = new FindFavoriteRestaurantFondaWebApiControllerException(GeneralRes.GetFavoriteRestaurantException, e);
               return InternalServerError(error);
            }
            catch (Exception e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                FindFavoriteRestaurantFondaWebApiControllerException error = (FindFavoriteRestaurantFondaWebApiControllerException)e;
                return InternalServerError(error);    
            }

          Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                result.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
          Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, 
              GeneralRes.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

          return Ok(result.FavoritesRestaurants);
        }

        /// <summary>
        /// metodo que busca la existencia de un commensal
        /// </summary>
        /// <param name="email"></param>
        /// <returns>result</returns>

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
                command = FacCommand.GetCommensalEmailCommand();
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
                FindByEmailUserAccountFondaWebApiControllerException error = new FindByEmailUserAccountFondaWebApiControllerException(GeneralRes.GetCommensalEmailException, e);
                return InternalServerError(error);   
            }
            catch (NullReferenceException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                FindByEmailUserAccountFondaWebApiControllerException error = new FindByEmailUserAccountFondaWebApiControllerException(GeneralRes.GetCommensalEmailException, e);
                return InternalServerError(error);
            }
            catch (Exception e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                FindByEmailUserAccountFondaWebApiControllerException error = new FindByEmailUserAccountFondaWebApiControllerException(e.StackTrace);
                return InternalServerError(error);
            }

            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                result.ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, 
                GeneralRes.EndLogger,System.Reflection.MethodBase.GetCurrentMethod().Name);

            return Ok(result);
        }
    }
}