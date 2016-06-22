using FondaLogic.FondaCommandException.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.FondaCommandException.login
{
    /// <summary>
    /// excepcion que se crea en caso de que se falle una consulta de un empleado
    /// </summary>
    public class CommandExceptionGetEmployee : FondaLogicException
    {

        public CommandExceptionGetEmployee() : base() { }

        public CommandExceptionGetEmployee(string message) : base(message) { }

        public CommandExceptionGetEmployee(string message, Exception InnerException)
			: base(message, InnerException) { }

    }
}
