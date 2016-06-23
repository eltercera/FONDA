using com.ds201625.fonda.FondaBackEnd.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.ds201625.fonda.BackEnd.Exceptions
{
    /// <summary>
    /// Representa los errores que se generan al eliminar
    /// un Token de un Commensal en DeleteTokenFondaWebApiController
    /// </summary>
    public class DeleteTokenFondaWebApiControllerException : FondaBackendException
    {
        public DeleteTokenFondaWebApiControllerException () : base() {	}

		public DeleteTokenFondaWebApiControllerException (string message) : base(message) {	}

        public DeleteTokenFondaWebApiControllerException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}