using System;

namespace com.ds201625.fonda.Domain
{
    public class GeneratedInvoiceStatus : InvoiceStatus
    {
        /// <summary>
		/// La intancia unica
		/// </summary>
		private static GeneratedInvoiceStatus _instance;

        /// <summary>
		/// Consructor
		/// </summary>
		public GeneratedInvoiceStatus() : base ()
		{
			StatusId = 10;
			Description = "Factura Generada";
		}

        /// <summary>
        /// Obtiene el Estado Pagada de una entidad
        /// </summary>
        public static GeneratedInvoiceStatus Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GeneratedInvoiceStatus();

                return _instance;
            }
        }

        /// <summary>
        /// Retorna una descripcion de este estado
        /// </summary>
        /// <returns>Pagado en String</returns>
        public override string ToString()
        {
            return "Pagado";
        }
    }
}
