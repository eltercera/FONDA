using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.FondaBackEnd.Exceptions
{
    public class DeleteFavoriteRestaurantFondaWebApiControllerException : FondaBackendException
    {
        public DeleteFavoriteRestaurantFondaWebApiControllerException () : base() {	}

		public DeleteFavoriteRestaurantFondaWebApiControllerException (string message) : base(message) {	}

        public DeleteFavoriteRestaurantFondaWebApiControllerException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
