using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.FondaCommandException.OrderAccount
{
    public class CommandExceptionGetPaymentHistoryByProfile : CommandException
    {
        #region Constructors

        public CommandExceptionGetPaymentHistoryByProfile(string message) : base(message)
        {
        }
        public CommandExceptionGetPaymentHistoryByProfile(string message, Exception ex) : base(message, ex)
        {
        }
        public CommandExceptionGetPaymentHistoryByProfile(string id, string classname, string method, string message, Exception ex)
                : base(id, classname, method, message, ex)
        {
        }

        #endregion
    }
}
