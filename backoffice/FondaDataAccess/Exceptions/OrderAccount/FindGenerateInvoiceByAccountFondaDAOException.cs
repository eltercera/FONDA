using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
    public class FindGenerateInvoiceByAccountFondaDAOException : FondaDAOException
    {
        #region Constructors

        public FindGenerateInvoiceByAccountFondaDAOException() : base() { }

        public FindGenerateInvoiceByAccountFondaDAOException(string message) : base(message) { }

        public FindGenerateInvoiceByAccountFondaDAOException(string message, Exception InnerException)
			: base(message, InnerException) { }

        #endregion
    }
}
