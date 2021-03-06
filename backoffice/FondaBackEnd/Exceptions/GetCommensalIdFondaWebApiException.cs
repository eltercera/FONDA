﻿using com.ds201625.fonda.FondaBackEnd.Exceptions;
using System;

namespace com.ds201625.fonda.BackEnd.Exceptions
{
    /// <summary>
    /// Representa los errores que se generan al buscar
    /// un Commensal en GetCommensalIdFondaWebApi
    /// </summary>
    public class GetCommensalIdFondaWebApiException : FondaBackendException
    {
        public GetCommensalIdFondaWebApiException  () : base() {	}

		public GetCommensalIdFondaWebApiException (string message) : base(message) {	}

        public GetCommensalIdFondaWebApiException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}