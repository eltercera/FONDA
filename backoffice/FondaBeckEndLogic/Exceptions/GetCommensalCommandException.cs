using com.ds201625.fonda.BackEndLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaBeckEndLogic.Exceptions
{
    /// <summary>
    /// Clase GetCommensalCommandException.
    /// </summary>
    class GetCommensalCommandException : FondaBackendLogicException
    {
        public GetCommensalCommandException  () : base() {	}

		public GetCommensalCommandException (string message) : base(message) {	}

        public GetCommensalCommandException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
