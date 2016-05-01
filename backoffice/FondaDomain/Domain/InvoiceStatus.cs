using System;

namespace com.ds201625.fonda.Domain
{
    public abstract class InvoiceStatus : Status
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public InvoiceStatus() : base()	{ }

        /// <summary>
        /// Cambio el estado de una entidad
        /// </summary>
        /// <returns> retorna el estado de la entidad</returns>
        public InvoiceStatus Change()
        {
            if (Equals(GeneratedInvoiceStatus.Instance))
                return CanceledInvoiceStatus.Instance;

            return GeneratedInvoiceStatus.Instance;
        }

    }
}
