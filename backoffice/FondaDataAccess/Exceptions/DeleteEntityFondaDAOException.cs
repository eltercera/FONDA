using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
    /// <summary>
    /// Representa los errores que se generan al eliminar
    /// una entidad en DeleteEntityFondaDAO
    /// </summary>
    public class DeleteEntityFondaDAOException: FondaDAOException
    {
        public DeleteEntityFondaDAOException () : base() {	}

		public DeleteEntityFondaDAOException (string message) : base(message) {	}

        public DeleteEntityFondaDAOException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
