using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
    public class FindByEmailUserAccountFondaDAOException : FondaDAOException
    {
        public FindByEmailUserAccountFondaDAOException () : base() {	}

		public FindByEmailUserAccountFondaDAOException (string message) : base(message) {	}

        public FindByEmailUserAccountFondaDAOException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
