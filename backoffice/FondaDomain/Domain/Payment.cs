﻿using System;
using System.Runtime.Serialization;

namespace com.ds201625.fonda.Domain
{
    /// <summary>
    /// Representa la forma de pago
    /// de la cuenta
    /// </summary>
    public class Payment : BaseEntity
    {
        /// <summary>
        /// Monto pagado
        /// </summary>
        private float _amount;

        #region Constructor

        public Payment()
        {

        }

        public Payment(float amount)
        {
            this._amount = amount;
        }

        #endregion


        /// <summary>
        /// obtiene o asigna el monto a pagar
        /// </summary>
        [DataMember]
        public virtual float Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
    }
}
