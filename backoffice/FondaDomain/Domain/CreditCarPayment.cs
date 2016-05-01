using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Domain
{
    /// <summary>
    /// Representa el pago con tarjeta
    /// </summary>
    class CreditCarPayment : Payment
    {
        /// <summary>
        /// Ultimos 4 digitos de la tarjeta
        /// </summary>
        private int lastCardDigits;

        /// <summary>
        /// Obtiene o asigna el valor de los digitos de la tarjeta
        /// </summary>
        public virtual int LastCardDigits
        {
            get { return lastCardDigits; }
            set { lastCardDigits = value; }
        }
    }
}
