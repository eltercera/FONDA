using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
    /// <summary>
    /// Representa los errores que se generan al buscar
    /// una entidad por una propiedad especifica en FindByFondaDAO
    /// </summary>
     public class FindByFondaDAOException : FondaDAOException
    {
        public FindByFondaDAOException () : base() {	}

		public FindByFondaDAOException (string message) : base(message) {	}

        public FindByFondaDAOException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
