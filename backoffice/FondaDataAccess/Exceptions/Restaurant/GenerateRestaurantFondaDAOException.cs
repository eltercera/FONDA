using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions.Restaurant
{
    public class GenerateRestaurantFondaDAOException : FondaDAOException
    {
        #region Constructors
        public GenerateRestaurantFondaDAOException() : base() { }

        public GenerateRestaurantFondaDAOException(string message) : base(message) { }

        public GenerateRestaurantFondaDAOException(string message, Exception InnerException)
            : base(message, InnerException) { }
        #endregion
    }
}
