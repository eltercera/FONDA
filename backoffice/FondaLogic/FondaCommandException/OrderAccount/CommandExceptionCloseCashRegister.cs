using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.FondaCommandException
{
    class CommandExceptionCloseCashRegister : CommandException
    {


        #region Constructors

        public CommandExceptionCloseCashRegister(string message) : base(message)
        {
        }
        public CommandExceptionCloseCashRegister(string message, Exception ex) : base(message, ex)
        {
        }
        public CommandExceptionCloseCashRegister(string id, string classname, string method, string message, Exception ex)
                : base(id, classname, method, message, ex)
        {
        }

        #endregion

    }
}
