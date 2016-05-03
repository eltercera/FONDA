using System;

namespace com.ds201625.fonda.Domain
{
    class CanceledInvoiceStatus : InvoiceStatus
    {
        /// <summary>
		/// La intancia unica
		/// </summary>
		private static CanceledInvoiceStatus _instance;

        /// <summary>
		/// Consructor
		/// </summary>
		public CanceledInvoiceStatus() : base ()
		{
			StatusId = 9;
			Description = "Factura Candelada";
		}

        /// <summary>
        /// Obtiene el Estado Cancelado de una entidad
        /// </summary>
        public static CanceledInvoiceStatus Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CanceledInvoiceStatus();

                return _instance;
            }
        }

        /// <summary>
        /// Retrona una descripcion de este estado
        /// </summary>
        /// <returns>Cancelado en String</returns>
        public override string ToString()
        {
            return "Cancelado";
        }
    }
}
