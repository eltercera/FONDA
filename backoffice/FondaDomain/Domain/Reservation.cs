using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Domain
{
    /// <summary>
    /// Representa las reservaciones.
    /// </summary>
    public class Reservation : BaseEntity
    {

        /// <summary>
        /// Numero de la reservacion
        /// </summary>
        private int _number;

        /// <summary>
        /// Fecha de reservación
        /// </summary>
        private DateTime _reservationDate;

        /// <summary>
        /// Fecha en la que fue hecha la reservación
        /// </summary>
        private DateTime _creationDate;

        /// <summary>
        /// Número de comensales
        /// </summary>
        private int _commensalNumber;

        /// <summary>
        /// Estado de la reserva
        /// </summary>
        private ReservationStatus _status;


        /// <summary>
		/// Constructor
		/// </summary>
		public Reservation() : base () { }


        public virtual int Number
        {
            get { return _number; }
            set { _number = value; }
        }

        public virtual DateTime ReservationDate
        {
            get { return _reservationDate; }
            set { _reservationDate = value; }
        }

        public virtual DateTime CreationDate
        {
            get { return _creationDate; }
            set { _creationDate = value; }
        }

        public virtual int CommensalNumber
        {
            get { return _commensalNumber; }
            set { _commensalNumber = value; }
        }

        public virtual ReservationStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }


    }
}
