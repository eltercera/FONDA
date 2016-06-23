using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
    public class CancelInvoiceFondaDAOException : FondaDAOException
    {
        #region Constructors

        public CancelInvoiceFondaDAOException() : base() { }

        public CancelInvoiceFondaDAOException(string message) : base(message) { }

        public CancelInvoiceFondaDAOException(string message, Exception InnerException)
			: base(message, InnerException) { }

        #endregion
    }


}
