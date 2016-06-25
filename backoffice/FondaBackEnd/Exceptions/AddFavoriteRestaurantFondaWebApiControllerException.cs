using System;

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
