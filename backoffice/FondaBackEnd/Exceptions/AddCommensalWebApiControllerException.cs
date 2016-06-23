using com.ds201625.fonda.FondaBackEnd.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.ds201625.fonda.BackEnd.Exceptions
{
    /// <summary>
    /// Representa los errores que se generan al crear
    /// un Commensal en CommensalWebApiController
    /// </summary>
    public class AddCommensalWebApiControllerException : FondaBackendException
    {
        public AddCommensalWebApiControllerException  () : base() {	}

		public AddCommensalWebApiControllerException (string message) : base(message) {	}

        public AddCommensalWebApiControllerException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}