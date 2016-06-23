using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.ds201625.fonda.BackEndLogic;

namespace com.ds201625.fonda.FondaBackEndLogic.Exceptions
{
    /// <summary>
    /// Clase CreateFavoriteRestaurantCommandException.
    /// </summary>
    public class CreateCommensalReservationCommandException : FondaBackendLogicException
    {
        public CreateCommensalReservationCommandException() : base() {	}

		public CreateCommensalReservationCommandException(string message) : base(message) {	}

        public CreateCommensalReservationCommandException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
