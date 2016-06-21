using com.ds201625.fonda.DataAccess.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.FondaBackEnd.Exceptions
{
    /// <summary>
    /// Clase FindFavoriteRestaurantFondaWebApiControllerException
    /// </summary>
    public class FindFavoriteRestaurantFondaWebApiControllerException : FondaBackendException
    {
        public FindFavoriteRestaurantFondaWebApiControllerException () : base() {	}

		public FindFavoriteRestaurantFondaWebApiControllerException (string message) : base(message) {	}

        public FindFavoriteRestaurantFondaWebApiControllerException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
