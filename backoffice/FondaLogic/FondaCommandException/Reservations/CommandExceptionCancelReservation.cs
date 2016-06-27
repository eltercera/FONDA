using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.Reservations
{
    public class CommandExceptionCancelReservation : CommandException
    {


        #region Constructors

        public CommandExceptionCancelReservation(string message) : base(message)
        {
        }
        public CommandExceptionCancelReservation(string message, Exception ex) : base(message, ex)
        {
        }
        public CommandExceptionCancelReservation(string id, string classname, string method, string message, Exception ex)
                : base(id, classname, method, message, ex)
        {
        }

        #endregion

 
    
    }
}
