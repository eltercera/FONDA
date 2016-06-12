using System;
using System.Runtime.Serialization;

namespace com.ds201625.fonda.Domain
{
    /// <summary>
    /// Representa la factura de una cuenta
    /// </summary>
    public class Invoice : BaseEntity
    {
        /// <summary>
        /// Restaurante al que la factura pertenece
        /// </summary>
        private Restaurant _restaurant;

        /// <summary>
        /// Pago al que la factura pertenece
        /// </summary>
        private Payment _payment;

        /// <summary>
        /// Cuenta a la que la factura pertenece
        /// </summary>
        private Account _account;

        /// <summary>
        /// Profile a la que la factura pertenece
        /// </summary>
        private Profile _profile;

        /// <summary>
        /// Propina de la cuenta
        /// </summary>
        private float _tip;

        /// <summary>
        /// Fecha de pago de la cuenta
        /// </summary>
        private DateTime _date;

        /// <summary>
        /// Monto toal a pagar de la cuenta
        /// </summary>
        private float _total;

        /// <summary>
        /// IVA o tax de la cuenta
        /// </summary>
        private float _tax;

        /// <summary>
        /// Estado de la cuenta
        /// </summary>
        private InvoiceStatus _status;
        
        /// <summary>
        /// Moneda 
        /// </summary>
        private Currency _currency;

        /// <summary>
		/// El numero unico de la factura
		/// </summary>
        private int _number;

        /// <summary>
        /// Constructor
        /// </summary>
        public Invoice() : base() { }

        /// <summary>
        /// Obtiene o asigna una moneda a la factura
        /// </summary>
        [DataMember]
        public virtual Currency Currency
        {
            get { return _currency; }
            set { _currency = value; }
        }


        /// <summary>
        /// Obtiene o asigna una cuenta a la factura
        /// </summary>
        [DataMember]
        public virtual Account Account
        {
            get { return _account; }
            set { _account = value; }
        }

        /// <summary>
        /// Obtiene o asigna un restaurant a la cuenta
        /// </summary>
        [DataMember]
        public virtual Restaurant  Restaurant
        {
            get { return _restaurant; }
            set { _restaurant = value; }
        }

        /// <summary>
        /// Obtiene o asigna un perfil a la cuenta
        /// </summary>
        [DataMember]
        public virtual Profile Profile
        {
            get { return _profile; }
            set { _profile = value; }
        }

        /// <summary>
        /// Obtiene o asigna la propina de la cuenta
        /// </summary>
        [DataMember]
        public virtual float Tip
        {
            get { return _tip; }
            set { _tip = value; }
        }

        /// <summary>
        /// Obtiene o asigna la fecha de pago de la cuenta
        /// </summary>
        [DataMember]
        public virtual DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        /// <summary>
        /// Obtiene o asigna el monto total a pagar de la cuenta
        /// </summary>
        [DataMember]
        public virtual float Total
        {
            get { return _total; }
            set { _total = value; }
        }

        /// <summary>
        /// Obtiene o asigna el IVA
        /// </summary>
        [DataMember]
        public virtual float Tax
        {
            get { return _tax; }
            set { _tax = value; }
        }

        /// <summary>
        /// Obtiene o asigna el numero de la factura
        /// </summary>
        public virtual int Number
        {
            get { return _number; }
            set { _number = value; }
        }

        /// <summary>
        /// Obtiene o asigna el status de la cuenta
        /// </summary>
        public virtual InvoiceStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }
        
        /// <summary>
        /// Obtiene o asigna un pago
        /// </summary>
        public virtual Payment Payment
        {
            get { return _payment; }
            set { _payment = value; }
        }


        /// <summary>
        /// Cambia el estado actual de la factura.
        /// </summary>
        public virtual void changeStatus()
        {
            _status = _status.Change();
        }
    }
}
