using FondaLogic.FondaCommandException.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.FondaCommandException.login
{
    public class CommandExceptionGetEmployee : FondaLogicException
    {

        public CommandExceptionGetEmployee() : base() { }

        public CommandExceptionGetEmployee(string message) : base(message) { }

        public CommandExceptionGetEmployee(string message, Exception InnerException)
			: base(message, InnerException) { }

    }
}
