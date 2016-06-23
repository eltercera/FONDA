using com.ds201625.fonda.FondaBackEnd.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.ds201625.fonda.BackEnd.Exceptions
{
    /// <summary>
    /// Representa los errores que se generan al buscar
    /// un Token de un Commensal en DeleteTokenFondaWebApiController
    /// </summary>
    public class GetTokenFondaWebApiControllerException : FondaBackendException
    {
        public GetTokenFondaWebApiControllerException () : base() {	}

		public GetTokenFondaWebApiControllerException (string message) : base(message) {	}

        public GetTokenFondaWebApiControllerException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}