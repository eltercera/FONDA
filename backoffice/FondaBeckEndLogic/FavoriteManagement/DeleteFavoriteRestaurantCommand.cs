using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.ds201625.fonda.Logic;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.DataAccess.FactoryDAO;


namespace FondaBeckEndLogic.ProfileManagement
{
    class DeleteFavoriteRestaurantCommand : BaseCommand
    {

        public DeleteFavoriteRestaurantCommand() : base() { }

		protected override Parameter[] InitParameters ()
        { 
            // Requiere 2 Parametros
            Parameter[] paramters = new Parameter[2];

            // [0] el Commensal
            paramters[0] = new Parameter(typeof(Commensal), true);

            // [1] El Restaurant
            paramters[1] = new Parameter(typeof(Restaurant), true);
            return paramters;
		}


        protected override void Invoke()
        {
            Commensal commensal;
            Restaurant restaurant;
            // Obtencion de parametros
            Commensal idCommensal = (Commensal)GetParameter(0);
            Restaurant idRestaurant = (Restaurant)GetParameter(1);
            // Obtiene el dao que se requiere
            ICommensalDAO commensalDAO = FacDao.GetCommensalDAO();
            IRestaurantDAO restaurantDAO = FacDao.GetRestaurantDAO();
           
            //VALIDACIONES DE CAMPOS

            // Ejecucion del Buscar.		
            try
            {
                commensal = (Commensal)commensalDAO.FindById(idCommensal.Id);
                restaurant = (Restaurant)restaurantDAO.FindById(idRestaurant.Id);
                commensal.RemoveFavoriteRestaurant(restaurant);
                commensalDAO.Save(commensal);
             //   answer = (UserAccount)commensalDAO.FindByEmail(commensal.Email);
                //PREGUNTAR POR EL NEW RESTAURANT
               
            }
            catch (SaveEntityFondaDAOException e)  ////CAMBIAR EXEPCIONES
            {
                // TODO: Crear Excepcion personalizada
                throw new Exception("Error al gualrdar los datos", e);
            }
            catch (Exception e)
            {
                // TODO: Crear Excepcion personalizada
                throw new Exception("Error Desconocido", e);
            }
            //FALTA LOGGER
            // Guardar el resultado.
            Result = commensal;
        }
    }
}