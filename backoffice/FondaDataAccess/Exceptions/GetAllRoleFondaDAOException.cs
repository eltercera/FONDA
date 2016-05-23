using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
    public class GetAllRoleFondaDAOException : FondaDAOException
    {
        public GetAllRoleFondaDAOException () : base() {	}

		public GetAllRoleFondaDAOException (string message) : base(message) {	}

        public GetAllRoleFondaDAOException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
