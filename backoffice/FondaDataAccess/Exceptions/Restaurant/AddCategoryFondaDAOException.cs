using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions.Restaurant
{
    public class AddCategoryFondaDAOException : FondaDAOException
    {
        #region Constructors
        public AddCategoryFondaDAOException() : base() { }

        public AddCategoryFondaDAOException(string message) : base(message) { }

        public AddCategoryFondaDAOException(string message, Exception InnerException)
            : base(message, InnerException) { }
        #endregion
    }
}
