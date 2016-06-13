using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.FondaBackEnd.Exceptions
{
    /// <summary>
    /// Clase AddFavoriteRestaurantFondaWebApiControllerException
    /// </summary>
    public class AddFavoriteRestaurantFondaWebApiControllerException : FondaBackendException
    {
        public AddFavoriteRestaurantFondaWebApiControllerException  () : base() {	}

		public AddFavoriteRestaurantFondaWebApiControllerException  (string message) : base(message) {	}

        public AddFavoriteRestaurantFondaWebApiControllerException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
