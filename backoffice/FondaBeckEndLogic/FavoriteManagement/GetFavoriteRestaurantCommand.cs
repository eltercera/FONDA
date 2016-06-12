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
            Commensal favorites;
            // Obtencion de parametros
            Commensal commensal = (Commensal)GetParameter(0);

            // Obtiene el dao que se requiere
            ICommensalDAO commensalDAO = FacDao.GetCommensalDAO();
           
            //VALIDACIONES DE CAMPOS--ESTO ES NECESARIO?
            if (commensal.Id == null) 
                throw new Exception("Datos de Perfil Invalidos");
          // Ejecucion del Buscar.		
			try
			{
                favorites = (Commensal)commensalDAO.FindById(commensal.Id);  //PREGUNTAR POR EL NEW RESTAURANT
                foreach (var restaurant in favorites.FavoritesRestaurants)
                {
                    restaurant.RestaurantCategory = new RestaurantCategory
                    {
                        Name = restaurant.RestaurantCategory.Name,
                        Id = restaurant.RestaurantCategory.Id
                    };
                }
			}
            catch (FindByIdFondaDAOException e)
            {
                throw new GetFavoriteRestaurantFondaCommandException(
                   "Excepción al buscar los restaurantes favoritos del comensal",
                   e);
            }
            catch (NullReferenceException e)
            {
                throw new GetFavoriteRestaurantFondaCommandException(
                 "Excepción, referencia de objeto nula al buscar la lista de restaurantes favoritos del comensal",
                 e);
            }
            catch (Exception e)
            {
                throw new GetFavoriteRestaurantFondaCommandException(
                 "Error al listar los restaurantes Favoritos",
                 e);
            }
            //FALTA LOGGER
			// Guardar el resultado.
            Result = favorites;
		}
	}
}