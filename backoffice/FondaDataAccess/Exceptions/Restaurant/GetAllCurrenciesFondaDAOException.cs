using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions.Restaurant
{
    public class GetAllCurrenciesFondaDAOException : FondaDAOException
    {
        #region Constructors
        public GetAllCurrenciesFondaDAOException() : base() { }

        public GetAllCurrenciesFondaDAOException(string message) : base(message) { }

        public GetAllCurrenciesFondaDAOException(string message, Exception InnerException)
            : base(message, InnerException) { }
        #endregion
    }    
}
