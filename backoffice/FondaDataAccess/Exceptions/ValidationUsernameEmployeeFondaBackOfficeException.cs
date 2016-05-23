using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
    public class ValidationUsernameEmployeeFondaBackOfficeException : FondaBackOfficeException
    {
        public ValidationUsernameEmployeeFondaBackOfficeException () : base() {	}

		public ValidationUsernameEmployeeFondaBackOfficeException (string message) : base(message) {	}

        public ValidationUsernameEmployeeFondaBackOfficeException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
