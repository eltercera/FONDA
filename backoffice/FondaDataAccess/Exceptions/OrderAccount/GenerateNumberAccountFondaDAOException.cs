using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
    public class GenerateNumberAccountFondaDAOException : FondaDAOException
    {
        #region Constructors

        public GenerateNumberAccountFondaDAOException() : base() { }

        public GenerateNumberAccountFondaDAOException(string message) : base(message) { }

        public GenerateNumberAccountFondaDAOException(string message, Exception InnerException)
			: base(message, InnerException) { }

        #endregion
    }
}
