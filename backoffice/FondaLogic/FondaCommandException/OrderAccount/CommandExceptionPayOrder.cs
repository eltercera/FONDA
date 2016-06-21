using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.FondaCommandException
{
    public class CommandExceptionPayOrder: CommandException
    {

        #region Constructors

        public CommandExceptionPayOrder(string message) : base(message)
        {
        }
        public CommandExceptionPayOrder(string message, Exception ex) : base(message, ex)
        {
        }
        public CommandExceptionPayOrder(string id, string classname, string method, string message, Exception ex)
                : base(id, classname, method, message, ex)
        {
        }

        #endregion
    }
}
