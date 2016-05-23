using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
    public class FondaBackOfficeException: Exception
	{
		public FondaBackOfficeException () : base() {	}

		public FondaBackOfficeException (string message) : base(message) {	}

        public FondaBackOfficeException(string message, Exception InnerException)
			: base(message, InnerException) {	}
	}
}
