using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Domain
{
    /// <summary>
    /// Estado activa de una reservacion
    /// </summary>
    public class ReservedReservationStatus : ReservationStatus
    {
        /// <summary>
        /// La intancia unica
        /// </summary>
        private static ReservedReservationStatus _instance;

        /// <summary>
		/// Constructor
		/// </summary>
		protected ReservedReservationStatus() : base()
        {
            StatusId = 8;
            Description = "Reservación realizada";
        }

        /// <summary>
        /// Obtiene el Estado Activo de una entidad
        /// </summary>
        public static ReservedReservationStatus Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ReservedReservationStatus();

                return _instance;
            }
        }

        /// <summary>
        /// Retorna una descripcion del estado
        /// </summary>
        /// <returns>Activa en String</returns>
        public override string ToString()
        {
            return "Reservada";
        }
    }
}
