using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.FondaBackEnd.Exceptions
{
    /// <summary>
    /// Clase FondaBackendExceptio
    /// </summary>
    public class FondaBackendException: Exception
	{
		public FondaBackendException () : base() {	}

		public FondaBackendException (string message) : base(message) {	}

        public FondaBackendException(string message, Exception InnerException)
			: base(message, InnerException) {	}
	}
}
