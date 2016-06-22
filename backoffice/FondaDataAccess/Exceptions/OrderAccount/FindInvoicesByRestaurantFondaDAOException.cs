using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions.OrderAccount
{
    public class FindInvoicesByRestaurantFondaDAOException : FondaDAOException
    {
        #region Constructors

        public FindInvoicesByRestaurantFondaDAOException() : base() { }

        public FindInvoicesByRestaurantFondaDAOException(string message) : base(message) { }

        public FindInvoicesByRestaurantFondaDAOException(string message, Exception InnerException)
			: base(message, InnerException) { }

        #endregion
    }
}
