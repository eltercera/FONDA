using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
    public class ClosedOrdersByRestaurantFondaDAOException : FondaDAOException
    {
        #region Constructors

        public ClosedOrdersByRestaurantFondaDAOException() : base() { }

        public ClosedOrdersByRestaurantFondaDAOException(string message) : base(message) { }

        public ClosedOrdersByRestaurantFondaDAOException(string message, Exception InnerException)
			: base(message, InnerException) { }

        #endregion
    }
}
