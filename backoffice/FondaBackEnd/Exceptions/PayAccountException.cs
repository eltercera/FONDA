using com.ds201625.fonda.FondaBackEnd.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.ds201625.fonda.BackEnd.Exceptions
{
    public class PayAccountException : FondaBackendException
    {
        public PayAccountException() : base() { }

        public PayAccountException(string message) : base(message) { }

        public PayAccountException(string message, Exception InnerException)
            : base(message, InnerException) { }
    
}
}