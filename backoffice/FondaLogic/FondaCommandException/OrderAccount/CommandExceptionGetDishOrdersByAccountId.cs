using System;

namespace FondaLogic.FondaCommandException.OrderAccount
{
    /// <summary>
    /// Excepcion arrojada en caso de que falle la consulta  de una lista DishOrders 
    /// pertenenciente a una orden mediante su Id
    /// </summary>
    class CommandExceptionGetDishOrdersByAccountId : CommandException
    {
        #region Constructors

        public CommandExceptionGetDishOrdersByAccountId(string message) : base(message)
        {
        }
        public CommandExceptionGetDishOrdersByAccountId(string message, Exception ex) : base(message, ex)
        {
        }
        public CommandExceptionGetDishOrdersByAccountId(string id, string classname, string method, string message, Exception ex)
                : base(id, classname, method, message, ex)
        {
        }

        #endregion
    }
}
