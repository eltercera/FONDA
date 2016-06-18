using com.ds201625.fonda.FondaBackEnd.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.ds201625.fonda.BackEnd.Exceptions
{
    /// <summary>
    /// Clase GetProfileFondaWebApiException para manejo 
    /// de Excepciones en GetProfileFondaWebApi
    /// </summary>
    public class GetProfileFondaWebApiException : FondaBackendException
    {
        public GetProfileFondaWebApiException  () : base() {	}

		public GetProfileFondaWebApiException (string message) : base(message) {	}

        public GetProfileFondaWebApiException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}