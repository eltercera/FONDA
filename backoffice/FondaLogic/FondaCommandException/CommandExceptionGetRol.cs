using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.FondaCommandException
{
    class CommandExceptionGetRol : CommandException
    {
        #region Constructors

        public CommandExceptionGetRol(string message, Exception ex) : base(message, ex)
            {
        }

        public CommandExceptionGetRol(string id, string classname, string method, string message, Exception ex)
                : base(id, classname, method, message, ex)
            {
        }

        #endregion

    }
}
