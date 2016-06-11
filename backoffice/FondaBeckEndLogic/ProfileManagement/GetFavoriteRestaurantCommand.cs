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
    class GetFavoriteRestaurantCommand : BaseCommand
    {
        public GetFavoriteRestaurantCommand() : base() { }

		protected override Parameter[] InitParameters ()
		{
            // Requiere 2 Parametros
            Parameter[] paramters = new Parameter[1];

            // [0] El Commensal
            paramters[0] = new Parameter(typeof(Commensal), true);

            return paramters;
		}

       

		protected override void Invoke()
		{
            Commensal favorites;
            // Obtencion de parametros
            Commensal commensal = (Commensal)GetParameter(0);

            // Obtiene el dao que se requiere
            ICommensalDAO commensalDAO = FacDao.GetCommensalDAO();
           
            //VALIDACIONES DE CAMPOS

           /* // Validacion basica de datos
            if (commensal.Id == null || profile.Person == null || profile.Person.Name == null
                || profile.Person.LastName == null || profile.Person
                .Ssn == null)
                // TODO: Crear Excepcion personalizada
                throw new Exception("Datos de Perfil Invalidos");*/

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
			catch (SaveEntityFondaDAOException e)  ////CAMBIAR EXEPCIONES
			{
				// TODO: Crear Excepcion personalizada
				throw new Exception("Error al gualrdar los datos",e);
			}
			catch (Exception e)
			{
				// TODO: Crear Excepcion personalizada
				throw new Exception("Error Desconocido",e);
			}

			// Guardar el resultado.
            Result = favorites;
		}
	}
}