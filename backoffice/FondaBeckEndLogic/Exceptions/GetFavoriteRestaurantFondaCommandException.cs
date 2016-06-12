using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.FondaBackEndLogic.Exceptions
{
    public class FindByFavoriteRestaurantFondaWebApiControllerException : FondaBackendLogicException
    {
        public FindByFavoriteRestaurantFondaWebApiControllerException () : base() {	}

		public FindByFavoriteRestaurantFondaWebApiControllerException (string message) : base(message) {	}

        public FindByFavoriteRestaurantFondaWebApiControllerException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
