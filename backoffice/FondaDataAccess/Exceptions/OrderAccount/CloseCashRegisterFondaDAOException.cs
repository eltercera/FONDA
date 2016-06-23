using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
    public class CloseCashRegisterFondaDAOException : FondaDAOException
    {
        #region Constructors

        public CloseCashRegisterFondaDAOException() : base() { }

        public CloseCashRegisterFondaDAOException(string message) : base(message) { }

        public CloseCashRegisterFondaDAOException(string message, Exception InnerException)
			: base(message, InnerException) { }

        #endregion
    }
}
