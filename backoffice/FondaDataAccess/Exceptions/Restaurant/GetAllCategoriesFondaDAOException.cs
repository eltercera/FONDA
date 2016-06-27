using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions.Restaurant
{
    public class GetAllCategoriesFondaDAOException : FondaDAOException
    {
        #region Constructors
        public GetAllCategoriesFondaDAOException() : base() { }

        public GetAllCategoriesFondaDAOException(string message) : base(message) { }

        public GetAllCategoriesFondaDAOException(string message, Exception InnerException)
            : base(message, InnerException) { }
        #endregion
    }
}
