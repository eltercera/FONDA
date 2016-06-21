using com.ds201625.fonda.BackEndLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.FondaBackEndLogic.Exceptions
{
    /// <summary>
    /// Clase DeleteFavoriteRestaurantCommandException
    /// </summary>
    public class DeleteFavoriteRestaurantCommandException : FondaBackendLogicException
    {
        public DeleteFavoriteRestaurantCommandException  () : base() {	}

		public DeleteFavoriteRestaurantCommandException  (string message) : base(message) {	}

        public DeleteFavoriteRestaurantCommandException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
