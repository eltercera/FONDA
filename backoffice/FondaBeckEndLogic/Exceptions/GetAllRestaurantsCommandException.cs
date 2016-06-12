using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.BackEndLogic.Exceptions
{
    public class GetAllRestaurantsCommandException : FondaBackendLogicException
    {
        public GetAllRestaurantsCommandException () : base() {	}

		public GetAllRestaurantsCommandException(string message) : base(message) {	}

        public GetAllRestaurantsCommandException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
