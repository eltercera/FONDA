using FondaLogic.Commands.OrderAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.Log
{
    public class Validate
    {
        #region OrderAccount

        /// <summary>
        /// Valida lo que recibe el comando Get Orders
        /// </summary>
        /// <param name="command">El comando junto a su Receiver</param>
        public static void CommandGetOrdersParameter(CommandGetOrders command)
        {
            int restaurantId;

            try
            {
                restaurantId = (int)command.Receiver;
            }
            catch (Exception)
            {
                //TODO: Enviar excepcion personalizada
                throw;
            }
        }

        #endregion
    }
}
