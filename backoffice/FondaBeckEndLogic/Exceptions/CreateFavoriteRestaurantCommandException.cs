using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.BackEndLogic.Exceptions
{
    public class CreateFavoriteRestaurantCommandException : FondaBackendLogicException
    {
        public CreateFavoriteRestaurantCommandException  () : base() {	}

		public CreateFavoriteRestaurantCommandException (string message) : base(message) {	}

        public CreateFavoriteRestaurantCommandException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
