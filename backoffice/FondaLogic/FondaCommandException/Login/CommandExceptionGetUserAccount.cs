using FondaLogic.FondaCommandException.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.FondaCommandException
{
    public class CommandExceptionGetUserAccount : FondaLogicException
    {

        public CommandExceptionGetUserAccount() : base() { }

        public CommandExceptionGetUserAccount(string message) : base(message) { }

        public CommandExceptionGetUserAccount(string message, Exception InnerException)
			: base(message, InnerException) { }





    }
}
