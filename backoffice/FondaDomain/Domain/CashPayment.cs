using System;

namespace com.ds201625.fonda.Domain
{
    /// <summary>
    /// Representa el pago en efectivo
    /// </summary>
    public class CashPayment : Payment
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public CashPayment() : base ()
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="amount">Monto del pago</param>
        public CashPayment(float amount) : base (amount)
        {
            this.Amount = amount;
        }

        #endregion
    }
}
