using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.ds201625.fonda.BackEndLogic;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.FondaBackEndLogic.Exceptions;


namespace FondaBeckEndLogic.ProfileManagement
{
    /// <summary>
    /// Delete Favorite Restaurant Command.
    /// </summary>
    class DeleteFavoriteRestaurantCommand : BaseCommand
    {

        /// <summary>
        /// constructor delete Favorite restaurant command
        /// </summary>
        public DeleteFavoriteRestaurantCommand() : base() { }

        /// <summary>
        /// metodo que inicializa los parametros
        /// </summary>
        /// <returns>paramters</returns>
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

        /// <summary>
        /// metodo invoke que ejecuta el borrar restaurant favorito de un comensal
        /// </summary>
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
            // Ejecucion del Buscar.		
            try
            {
                commensal = (Commensal)commensalDAO.FindById(idCommensal.Id);
                restaurant = (Restaurant)restaurantDAO.FindById(idRestaurant.Id);
                commensal.RemoveFavoriteRestaurant(restaurant);
                commensalDAO.Save(commensal);
            }
            catch (DeleteFondaDAOException e) 
            {
                throw new DeleteFavoriteRestaurantCommandException(
                    "Excepción al eliminar restaurant favorito de un comensal", e);
            }
            catch (NullReferenceException e)
            {
                throw new DeleteFavoriteRestaurantCommandException(
                   "Excepción, apuntador nulo al intentar eliminar un restaurant favorito del comensal",
                   e);
            }
            catch (Exception e)
            {
                throw new DeleteFavoriteRestaurantCommandException(
                   "Error al intentar eliminar un restaurant favorito de un comensal", e);
            }
            //FALTA LOGGER
            // Guardar el resultado.
            Result = commensal;
        }
    }
}