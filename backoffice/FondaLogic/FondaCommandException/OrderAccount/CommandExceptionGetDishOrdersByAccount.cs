using System;

namespace FondaLogic.FondaCommandException.OrderAccount
{
    /// <summary>
    /// Excepcion arrojada en caso de que falle la consulta  de una lista DishOrders 
    /// pertenenciente a una orden mediante su Id
    /// </summary>
    public class CommandExceptionGetDishOrdersByAccount : CommandException
    {
        #region Constructors

        public CommandExceptionGetDishOrdersByAccount(string message) : base(message)
        {
        }
        public CommandExceptionGetDishOrdersByAccount(string message, Exception ex) : base(message, ex)
        {
        }
        public CommandExceptionGetDishOrdersByAccount(string id, string classname, string method, string message, Exception ex)
                : base(id, classname, method, message, ex)
        {
        }

        #endregion
    }
}
