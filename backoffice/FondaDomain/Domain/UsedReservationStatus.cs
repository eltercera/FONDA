using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Domain
{
    /// <summary>
    /// Estado usado de una reservacion
    /// </summary>
    public class UsedReservationStatus : ReservationStatus
    {
        /// <summary>
        /// La intancia unica
        /// </summary>
        private static UsedReservationStatus _instance;

        /// <summary>
		/// Constructor
		/// </summary>
		protected UsedReservationStatus() : base()
        {
            StatusId = 9;
            Description = "Reservación Usada";
        }

        /// <summary>
        /// Obtiene el Estado Usado de una entidad
        /// </summary>
        public static UsedReservationStatus Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UsedReservationStatus();

                return _instance;
            }
        }

        /// <summary>
        /// Retorna una descripcion del estado
        /// </summary>
        /// <returns>Usada en String</returns>
        public override string ToString()
        {
            return "Usada";
        }
    }
}
