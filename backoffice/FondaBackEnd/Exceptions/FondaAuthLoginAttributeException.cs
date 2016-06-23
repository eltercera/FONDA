using com.ds201625.fonda.FondaBackEnd.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.ds201625.fonda.BackEnd.Exceptions
{
    /// <summary>
    /// Representa los errores que se generan al validar
    /// cuenta en FondaAuthLoginAttribute
    /// </summary>
    public class FondaAuthLoginAttributeException : FondaBackendException
    {
        public FondaAuthLoginAttributeException  () : base() {	}

		public FondaAuthLoginAttributeException (string message) : base(message) {	}

        public FondaAuthLoginAttributeException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}