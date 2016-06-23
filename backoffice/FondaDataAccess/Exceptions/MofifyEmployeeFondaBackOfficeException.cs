using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
    public class MofifyEmployeeFondaBackOfficeException : FondaBackOfficeException
    {
        public MofifyEmployeeFondaBackOfficeException () : base() {	}

		public MofifyEmployeeFondaBackOfficeException (string message) : base(message) {	}

        public MofifyEmployeeFondaBackOfficeException (string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
