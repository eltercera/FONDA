using com.ds201625.fonda.FondaBackEnd.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.ds201625.fonda.BackEnd.Exceptions
{
    /// <summary>
    /// Clase PutProfileFondaWebApiControllerException para manejo 
    /// de Excepciones en PutProfileFondaWebApiController
    /// </summary>
    public class PutProfileFondaWebApiControllerException : FondaBackendException
    {
        public PutProfileFondaWebApiControllerException  () : base() {	}

		public PutProfileFondaWebApiControllerException (string message) : base(message) {	}

        public PutProfileFondaWebApiControllerException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}