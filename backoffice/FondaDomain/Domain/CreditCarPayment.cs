using System;
using System.Runtime.Serialization;

namespace com.ds201625.fonda.Domain
{
    /// <summary>
    /// Representa el pago con tarjeta
    /// </summary>
    public class CreditCarPayment : Payment
    {
        /// <summary>
        /// Ultimos 4 digitos de la tarjeta
        /// </summary>
        private int lastCardDigits;

        /// <summary>
        /// Obtiene o asigna el valor de los digitos de la tarjeta
        /// </summary>
        [DataMember]
        public virtual int LastCardDigits
        {
            get { return lastCardDigits; }
            set { lastCardDigits = value; }
        }
    }
}
