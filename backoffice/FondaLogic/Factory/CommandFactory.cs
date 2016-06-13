using com.ds201625.fonda;
using com.ds201625.fonda.Domain;
using FondaLogic.Commands.OrderAccount;
using FondaLogic.Commands.Login;
using FondaLogic.Log;
using System.Collections.Generic;

namespace FondaLogic.Factory
{
    /// <summary>
    /// Fabrica que genera los comandos del sistema
    /// </summary>
    public class CommandFactory
    {
        #region Logger

        /// <summary>
        /// Inicializa el Logger de la aplicacion
        /// </summary>
        public static void InitLog()
        {
            new Logger();
        }

        #endregion

        #region OrderAccount

        //Se obtienen los comandos a a utilizar

        /// <summary>
        /// Metodo de la fabrica para el Comando CommandGetOrders
        /// </summary>
        /// <param name="entity">Id del Restaurante</param>
        /// <returns>comando CommandGetOrders</returns>
        public static Command GetCommandGetOrders(object receiver)
        {
            return new CommandGetOrders(receiver);
        }

        /// <summary>
        /// Metodo de la fabrica para el ComandoGetOrder
        /// </summary>
        /// <param name="receiver">Id de la orden</param>
        /// <returns>comando CommandGetOrder</returns>
        public static Command GetCommandGetOrder(object receiver)
        {
            return new CommandGetOrder(receiver);
        }

        /// <summary>
        /// Metodo de la fabrica para el ComandoClosedOrders
        /// </summary>
        /// <param name="receiver">Id del restaurant</param>
        /// <returns>comando CommandClosedOrders</returns>
        public static Command GetCommandClosedOrders(object receiver)
        {
            return new CommandGetClosedOrders(receiver);
        }


        #endregion

        #region Invoice

        //Se obtienen los comandos a a utilizar

        /// <summary>
        /// Metodo de la fabrica para el Comando CommandGetInvoice
        /// </summary>
        /// <param name="entity">Id del Restaurante</param>
        /// <returns>comando CommandGetOrders</returns>
        public static Command GetCommandInvoice(object receiver)
        {
            return new CommandGetInvoice(receiver);
        }

        #endregion

        #region Restaurant

        //Defincion de los comandos a implementar del modulo Restaurante

        #endregion

        #region Menu

        //Defincion de los comandos a implementar del modulo Menu

        #endregion

        #region Login

        //Defincion de los comandos a implementar del modulo Login

        public static Command GetCommandGetEmployeeByUser(object receiver)
        {
            return new CommandGetEmployeeByUser(receiver);
        }

        public static Command GetCommandGetRestaurantById(object receiver)
        {
            return new CommandGetRestaurantById(receiver);
        }

        public static Command GetCommandSaveEmployee(object receiver)
        {
            return new CommandSaveEmployee(receiver);
        }

        #endregion
    }
}
