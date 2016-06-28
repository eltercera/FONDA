using System;

namespace com.ds201625.fonda.Logic.FondaLogic.FondaCommandException
{
    public class CommandExceptionGetDetailReservation : CommandException
    {


        #region Constructors

        public CommandExceptionGetDetailReservation(string message) : base(message)
        {
        }
        public CommandExceptionGetDetailReservation(string message, Exception ex) : base(message, ex)
        {
        }
        public CommandExceptionGetDetailReservation(string id, string classname, string method, string message, Exception ex)
                : base(id, classname, method, message, ex)
        {
        }

        #endregion
    }
}
