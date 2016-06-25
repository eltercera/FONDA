using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions.Restaurant
{
    public class ModifyCategoryFondaDAOException : FondaDAOException
    {
        #region Constructors
        public ModifyCategoryFondaDAOException() : base() { }

        public ModifyCategoryFondaDAOException(string message) : base(message) { }

        public ModifyCategoryFondaDAOException(string message, Exception InnerException)
            : base(message, InnerException) { }
        #endregion
    }
}
