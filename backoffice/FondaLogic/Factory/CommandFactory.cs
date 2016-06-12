using com.ds201625.fonda;
using com.ds201625.fonda.Domain;
using FondaLogic.Commands.OrderAccount;
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


        #endregion

        #region Restaurant

        //Defincion de los comandos a implementar del modulo Restaurante

        #endregion

        #region Menu

        //Defincion de los comandos a implementar del modulo Menu

        #endregion

        #region Login

        //Defincion de los comandos a implementar del modulo Login

        #endregion
    }
}
