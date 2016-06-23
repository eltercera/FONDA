using com.ds201625.fonda.FondaBackEnd.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.ds201625.fonda.BackEnd.Exceptions
{
    public class GetPaymentHistoryByProfileException : FondaBackendException
    {
        public GetPaymentHistoryByProfileException() : base() { }

        public GetPaymentHistoryByProfileException(string message) : base(message) { }

        public GetPaymentHistoryByProfileException(string message, Exception InnerException)
			: base(message, InnerException) { }
    }
}