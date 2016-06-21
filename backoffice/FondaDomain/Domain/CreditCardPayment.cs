using System;
using System.Runtime.Serialization;

namespace com.ds201625.fonda.Domain
{
    /// <summary>
    /// Representa el pago con tarjeta
    /// </summary>
    public class CreditCardPayment : Payment
    {
        #region Fields

        /// <summary>
        /// Ultimos 4 digitos de la tarjeta
        /// </summary>
        private int lastCardDigits;
        /// <summary>
        /// Propina
        /// </summary>
        private float _tip;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public CreditCardPayment() : base ()
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="amout">Monto del pago</param>
        /// <param name="lastDigits">Ultimos digitos de la tarjeta</param>
        public CreditCardPayment(float amout, int lastDigits, float tip) : base (amout)
        {
            this.Amount = amout;
            this.lastCardDigits = lastDigits;
            this._tip = tip;
        }

        #endregion

        /// <summary>
        /// Obtiene o asigna el valor de los digitos de la tarjeta
        /// </summary>
        [DataMember]
        public virtual int LastCardDigits
        {
            get { return lastCardDigits; }
        }

        public virtual float Tip
        {
            get { return _tip; }
        }
    }
}
