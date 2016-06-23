using com.ds201625.fonda.FondaBackEnd.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.ds201625.fonda.BackEnd.Exceptions
{
    /// <summary>
    /// Representa los errores que se generan al listar
    /// los Perfiles de un Commensal en GetProfilesFondaWebApiController
    /// </summary>
    public class GetProfilesFondaWebApiControllerException : FondaBackendException
    {
        public GetProfilesFondaWebApiControllerException  () : base() {	}

		public GetProfilesFondaWebApiControllerException (string message) : base(message) {	}

        public GetProfilesFondaWebApiControllerException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}