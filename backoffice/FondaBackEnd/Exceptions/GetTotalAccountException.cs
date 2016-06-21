using com.ds201625.fonda.FondaBackEnd.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.ds201625.fonda.BackEnd.Exceptions
{
    public class GetTotalAccountException : FondaBackendException
    {
        public GetTotalAccountException() : base() { }

        public GetTotalAccountException(string message) : base(message) { }

        public GetTotalAccountException(string message, Exception InnerException)
            : base(message, InnerException) { }
    }
}