using com.ds201625.fonda.BackEndLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaBeckEndLogic.Exceptions
{
    /// <summary>
    /// Clase DeleteProfileCommandException para manejo 
    /// de Excepciones en la clase DeleteProfileCommand
    /// </summary>
    public class DeleteProfileCommandException : FondaBackendLogicException
    {
        public DeleteProfileCommandException  () : base() {	}

		public DeleteProfileCommandException  (string message) : base(message) {	}

        public DeleteProfileCommandException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
