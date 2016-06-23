using com.ds201625.fonda.FondaBackEnd.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.ds201625.fonda.BackEnd.Exceptions
{
    public class GetOrderDetailException : FondaBackendException
    {
        public GetOrderDetailException() : base() { }

        public GetOrderDetailException(string message) : base(message) { }

        public GetOrderDetailException(string message, Exception InnerException)
            : base(message, InnerException) { }
    }
}