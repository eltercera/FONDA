using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
    public class FindByIdFondaDAOException : FondaDAOException
    {
        public FindByIdFondaDAOException () : base() {	}

		public FindByIdFondaDAOException (string message) : base(message) {	}

        public FindByIdFondaDAOException (string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
