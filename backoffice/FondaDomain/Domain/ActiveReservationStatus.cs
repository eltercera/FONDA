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
    public class ActiveReservationStatus : ReservationStatus
    {
        /// <summary>
        /// La intancia unica
        /// </summary>
        private static ActiveReservationStatus _instance;

        /// <summary>
		/// Constructor
		/// </summary>
		protected ActiveReservationStatus() : base()
        {
            StatusId = 8;
            Description = "Reservación Activa";
        }

        /// <summary>
        /// Obtiene el Estado Activo de una entidad
        /// </summary>
        public static ActiveReservationStatus Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ActiveReservationStatus();

                return _instance;
            }
        }

        /// <summary>
        /// Retorna una descripcion del estado
        /// </summary>
        /// <returns>Activa en String</returns>
        public override string ToString()
        {
            return "Activa";
        }
    }
}
