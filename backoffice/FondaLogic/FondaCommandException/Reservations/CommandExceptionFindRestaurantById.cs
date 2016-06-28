using System;

namespace com.ds201625.fonda.Logic.FondaLogic.FondaCommandException
{
    /// <summary>
    /// Excepcion arrojada en caso de que falle la busqueda de las facturas de una cuenta
    /// </summary>
    public class CommandExceptionFindRestaurantById : CommandException
    {


        #region Constructors

        public CommandExceptionFindRestaurantById(string message) : base(message)
        {
        }
        public CommandExceptionFindRestaurantById(string message, Exception ex) : base(message, ex)
        {
        }
        public CommandExceptionFindRestaurantById(string id, string classname, string method, string message, Exception ex)
                : base(id, classname, method, message, ex)
        {
        }

        #endregion

    }
}
