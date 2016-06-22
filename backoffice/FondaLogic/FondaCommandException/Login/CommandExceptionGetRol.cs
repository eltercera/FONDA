using FondaLogic.FondaCommandException.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.FondaCommandException.login
{
    /// <summary>
    /// excepcion que es lanzada en caso de que falle una consulta de rol
    /// </summary>
    public class CommandExceptionGetRol : FondaLogicException
    {
        public CommandExceptionGetRol() : base() { }

        public CommandExceptionGetRol(string message) : base(message) { }

        public CommandExceptionGetRol(string message, Exception InnerException)
			: base(message, InnerException) { }

    }
}
