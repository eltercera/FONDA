using System;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
    /// <summary>
    /// Representa los errores que se generan FondaDAO
    /// </summary>
	public class FondaDAOException : Exception
	{
		public FondaDAOException () : base() {	}

		public FondaDAOException (string message) : base(message) {	}

		public  FondaDAOException (string message, Exception InnerException)
			: base(message, InnerException) {	}
	}
}

