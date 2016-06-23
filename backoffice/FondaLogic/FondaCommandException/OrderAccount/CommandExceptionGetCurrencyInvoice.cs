using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaCommandException.OrderAccount
{
    public class CommandExceptionGetCurrencyInvoice : CommandException
    {
        #region Constructors

        public CommandExceptionGetCurrencyInvoice(string message) : base(message)
        {
        }
        public CommandExceptionGetCurrencyInvoice(string message, Exception ex) : base(message, ex)
        {
        }
        public CommandExceptionGetCurrencyInvoice(string id, string classname, string method, string message, Exception ex)
                : base(id, classname, method, message, ex)
        {
        }

        #endregion
    }
}
