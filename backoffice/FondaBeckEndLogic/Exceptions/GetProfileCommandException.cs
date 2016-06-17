using com.ds201625.fonda.BackEndLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaBeckEndLogic.Exceptions
{
    /// <summary>
    /// Clase GetProfileCommandException para manejo 
    /// de Excepciones en la clase GetProfileCommand
    /// </summary>
    public class GetProfileCommandException : FondaBackendLogicException
    {
         public GetProfileCommandException  () : base() {	}

		public GetProfileCommandException (string message) : base(message) {	}

        public GetProfileCommandException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
