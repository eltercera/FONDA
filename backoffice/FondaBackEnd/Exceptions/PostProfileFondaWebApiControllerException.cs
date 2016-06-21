using com.ds201625.fonda.FondaBackEnd.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.ds201625.fonda.BackEnd.Exceptions
{
    /// <summary>
    /// Representa los errores que se generan al crear
    /// un Perfil de un Commensal en PostProfileFondaWebApiController
    /// </summary>
    public class PostProfileFondaWebApiControllerException : FondaBackendException
    {
        public PostProfileFondaWebApiControllerException  () : base() {	}

		public PostProfileFondaWebApiControllerException (string message) : base(message) {	}

        public PostProfileFondaWebApiControllerException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}