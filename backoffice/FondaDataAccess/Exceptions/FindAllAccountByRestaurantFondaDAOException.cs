using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
    public class FindAllAccountByRestaurantFondaDAOException : FondaDAOException
    {
        #region Constructors

        public FindAllAccountByRestaurantFondaDAOException() : base() { }

        public FindAllAccountByRestaurantFondaDAOException(string message) : base(message) { }

        public FindAllAccountByRestaurantFondaDAOException(string message, Exception InnerException)
			: base(message, InnerException) { }

        #endregion
    }
}
