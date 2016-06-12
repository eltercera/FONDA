using com.ds201625.fonda.DataAccess.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.FondaBackEnd.Exceptions
{
    public class FindByFavoriteRestaurantFondaWebApiControllerException : FondaBackendException
    {
        public FindByFavoriteRestaurantFondaWebApiControllerException () : base() {	}

		public FindByFavoriteRestaurantFondaWebApiControllerException (string message) : base(message) {	}

        public FindByFavoriteRestaurantFondaWebApiControllerException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
