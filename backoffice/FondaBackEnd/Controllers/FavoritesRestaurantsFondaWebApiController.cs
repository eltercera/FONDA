using System;
using System.Web.Http;
using System.Linq;
using System.Collections;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.BackEnd.ActionFilters;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.DataAccess.Exceptions;
using System.Collections.Generic;
using com.ds201625.fonda.BackEndLogic;
using com.ds201625.fonda.FondaBackEnd.Exceptions;

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
            Commensal result;   //PREGUNTAR SI ES PRIVADA O CUANDO SON STATIC
            try
            {
                Commensal commensal = new Commensal();   //PREGUNTAR SI SE NECESITA FAB ENTIDAD 
                commensal.Id = idcommensal;                       //PREGUNTAR ID

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
            }
            catch (DeleteFondaDAOException e)
            {
                throw new DeleteFavoriteRestaurantFondaWebApiControllerException(
                  "Excepción en el controller web api, al eliminar restaurant favorito de un comensal", e);
               
            }
            catch (NullReferenceException e)
            {
                throw new DeleteFavoriteRestaurantFondaWebApiControllerException(
                   "Excepción en el controller web api,"+
                "apuntador nulo al intentar eliminar un restaurant favorito del comensal",
                   e);
            }
            catch (Exception e)
            {
                throw new DeleteFavoriteRestaurantFondaWebApiControllerException(
                  "Error al intentar eliminar un restaurant favorito de un comensal", e);
            }
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
            Commensal result;
            try
            {
                //Creación del commensal con id
                Commensal commensal = new Commensal();   //PREGUNTAR SI SE NECESITA FAB ENTIDAD 
                commensal.Id = idcommensal;                       //PREGUNTAR ID

                //Creación del restaurant con id
                Restaurant restaurant = new Restaurant();   //PREGUNTAR SI SE NECESITA FAB ENTIDAD 
                restaurant.Id = idrestaurant;                       //PREGUNTAR ID

                // Obtención del commando
                ICommand command = FacCommand.CreateFavoriteRestaurantCommand();

                // Agregacion de parametros
                command.SetParameter(0, commensal);
                command.SetParameter(1, restaurant);

                // Ejecucion del commando
                command.Run();

                // Obtención de respuesta
                result = (Commensal)command.Result;
            }
            catch (SaveEntityFondaDAOException e)
            {
                throw new AddFavoriteRestaurantFondaWebApiControllerException(
                     "Excepción en el conroller web api, al agregar restaurant favorito de un comensal", e);
            }
            catch (NullReferenceException e)
            {
                throw new AddFavoriteRestaurantFondaWebApiControllerException(
                 "Excepción, apuntador nulo al agregrar un restaurant favorito del comensal",
                 e);
            }
            catch (Exception e)
            {
                throw new AddFavoriteRestaurantFondaWebApiControllerException(
                   "Error al agregar restaurant favorito de un comensali", e);
            }
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
            IList<Restaurant> result;
            try
            {
                // Obtención del commando
                ICommand command = FacCommand.GetAllRestaurantCommand();
                // Ejecucion del commando
                command.Run();
                result = (IList<Restaurant>)command.Result;
            }
            catch (FindAllFondaDAOException e)
            {
                throw new GetAllRestaurantsFondaWebApiControllerException(
                     "Excepción en el conroller web api, al obtener la lista de restaurantes", e);
            }
            catch (NullReferenceException e)
            {
                throw new GetAllRestaurantsFondaWebApiControllerException(
                 "Excepción,referencia nula del objeto al obtener la lista de restaurantes",
                 e);
            }
            catch (Exception e)
            {
                throw new GetAllRestaurantsFondaWebApiControllerException(
                   "Error al obtener la lista de restaurantes disponibles", e);
            }                 
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
            Commensal result;
            try
            {
                //Creación del commensal con id
                Commensal commensal = new Commensal();   //PREGUNTAR SI SE NECESITA FAB ENTIDAD 
                commensal.Id = idCommensal;                       //PREGUNTAR ID

                // Obtención del commando
                ICommand command = FacCommand.GetFavoriteRestaurantCommand();

                // Agregacion de parametros
                command.SetParameter(0, commensal);

                // Ejecucion del commando
                command.Run();

                // Obtención de respuesta
                result = (Commensal)command.Result;
            }
            catch (FindByIdFondaDAOException e)
            {
                throw new FindFavoriteRestaurantFondaWebApiControllerException(
                     "Excepción en el conroller web api, al obtener la lista de restaurantes favoritos del comensal",
                     e);
            }
            catch (NullReferenceException e)
            {
                throw new FindFavoriteRestaurantFondaWebApiControllerException(
                 "Excepción, referencia de objeto nula al buscar la lista de restaurantes favoritos del comensal",
                 e);
            }
            catch (Exception e)
            {
                throw new FindFavoriteRestaurantFondaWebApiControllerException(
                 "Error al obtener la lista de los restaurantes Favoritos del comensal",
                 e);
            }                 
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
            UserAccount result;
            try
            {
                UserAccount commensal = new UserAccount();   //PREGUNTAR SI SE NECESITA FAB ENTIDAD 
                commensal.Email = email;
                // Obtención del commando
                ICommand command = FacCommand.GetCommensalEmailCommand();
                // Agregacion de parametros
                command.SetParameter(0, commensal);

                // Ejecucion del commando
                command.Run();

                // Obtención de respuesta
                result = (UserAccount)command.Result;
            }
            catch (FindByEmailUserAccountFondaDAOException e)
            {
                throw new FindByEmailUserAccountFondaWebApiControllerException(
                   "Excepción en el web api controller, al buscar el comensal por email",
                   e);
            }
            catch (NullReferenceException e)
            {
                throw new FindByEmailUserAccountFondaWebApiControllerException(
                 "Excepción, apuntador nulo al buscar un comensal por email",
                 e);
            }
            catch (Exception e)
            {
                throw new FindByEmailUserAccountFondaWebApiControllerException(
                 "Error al buscar el comensal por email",
                 e);
            }
            return Ok(result);
        }
    }
}