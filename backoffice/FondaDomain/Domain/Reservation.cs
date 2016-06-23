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
        #region Fields

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

        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public Reservation() : base()
        {
        }



        /// <summary>
        /// Constructor para crear una reservacion nueva
        /// </summary>
        /// <param name="number">Numero de la reservacion</param>
        /// <param name="reservationDate">Fecha de la reservacion</param>
        /// <param name="commensalNumber">Numero de comensales</param>
        public Reservation(int number, DateTime reservationDate, int commensalNumber) : base()
        {

            this._number = number;
            this._reservationDate = reservationDate;
            this._creationDate = DateTime.Now;
            this._commensalNumber = commensalNumber;
            this._status = new ReservedReservationStatus();

        }
        #endregion

        #region Properties


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

        #endregion

        #region Methods

        /// <summary>
        /// Cambia el estado actual de la reservacion.
        /// </summary>
        public virtual void ChangeStatus()
        {
            _status = _status.Change();
        }

        #endregion
    }
}
