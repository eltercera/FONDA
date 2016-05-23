using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
    class LoadDataTableEmployeeFondaBackOfficeException : FondaBackOfficeException
    {
        public LoadDataTableEmployeeFondaBackOfficeException () : base() {	}

		public LoadDataTableEmployeeFondaBackOfficeException (string message) : base(message) {	}

        public LoadDataTableEmployeeFondaBackOfficeException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
