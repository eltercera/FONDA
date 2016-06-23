using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
    /// <summary>
    /// Representa los errores que se generan al buscar
    /// una lista de entidades en FindAllFondaDAO
    /// </summary>
    public class FindAllFondaDAOException : FondaDAOException
    {
         public FindAllFondaDAOException () : base() {	}

		public FindAllFondaDAOException (string message) : base(message) {	}

        public FindAllFondaDAOException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
