using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.FondaBackEndLogic.Exceptions
{
    public class FondaBackendLogicException: Exception
	{
		public FondaBackendLogicException () : base() {	}

		public FondaBackendLogicException (string message) : base(message) {	}

        public FondaBackendLogicException(string message, Exception InnerException)
			: base(message, InnerException) {	}
	}
}
