using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.ds201625.fonda;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;


namespace FondaLogic.Commands.Login
{
    class CommandGetRestaurantById : Command<Restaurant>
    {
        /// <summary>
        /// Metodo que ejecuta el comando para buscar un empleado de la bd
        /// </summary>
        /// <returns>Empleado</returns>
        public override Restaurant Execute()
        {

            try
            {
                //Metodos para acceder a la BD
                FactoryDAO _facDAO = FactoryDAO.Intance;
                IRestaurantDAO _restaurantDAO = _facDAO.GetRestaurantDAO();
                Restaurant _restaurant = (Restaurant)Entity;

                return _restaurantDAO.FindById(_restaurant.Id);
            }
            catch (NullReferenceException ex)
            {
                //TODO: Arrojar Excepcion personalizada
                //TODO: Escribir en el Log la excepcion
                throw;
            }

        }

    }
}