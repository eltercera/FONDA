using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
    public class FindAccountByRestaurantFondaDAOException : FondaDAOException
    {
        #region Constructors

        public FindAccountByRestaurantFondaDAOException() : base() { }

        public FindAccountByRestaurantFondaDAOException(string message) : base(message) { }

        public FindAccountByRestaurantFondaDAOException(string message, Exception InnerException)
			: base(message, InnerException) { }

        #endregion
    }
}
