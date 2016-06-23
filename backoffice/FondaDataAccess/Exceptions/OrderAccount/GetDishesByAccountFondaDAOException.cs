using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
    public class GetDishesByAccountFondaDAOException : FondaDAOException
    {
        #region Constructors

        public GetDishesByAccountFondaDAOException() : base() { }

        public GetDishesByAccountFondaDAOException(string message) : base(message) { }

        public GetDishesByAccountFondaDAOException(string message, Exception InnerException)
			: base(message, InnerException) { }

        #endregion
    }
}
