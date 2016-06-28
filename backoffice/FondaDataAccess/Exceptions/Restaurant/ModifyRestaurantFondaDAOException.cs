using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions.Restaurant
{
    public class ModifyRestaurantFondaDAOException : FondaDAOException
    {
        #region Constructors
        public ModifyRestaurantFondaDAOException() : base() { }

        public ModifyRestaurantFondaDAOException(string message) : base(message) { }

        public ModifyRestaurantFondaDAOException(string message, Exception InnerException)
            : base(message, InnerException) { }
        #endregion
    }
}
