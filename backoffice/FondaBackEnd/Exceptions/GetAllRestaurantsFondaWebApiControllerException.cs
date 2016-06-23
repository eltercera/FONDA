using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.FondaBackEnd.Exceptions
{
    /// <summary>
    /// Clase GetAllRestaurantsFondaWebApiControllerException 
    /// </summary>
    public class GetAllRestaurantsFondaWebApiControllerException : FondaBackendException
    {
        public GetAllRestaurantsFondaWebApiControllerException () : base() {	}

		public GetAllRestaurantsFondaWebApiControllerException (string message) : base(message) {	}

        public GetAllRestaurantsFondaWebApiControllerException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
