using com.ds201625.fonda.FondaBackEnd.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.ds201625.fonda.BackEnd.Exceptions
{
    /// <summary>
    /// Representa los errores que se generan al validar
    /// Token en FondaAuthLoginAttribute
    /// </summary>
    public class FondaAuthTokenAttributeException : FondaBackendException
    {
        public FondaAuthTokenAttributeException  () : base() {	}

		public FondaAuthTokenAttributeException (string message) : base(message) {	}

        public FondaAuthTokenAttributeException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}