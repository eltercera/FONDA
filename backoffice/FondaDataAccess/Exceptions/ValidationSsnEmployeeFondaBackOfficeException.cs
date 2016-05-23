using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
    public class ValidationSsnEmployeeFondaBackOfficeException: FondaBackOfficeException
    {
        public ValidationSsnEmployeeFondaBackOfficeException () : base() {	}

		public ValidationSsnEmployeeFondaBackOfficeException (string message) : base(message) {	}

        public ValidationSsnEmployeeFondaBackOfficeException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
