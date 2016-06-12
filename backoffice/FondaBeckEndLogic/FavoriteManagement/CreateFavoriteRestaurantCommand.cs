using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.FondaBackEndLogic.Exceptions;

namespace com.ds201625.fonda.BackEndLogic.FavoriteManagement
{
    /// <summary>
    /// Create Favorite Restaurant Command.
    /// </summary>
    class CreateFavoriteRestaurantCommand : BaseCommand 
    {
        /// <summary>
        /// constructor create Favorite restaurant command
        /// </summary>
         public CreateFavoriteRestaurantCommand() : base() { }
         
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
        /// metodo invoke que ejecuta el agregar restaurant favorito
        /// </summary>
		protected override void Invoke()
		{
            Commensal commensal;
            Restaurant restaurant;
            // Obtencion de parametros
            Commensal idCommensal = (Commensal)GetParameter(0);
            Restaurant idRestaurant = (Restaurant)GetParameter(1);
            // Obtiene el DAO que se requiere
            ICommensalDAO commensalDAO = FacDao.GetCommensalDAO();
            IRestaurantDAO restaurantDAO = FacDao.GetRestaurantDAO();
           //VALIDACIONES DE CAMPOS
            if ((idCommensal == null) || (idRestaurant == null)) 
                throw new Exception("Datos Invalidos");
            // Ejecucion del agregar.		
			try
			{
                commensal = (Commensal)commensalDAO.FindById(idCommensal.Id);
                restaurant = (Restaurant)restaurantDAO.FindById(idRestaurant.Id);
                commensal.RemoveFavoriteRestaurant(restaurant);
                commensal.AddFavoriteRestaurant(restaurant);
                commensalDAO.Save(commensal);
            }
			catch (SaveEntityFondaDAOException e)  
			{
                throw new CreateFavoriteRestaurantCommandException(
                   "Excepción al agregar un restaurant favorito del comensal",
                   e);
			}
            catch (NullReferenceException e)  
            {
                throw new CreateFavoriteRestaurantCommandException(
                 "Excepción, apuntador nulo al agregrar un restaurant favorito del comensal",
                 e);
            }
			catch (Exception e)
			{
                throw new CreateFavoriteRestaurantCommandException(
                 "Error al crear restaurant Favorito",
                 e);
			}
            //FALTA LOGGER
			// Guarda el resultado.
            Result = commensal;
		}
	}
}
  