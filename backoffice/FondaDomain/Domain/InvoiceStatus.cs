using System;

namespace com.ds201625.fonda.Domain
{
    public abstract class InvoiceStatus : Status
    {
        /// <summary>
        /// Constructor
        /// </summary>
		protected InvoiceStatus() : base()	{ }

        /// <summary>
        /// Cambio el estado de una entidad
        /// </summary>
        /// <returns> retorna el estado de la entidad</returns>
        public virtual InvoiceStatus Change()
        {
            if (Equals(GeneratedInvoiceStatus.Instance))
                return CanceledInvoiceStatus.Instance;

            return GeneratedInvoiceStatus.Instance;
        }

    }
}
