using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions.Restaurant
{
    public class GetAllZonesFondaDAOException : FondaDAOException
    {
        #region Constructors
        public GetAllZonesFondaDAOException() : base() { }

        public GetAllZonesFondaDAOException(string message) : base(message) { }

        public GetAllZonesFondaDAOException(string message, Exception InnerException)
            : base(message, InnerException) { }
        #endregion
    }
}
