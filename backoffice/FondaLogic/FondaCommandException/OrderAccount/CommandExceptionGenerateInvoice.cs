using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.FondaCommandException
{
    /// <summary>
    /// Excepcion arrojada en caso de que falle la generacion de la factura
    /// </summary>
    class CommandExceptionGenerateInvoice : CommandException
    {
        #region Constructors

        public CommandExceptionGenerateInvoice(string message) : base(message)
        {
        }
        public CommandExceptionGenerateInvoice(string message, Exception ex) : base(message, ex)
        {
        }
        public CommandExceptionGenerateInvoice(string id, string classname, string method, string message, Exception ex)
                : base(id, classname, method, message, ex)
        {
        }

        #endregion
    }
}
