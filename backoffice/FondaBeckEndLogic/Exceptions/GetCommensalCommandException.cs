using com.ds201625.fonda.BackEndLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.BackEndLogic.Exceptions
{
    /// <summary>
    /// Representa los errores que se generan al buscar
    /// un Commensal en GetCommensalCommand
    /// </summary>
    public class GetCommensalCommandException : FondaBackendLogicException
    {
        public GetCommensalCommandException  () : base() {	}

		public GetCommensalCommandException (string message) : base(message) {	}

        public GetCommensalCommandException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
