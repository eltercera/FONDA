using com.ds201625.fonda.FondaBackEnd.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.ds201625.fonda.BackEnd.Exceptions
{
    /// <summary>
    /// Representa los errores que se generan al eliminar
    /// un Perfil de un Commensal en DeleteProfileFondaWebApiController
    /// </summary>
    public class DeleteProfileFondaWebApiControllerException : FondaBackendException
    {
        public DeleteProfileFondaWebApiControllerException  () : base() {	}

		public DeleteProfileFondaWebApiControllerException (string message) : base(message) {	}

        public DeleteProfileFondaWebApiControllerException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}