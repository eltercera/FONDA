using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
    public class LoadTabletEmployeeFondaBackOfficeException : FondaBackOfficeException
    {
        public LoadTabletEmployeeFondaBackOfficeException () : base() {	}

		public LoadTabletEmployeeFondaBackOfficeException (string message) : base(message) {	}

        public LoadTabletEmployeeFondaBackOfficeException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
