using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions.OrderAccount
{
    public class ReleaseTableFondaDAOException : FondaDAOException
    {
        #region Constructors

        public ReleaseTableFondaDAOException() : base() { }

        public ReleaseTableFondaDAOException(string message) : base(message) { }

        public ReleaseTableFondaDAOException(string message, Exception InnerException)
			: base(message, InnerException) { }

        #endregion
    }
}
