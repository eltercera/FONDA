using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
    public class AddEmployeeFondaBackOfficeException : FondaBackOfficeException
    {
        public AddEmployeeFondaBackOfficeException () : base() {	}

		public AddEmployeeFondaBackOfficeException (string message) : base(message) {	}

        public AddEmployeeFondaBackOfficeException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
