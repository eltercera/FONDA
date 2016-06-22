using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Domain
{
    /// <summary>
    /// Estados posibles de la Clase Reservation
    /// </summary>
	public abstract class ReservationStatus : Status
    {
        /// <summary>
        /// Constructor
        /// </summary>
		protected ReservationStatus() : base() { }

        public virtual ReservationStatus ReserveStatus()
        {
            if (Equals(ReservedReservationStatus.Instance))
                return CanceledReservationStatus.Instance;

            return ReservedReservationStatus.Instance;


        }

    }
}
