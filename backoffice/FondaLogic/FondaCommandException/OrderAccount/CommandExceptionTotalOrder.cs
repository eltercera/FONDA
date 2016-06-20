using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.FondaCommandException
{
    class CommandExceptionTotalOrder : CommandException
    {
        #region Constructors

        public CommandExceptionTotalOrder(string message) : base(message)
        {
        }
        public CommandExceptionTotalOrder(string message, Exception ex) : base(message, ex)
        {
        }
        public CommandExceptionTotalOrder(string id, string classname, string method, string message, Exception ex)
                : base(id, classname, method, message, ex)
        {
        }

        #endregion
    }
}
