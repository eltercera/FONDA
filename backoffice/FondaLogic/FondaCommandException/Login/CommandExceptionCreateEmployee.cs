
using FondaLogic.FondaCommandException.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace FondaLogic.FondaCommandException.Login
{
    /// <summary>
    /// excepcion creada en caso de que falle un save de un empleado
    /// </summary>
    public class CommandExceptionCreateEmployee : FondaLogicException
    {

        
        public CommandExceptionCreateEmployee() : base() { }

        public CommandExceptionCreateEmployee(string message) : base(message) { }

        public CommandExceptionCreateEmployee(string message, Exception InnerException)
			: base(message, InnerException) { }
    }
}

    

