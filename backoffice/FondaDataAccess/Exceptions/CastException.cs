using System;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
    public class CastException : Exception
    {
        public CastException() : base() { }

        public CastException(string message) : base(message) { }

        public CastException(string message, Exception InnerException)
            : base(message, InnerException)
        { }
    }
}
