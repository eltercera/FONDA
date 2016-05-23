using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
     public class FindByFondaDAOException : FondaDAOException
    {
        public FindByFondaDAOException () : base() {	}

		public FindByFondaDAOException (string message) : base(message) {	}

        public FindByFondaDAOException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
