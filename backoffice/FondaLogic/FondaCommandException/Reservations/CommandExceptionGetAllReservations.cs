using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.Login;
using System;

namespace com.ds201625.fonda.Logic.FondaLogic.FondaCommandException
{
    /// <summary>
    /// excepcion que es lanzada en caso de que falle una consulta de restaurantes
    /// </summary>
    public class CommandExceptionGetAllReservations : FondaLogicException
    {


        public CommandExceptionGetAllReservations() : base() { }

        public CommandExceptionGetAllReservations(string message) : base(message) { }

        public CommandExceptionGetAllReservations(string message, Exception InnerException)
			: base(message, InnerException) { }




    }
}
