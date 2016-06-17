using com.ds201625.fonda.BackEndLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaBeckEndLogic.Exceptions
{
    /// <summary>
    /// Clase CreateProfileCommandException para manejo 
    /// de Excepciones en la clase CreateProfileCommand
    /// </summary>
    public class CreateProfileCommandException : FondaBackendLogicException
    {
         public CreateProfileCommandException  () : base() {	}

		public CreateProfileCommandException (string message) : base(message) {	}

        public CreateProfileCommandException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
