using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
    class GetOrderAccountFondaDAOException : FondaDAOException
    {
        #region Constructors

        public GetOrderAccountFondaDAOException() : base() { }

        public GetOrderAccountFondaDAOException(string message) : base(message) { }

        public GetOrderAccountFondaDAOException(string message, Exception InnerException)
			: base(message, InnerException) { }

        #endregion
    }
}
