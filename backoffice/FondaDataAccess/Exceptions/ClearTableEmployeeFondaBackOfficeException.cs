using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
    public class ClearTableEmployeeFondaBackOfficeException: FondaBackOfficeException
    {
        public ClearTableEmployeeFondaBackOfficeException () : base() {	}

		public ClearTableEmployeeFondaBackOfficeException (string message) : base(message) {	}

        public ClearTableEmployeeFondaBackOfficeException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
