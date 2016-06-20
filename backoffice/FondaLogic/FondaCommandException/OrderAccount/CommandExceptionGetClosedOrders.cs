using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.FondaCommandException
{
    class CommandExceptionGetClosedOrders : CommandException
    {

        #region Constructors

        public CommandExceptionGetClosedOrders(string message) : base(message)
        {
        }
        public CommandExceptionGetClosedOrders(string message, Exception ex) : base(message, ex)
        {
        }
        public CommandExceptionGetClosedOrders(string id, string classname, string method, string message, Exception ex)
                : base(id, classname, method, message, ex)
        {
        }

        #endregion
    }
}
