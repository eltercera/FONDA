using System;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
    /// <summary>
    /// Representa los errores que se generan al guardar
    /// una entidad en SaveEntityFondaDAO
    /// </summary>
	public class SaveEntityFondaDAOException : FondaDAOException
	{
		public SaveEntityFondaDAOException () : base() {	}

		public SaveEntityFondaDAOException (string message) : base(message) {	}

		public  SaveEntityFondaDAOException (string message, Exception InnerException)
			: base(message, InnerException) {	}
	}
}

