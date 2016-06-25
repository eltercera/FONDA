using System;

namespace com.ds201625.fonda.FondaBackEnd.Exceptions
{
    /// <summary>
    /// Clase DeleteFavoriteRestaurantFondaWebApiControllerException
    /// </summary>
    public class DeleteFavoriteRestaurantFondaWebApiControllerException : FondaBackendException
    {
        public DeleteFavoriteRestaurantFondaWebApiControllerException () : base() {	}

		public DeleteFavoriteRestaurantFondaWebApiControllerException (string message) : base(message) {	}

        public DeleteFavoriteRestaurantFondaWebApiControllerException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
