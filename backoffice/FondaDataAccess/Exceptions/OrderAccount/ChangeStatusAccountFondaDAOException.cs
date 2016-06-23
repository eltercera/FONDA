using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
    public class ChangeStatusAccountFondaDAOException : FondaDAOException
    {
        #region Constructors

        public ChangeStatusAccountFondaDAOException() : base() { }

        public ChangeStatusAccountFondaDAOException(string message) : base(message) { }

        public ChangeStatusAccountFondaDAOException(string message, Exception InnerException)
			: base(message, InnerException) { }

        #endregion
    }

}
