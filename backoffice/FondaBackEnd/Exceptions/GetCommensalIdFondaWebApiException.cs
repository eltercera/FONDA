using com.ds201625.fonda.FondaBackEnd.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.ds201625.fonda.BackEnd.Exceptions
{
    /// <summary>
    /// Clase GetCommensalIdFondaWebApiException para manejo 
    /// de Excepciones en GetCommensalIdFondaWebApi
    /// </summary>
    public class GetCommensalIdFondaWebApiException : FondaBackendException
    {
        public GetCommensalIdFondaWebApiException  () : base() {	}

		public GetCommensalIdFondaWebApiException (string message) : base(message) {	}

        public GetCommensalIdFondaWebApiException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}