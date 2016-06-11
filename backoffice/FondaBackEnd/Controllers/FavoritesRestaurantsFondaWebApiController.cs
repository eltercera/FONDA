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
using com.ds201625.fonda.Logic;

namespace com.ds201625.fonda.BackEnd.Controllers
{
    [RoutePrefix("api")]
    public class FavoritesRestaurantsFondaWebApiController : FondaWebApi
    {
        public FavoritesRestaurantsFondaWebApiController() : base() { }

      
       /*/// <summary>
        /// elimina un restaurante de la lista de favoritos de un
        /// commensal, recibe id int del restaurant a agregar,
        /// retorna lista de favoritos actualizada
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("deletefavorite/{idcommensal}/{idrestaurant}")]
        [HttpGet]
        //[FondaAuthToken]
        public IHttpActionResult deletefavorite(int idcommensal, int idrestaurant)
        {
            Commensal commensal = (Commensal)GetCommensalDao().FindById(idcommensal);
            ICommensalDAO commensalDao = FactoryDAO.GetCommensalDAO();
            Restaurant restaurant = GetRestaurantDao().FindById(idrestaurant);
            commensal.RemoveFavoriteRestaurant(restaurant);
            try
            {
                commensalDao.Save(commensal);
            }
            catch (SaveEntityFondaDAOException e)
            {
                Console.WriteLine(e.ToString());
                return InternalServerError(e);
            }
            return Ok(commensal);
        }*/
        /// <summary>
        /// elimina un restaurante de la lista de favoritos de un
        /// commensal, recibe id int del restaurant a agregar,
        /// retorna lista de favoritos actualizada
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("deletefavorite/{idcommensal}/{idrestaurant}")]
        [HttpGet]
        //[FondaAuthToken]
        public IHttpActionResult deletefavorite(int idcommensal, int idrestaurant)
        {
            Commensal commensal = new Commensal();   //PREGUNTAR SI SE NECESITA FAB ENTIDAD 
            commensal.Id = idcommensal;                       //PREGUNTAR ID

            //Creación del restaurant con id
            Restaurant restaurant = new Restaurant();   //PREGUNTAR SI SE NECESITA FAB ENTIDAD 
            restaurant.Id = idrestaurant;                       //PREGUNTAR ID

            // Obtención del commando
            ICommand command = FacCommand.DeleteFavoriteRestaurantCommand();
            
                // Agregacion de parametros
                command.SetParameter(0, commensal);
                command.SetParameter(1, restaurant);

                // Ejecucion del commando
                command.Run();

                // Obtención de respuesta

                Commensal result = (Commensal)command.Result;
           
           /* catch (SaveEntityFondaDAOException e)
            {
                Console.WriteLine(e.ToString());
                return InternalServerError(e);
            }*/
            return Ok(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idcommensal"></param>
        /// <param name="idrestaurant"></param>
        /// <returns></returns>

        [Route("addfavorite/{idcommensal}/{idrestaurant}")]
        [HttpGet]
        ///[FondaAuthToken]
        public IHttpActionResult addfavorite(int idcommensal, int idrestaurant)
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
            Commensal result = (Commensal)command.Result;
           
       
            return Ok(result);
        }

        [Route("ListaRestaurant")]
        [HttpGet]
        public IHttpActionResult getRestaurant()
        {        
            // Obtención del commando
            ICommand command = FacCommand.GetAllRestaurantCommand();       
    
            // Ejecucion del commando
            try
            {
                command.Run();
            }
            catch(Exception e)
            {

            }
          

            // Obtención de respuesta
            IList<Restaurant> result = (IList<Restaurant>)command.Result;
                                  
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


        [Route("findRestaurantFavorites/{id}")]
        [HttpGet]
        public IHttpActionResult findRestaurantFavorites(int id)
        {
            //Creación del commensal con id
            Commensal commensal = new Commensal();   //PREGUNTAR SI SE NECESITA FAB ENTIDAD 
            commensal.Id = id;                       //PREGUNTAR ID

            // Obtención del commando
            ICommand command = FacCommand.GetFavoriteRestaurantCommand();

            // Agregacion de parametros
            command.SetParameter(0, commensal);

            // Ejecucion del commando
            command.Run();

            // Obtención de respuesta
            Commensal result = (Commensal)command.Result;
                       
            return Ok(result.FavoritesRestaurants);
        }
    
        [Route("findCommensalEmail/{email}")]
        [HttpGet]
        public IHttpActionResult findCommensalEmail(string email)
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
            UserAccount result = (UserAccount)command.Result;

            return Ok(result);

        }

    }
}