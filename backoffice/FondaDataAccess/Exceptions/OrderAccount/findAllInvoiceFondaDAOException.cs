using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions.OrderAccount
{
    public class FindAllInvoiceFondaDAOException : FondaDAOException
    {
        #region Constructors

        public FindAllInvoiceFondaDAOException() : base() { }

        public FindAllInvoiceFondaDAOException(string message) : base(message) { }

        public FindAllInvoiceFondaDAOException(string message, Exception InnerException)
			: base(message, InnerException) { }

        #endregion
    }
}
