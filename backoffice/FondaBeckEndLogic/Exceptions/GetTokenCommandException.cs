using com.ds201625.fonda.BackEndLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaBeckEndLogic.Exceptions
{
    /// <summary>
    /// Clase GetTokenCommandException para manejo 
    /// de Excepciones en la clase GetTokenCommandException
    /// </summary>
    public class GetTokenCommandException : FondaBackendLogicException
    {
         public GetTokenCommandException  () : base() {	}

		public GetTokenCommandException (string message) : base(message) {	}

        public GetTokenCommandException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
