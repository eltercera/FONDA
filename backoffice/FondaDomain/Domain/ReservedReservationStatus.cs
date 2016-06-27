using com.ds201625.fonda.Resources.FondaResources.Reservation;

namespace com.ds201625.fonda.Domain
{
    /// <summary>
    /// Estado reservada de una reservacion
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
		public ReservedReservationStatus() : base()
        {
            StatusId = 8;
            Description = ReservationResources.ReservedReservationStatusDes;
        }

        /// <summary>
        /// Obtiene el Estado Reservada de una entidad
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
        /// <returns>Reservada en String</returns>
        public override string ToString()
        {
            return ReservationResources.ReservedReservationStatus;
        }
    }
}
