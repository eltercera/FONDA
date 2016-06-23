using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
    public class FindInvoicesByAccountFondaDAOException : FondaDAOException
    {
        #region Constructors

        public FindInvoicesByAccountFondaDAOException() : base() { }

        public FindInvoicesByAccountFondaDAOException(string message) : base(message) { }

        public FindInvoicesByAccountFondaDAOException(string message, Exception InnerException)
			: base(message, InnerException) { }

        #endregion
    }
}
