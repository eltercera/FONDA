using System;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
	public class FondaDAOException : Exception
	{
		public FondaDAOException () : base() {	}

		public FondaDAOException (string message) : base(message) {	}

		public  FondaDAOException (string message, Exception InnerException)
			: base(message, InnerException) {	}
	}
}

