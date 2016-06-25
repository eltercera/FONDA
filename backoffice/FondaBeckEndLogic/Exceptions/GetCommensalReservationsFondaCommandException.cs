using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.ds201625.fonda.BackEndLogic;

namespace com.ds201625.fonda.FondaBackEndLogic.Exceptions
{
    /// <summary>
    /// Clase GetFavoriteRestaurantFondaCommandException
    /// </summary>
    public class GetCommensalReservationsFondaCommandException : FondaBackendLogicException
    {
        public GetCommensalReservationsFondaCommandException() : base() {	}

		public GetCommensalReservationsFondaCommandException(string message) : base(message) {	}

        public GetCommensalReservationsFondaCommandException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
