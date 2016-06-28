using System;

namespace com.ds201625.fonda.Logic.FondaLogic.FondaCommandException
{
    /// <summary>
    /// Excepcion arrojada en caso de que falle la busqueda de las facturas de una cuenta
    /// </summary>
    public class CommandExceptionFindReservationsByRestaurant : CommandException
    {


        #region Constructors

        public CommandExceptionFindReservationsByRestaurant(string message) : base(message)
        {
        }
        public CommandExceptionFindReservationsByRestaurant(string message, Exception ex) : base(message, ex)
        {
        }
        public CommandExceptionFindReservationsByRestaurant(string id, string classname, string method, string message, Exception ex)
                : base(id, classname, method, message, ex)
        {
        }

        #endregion

    }
}
