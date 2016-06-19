using System;
using System.Runtime.Serialization;

namespace com.ds201625.fonda.Domain
{
    /// <summary>
    /// Representa la forma de pago
    /// de la cuenta
    /// </summary>
    public class Payment : BaseEntity
    {

        #region Fields

        /// <summary>
        /// Monto pagado
        /// </summary>
        private float _amount;

        #endregion

        #region Constructors

        public Payment()
        {

        }

        public Payment(float amount)
        {
            this._amount = amount;
        }

        #endregion

        #region Properties

        /// <summary>
        /// obtiene o asigna el monto a pagar
        /// </summary>
        [DataMember]
        public virtual float Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Obtener el tipo de dato del objeto
        /// </summary>
        /// <returns>Retorna un tipo de dato</returns>
        public virtual Type GetTypeUnproxied()
        {
            return GetType();
        }

        #endregion
    }
}
