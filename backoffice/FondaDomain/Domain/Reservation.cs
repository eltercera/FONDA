using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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
        /// Fecha de reservación
        /// </summary>
        private DateTime _reserveDate;

        /// <summary>
        /// Fecha en la que fue hecha la reservación
        /// </summary>
        private DateTime _createDate;

        /// <summary>
        /// Número de comensales
        /// </summary>
        private int _commensalNumber;

        /// <summary>
        /// Restaurante donde se reservó
        /// </summary>
        private Restaurant _restaurant;

        /// <summary>
        /// Mesa reservada
        /// </summary>
        private Table _table;

        /// <summary>
        /// Estado de la reserva
        /// </summary>
        private ReservationStatus _reserveStatus;

        /// <summary>
		/// Constructor
		/// </summary>
		public Reservation() : base () { }

        [DataMember]
        public virtual DateTime ReserveDate
        {
            get { return _reserveDate; }
            set { _reserveDate = value; }
        }

        public virtual DateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }

        [DataMember]
        public virtual int CommensalNumber
        {
            get { return _commensalNumber; }
            set { _commensalNumber = value; }
        }

        public virtual Restaurant ReserveRestaurant
        {
            get { return _restaurant; }
            set { _restaurant = value; }
        }

        public virtual Table ReserveTable
        {
            get { return _table; }
            set { _table = value; }
        }

        public virtual ReservationStatus ReserveStatus
        {
            get { return _reserveStatus; }
            set { _reserveStatus = value; }
        }


    }
}
