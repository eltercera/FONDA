using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
    public class ValidationEmailEmployeeFondaBackOfficeException : FondaBackOfficeException
    {
        public ValidationEmailEmployeeFondaBackOfficeException () : base() {	}

		public ValidationEmailEmployeeFondaBackOfficeException (string message) : base(message) {	}

        public ValidationEmailEmployeeFondaBackOfficeException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
