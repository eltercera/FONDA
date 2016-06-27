using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions.Restaurant
{
    public class GetAllRestaurantsFondaDAOException : FondaDAOException
    {
        #region Constructors
        public GetAllRestaurantsFondaDAOException() : base() { }

        public GetAllRestaurantsFondaDAOException(string message) : base(message) { }

        public GetAllRestaurantsFondaDAOException(string message, Exception InnerException)
            : base(message, InnerException) { }
        #endregion
    }
}
