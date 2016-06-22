using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
    public class GenerateNumberInvoiceFondaDAOException : FondaDAOException
    {
        #region Constructors

        public GenerateNumberInvoiceFondaDAOException() : base() { }

        public GenerateNumberInvoiceFondaDAOException(string message) : base(message) { }

        public GenerateNumberInvoiceFondaDAOException(string message, Exception InnerException)
			: base(message, InnerException) { }

        #endregion
    }
}
