using System;
using System.Runtime.Serialization;

namespace com.ds201625.fonda.Domain
{
    /// <summary>
    /// Representa la factura de una cuenta
    /// </summary>
    public class Invoice : BaseEntity
    {
        #region Fields

        /// <summary>
        /// Pago al que la factura pertenece
        /// </summary>
        private Payment _payment;

        ///// <summary>
        ///// Cuenta a la que la factura pertenece
        ///// </summary>
        //private Account _account;

        /// <summary>
        /// Profile a la que la factura pertenece
        /// </summary>
        private Profile _profile;

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
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public Invoice() : base() { }

        /// <summary>
        /// Constructor de Factura
        /// </summary>
        /// <param name="payment">Pago de la factura</param>
        /// <param name="profile">Perfil de la factura</param>
        /// <param name="total">Total de la factura</param>
        /// <param name="tax">Impuesto de la factura</param>
        /// <param name="currency">Tipo de Moneda</param>
        public Invoice(Payment payment, Profile profile,
         float total, float tax, Currency currency, int number, InvoiceStatus status) 
            : base()
        {
            

            this._payment = payment;
            this._profile = profile;
            this._date = DateTime.Now;
            this._total = total;
            this._tax = tax;

            this._status = status;

            this._currency = currency;
            this._number = number;
        }

        /// <summary>
        /// Constructor de Factura
        /// </summary>
        ///<param name="id">Id de la factura</param>
        /// <param name="payment">Pago de la factura</param>
        /// <param name="profile">Perfil de la factura</param>
        /// <param name="total">Total de la factura</param>
        /// <param name="tax">Impuesto de la factura</param>
        public Invoice( int id,Payment payment, Profile profile, 
            float total, float tax, int number)
            : base()
        {
            this.Id = id;
            this._payment = payment;
            this._profile = profile;
            this._date = DateTime.Now;
            this._total = total;
            this._tax = tax;
            this._status = new GeneratedInvoiceStatus();
            this._number = number;
        }

        /// <summary>
        /// Constructor de Factura sin propina
        /// </summary>
        /// <param name="payment">Pago de la factura</param>
        /// <param name="profile">Perfil de la factura</param>
        /// <param name="total">Total de la factura</param>
        /// <param name="tax">Impuesto de la factura</param>
        /// <param name="currency">Tipo de Moneda</param>
        public Invoice(Payment payment, Profile profile,
            float total, float tax, Currency currency, int number)
            : base()
        {
            this._payment = payment;
            this._profile = profile;
            this._date = DateTime.Now;
            this._total = total;
            this._tax = tax;
            this._status = new GeneratedInvoiceStatus();
            this._currency = currency;
            this._number = number;

        }

        #endregion

        #region Properties
        /// <summary>
        /// Obtiene o asigna una moneda a la factura
        /// </summary>
        [DataMember]
        public virtual Currency Currency
        {
            get { return _currency; }
        }


        ///// <summary>
        ///// Obtiene o asigna una cuenta a la factura
        ///// </summary>
        //[DataMember]
        //public virtual Account Account
        //{
        //    get { return _account; }
        //}

        /// <summary>
        /// Obtiene o asigna un restaurant a la cuenta
        /// </summary>
        //[DataMember]
        //public virtual Restaurant Restaurant
        //{
        //    get { return _restaurant; }
        //}

        /// <summary>
        /// Obtiene o asigna un perfil a la cuenta
        /// </summary>
        [DataMember]
        public virtual Profile Profile
        {
            get { return _profile; }
        }

        /// <summary>
        /// Obtiene o asigna la fecha de pago de la cuenta
        /// </summary>
        [DataMember]
        public virtual DateTime Date
        {
            get { return _date; }
        }

        /// <summary>
        /// Obtiene o asigna el monto total a pagar de la cuenta
        /// </summary>
        [DataMember]
        public virtual float Total
        {
            get { return _total; }
        }

        /// <summary>
        /// Obtiene o asigna el IVA
        /// </summary>
        [DataMember]
        public virtual float Tax
        {
            get { return _tax; }
        }

        /// <summary>
        /// Obtiene o asigna el numero de la factura
        /// </summary>
        public virtual int Number
        {
            get { return _number; }
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
        }
        #endregion

        /// <summary>
        /// Cambia el estado actual de la factura.
        /// </summary>
        public virtual void changeStatus()
        {
            _status = _status.Change();
        }
    }
}
