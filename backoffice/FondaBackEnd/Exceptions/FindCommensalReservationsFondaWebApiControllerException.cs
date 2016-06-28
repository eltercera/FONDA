using com.ds201625.fonda.DataAccess.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.FondaBackEnd.Exceptions
{
    /// <summary>
    /// Clase FindFavoriteRestaurantFondaWebApiControllerException
    /// </summary>
    public class FindCommensalReservationsFondaWebApiControllerException : FondaBackendException
    {
        public FindCommensalReservationsFondaWebApiControllerException() : base() {	}

		public FindCommensalReservationsFondaWebApiControllerException(string message) : base(message) {	}

        public FindCommensalReservationsFondaWebApiControllerException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
