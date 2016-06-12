using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.FondaBackEnd.Exceptions
{
    public class GetAllRestaurantsFondaException : FondaBackendException
    {
        public GetAllRestaurantsFondaException () : base() {	}

		public GetAllRestaurantsFondaException (string message) : base(message) {	}

        public GetAllRestaurantsFondaException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
