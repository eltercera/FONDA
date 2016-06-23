using System;

namespace com.ds201625.fonda.DataAccess.FondaDAOExceptions
{
    public class FondaIndexException : Exception
    {
        public FondaIndexException() : base() { }

        public FondaIndexException(string message) : base(message) { }

        public FondaIndexException(string message, Exception InnerException)
			: base(message, InnerException) { }
    }
}
