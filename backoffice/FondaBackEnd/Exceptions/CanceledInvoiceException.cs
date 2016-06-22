using com.ds201625.fonda.FondaBackEnd.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.ds201625.fonda.BackEnd.Exceptions
{
    public class CanceledInvoiceException : FondaBackendException
    {
        public CanceledInvoiceException() : base() { }

        public CanceledInvoiceException(string message) : base(message) { }

        public CanceledInvoiceException(string message, Exception InnerException)
            : base(message, InnerException) { }
    }
}