using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.OrderAccount
{
    public class CommandExceptionGetInvoicesByProfile : CommandException
    {
        #region Constructors

        public CommandExceptionGetInvoicesByProfile(string message) : base(message)
        {
        }
        public CommandExceptionGetInvoicesByProfile(string message, Exception ex) : base(message, ex)
        {
        }
        public CommandExceptionGetInvoicesByProfile(string id, string classname, string method, string message, Exception ex)
                : base(id, classname, method, message, ex)
        {
        }

        #endregion
    }
}
