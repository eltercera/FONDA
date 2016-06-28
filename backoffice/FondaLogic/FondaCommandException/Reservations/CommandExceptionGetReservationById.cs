using System;

namespace com.ds201625.fonda.Logic.FondaLogic.FondaCommandException
{
    public class CommandExceptionGetReservationById : CommandException
    {

        #region Constructors

        public CommandExceptionGetReservationById(string message) : base(message)
        {
        }
        public CommandExceptionGetReservationById(string message, Exception ex) : base(message, ex)
        {
        }
        public CommandExceptionGetReservationById(string id, string classname, string method, string message, Exception ex)
                : base(id, classname, method, message, ex)
        {
        }
        #endregion
    }
}
