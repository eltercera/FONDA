using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
    public class DeleteFondaDAOException : FondaDAOException
    {
        public DeleteFondaDAOException () : base() {	}

		public DeleteFondaDAOException (string message) : base(message) {	}

        public DeleteFondaDAOException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
