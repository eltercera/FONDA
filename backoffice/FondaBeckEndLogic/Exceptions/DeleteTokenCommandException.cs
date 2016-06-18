using com.ds201625.fonda.BackEndLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaBeckEndLogic.Exceptions
{
    /// <summary>
    /// Clase DeleteTokenCommandException para manejo 
    /// de Excepciones en la clase DeleteTokenCommand
    /// </summary>
    public class DeleteTokenCommandException : FondaBackendLogicException
    {
        public DeleteTokenCommandException  () : base() {	}

		public DeleteTokenCommandException  (string message) : base(message) {	}

        public DeleteTokenCommandException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
