using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.FondaBackEndLogic.Exceptions
{
    public class GetFavoriteRestaurantFondaCommandException : FondaBackendLogicException
    {
        public GetFavoriteRestaurantFondaCommandException () : base() {	}

		public GetFavoriteRestaurantFondaCommandException (string message) : base(message) {	}

        public GetFavoriteRestaurantFondaCommandException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
