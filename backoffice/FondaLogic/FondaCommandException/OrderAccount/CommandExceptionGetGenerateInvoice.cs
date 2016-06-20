using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.FondaCommandException
{
    /// <summary>
    /// Excepcion arrojada en caso de que no se pueda generar la factura
    class CommandExceptionGetGenerateInvoice : CommandException
    {
        #region Constructors

        public CommandExceptionGetGenerateInvoice(string message) : base(message)
        {
        }
        public CommandExceptionGetGenerateInvoice(string message, Exception ex) : base(message, ex)
        {
        }
        public CommandExceptionGetGenerateInvoice(string id, string classname, string method, string message, Exception ex)
                : base(id, classname, method, message, ex)
        {
        }

        #endregion
    }
}
