using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
    public class findAllInvoiceFondaDAOException : FondaDAOException
    {
        #region Constructors

        public findAllInvoiceFondaDAOException() : base() { }

        public findAllInvoiceFondaDAOException(string message) : base(message) { }

        public findAllInvoiceFondaDAOException(string message, Exception InnerException)
			: base(message, InnerException) { }

        #endregion
    }
}
