using FondaLogic.FondaCommandException.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.FondaCommandException.Login
{
    public class CommandExceptionSaveUserAccount : FondaLogicException
    {
        public CommandExceptionSaveUserAccount() : base() { }

        public CommandExceptionSaveUserAccount(string message) : base(message) { }

        public CommandExceptionSaveUserAccount(string message, Exception InnerException)
			: base(message, InnerException) { }
    }
}
