using com.ds201625.fonda.FondaBackEnd.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.ds201625.fonda.BackEnd.Exceptions
{
    /// <summary>
    /// Representa los errores que se generan al buscar
    /// un Commensal en GetCommensalFondaWebApi
    /// </summary>
    public class GetCommensalFondaWebApiException : FondaBackendException
    {
        public GetCommensalFondaWebApiException  () : base() {	}

		public GetCommensalFondaWebApiException (string message) : base(message) {	}

        public GetCommensalFondaWebApiException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}