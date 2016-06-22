using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.FondaCommandException
{
    /// <summary>
    /// Excepcion arrojada en caso de que no se pueda obtener el detalle de la orden
    /// </summary>
    public class CommandExceptionGetDetailOrder : CommandException
    {
        #region Constructors

        public CommandExceptionGetDetailOrder(string message) : base(message)
        {
        }
        public CommandExceptionGetDetailOrder(string message, Exception ex) : base(message, ex)
        {
        }
        public CommandExceptionGetDetailOrder(string id, string classname, string method, string message, Exception ex)
                : base(id, classname, method, message, ex)
        {
        }

        #endregion
    }
}
