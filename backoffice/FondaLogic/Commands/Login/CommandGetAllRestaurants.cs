using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.ds201625.fonda;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using FondaLogic.FondaCommandException;
using FondaLogic.Log;

namespace FondaLogic.Commands.Login
{
    public class CommandGetAllRestaurants : Command
    {

        FactoryDAO _facDAO = FactoryDAO.Intance;

        public CommandGetAllRestaurants(Object receiver) : base(receiver)
        {

        }

        /// <summary>
        /// Metodo que ejecuta el comando para buscar todos los restaurantes del sistema
        /// </summary>
        /// <returns>Empleado</returns>
        public override void Execute()
        {

            try
            {
                //Metodos para acceder a la BD

                IRestaurantDAO _RestaurantDAO = _facDAO.GetRestaurantDAO();


                Receiver = _RestaurantDAO.GetAll();
            }
            catch (NullReferenceException ex)
            {
                //TODO: Arrojar Excepcion personalizada
                CommandExceptionGetRestaurant exceptionGetRestaurant = new CommandExceptionGetRestaurant(
                //Arrojar
                FondaResources.General.Errors.NullExceptionReferenceCode,
                FondaResources.Login.Errors.ClassNameGetRestaurantAll,
                FondaResources.Login.Errors.CommandMethod,
                FondaResources.General.Errors.NullExceptionReferenceMessage,
                ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exceptionGetRestaurant);

                throw exceptionGetRestaurant;
            }
            catch (Exception ex)
            {
                throw new System.InvalidOperationException(ex.Message);

            }
        }
    }
}
