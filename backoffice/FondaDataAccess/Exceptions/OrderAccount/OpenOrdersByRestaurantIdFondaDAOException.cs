using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
    public class OpenOrdersByRestaurantIdFondaDAOException : FondaDAOException
    {
        #region Constructors

        public OpenOrdersByRestaurantIdFondaDAOException() : base() { }

        public OpenOrdersByRestaurantIdFondaDAOException(string message) : base(message) { }

        public OpenOrdersByRestaurantIdFondaDAOException(string message, Exception InnerException)
			: base(message, InnerException) { }

        #endregion
    }
}
