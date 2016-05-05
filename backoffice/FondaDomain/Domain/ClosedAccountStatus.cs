using System;

namespace com.ds201625.fonda.Domain
{
    public class ClosedAccountStatus : AccountStatus
    {
        /// <summary>
		/// La intancia unica
		/// </summary>
		private static ClosedAccountStatus _instance;

        /// <summary>
		/// Consructor
		/// </summary>
		protected ClosedAccountStatus() : base ()
		{
			StatusId = 8;
			Description = "Cuenta de Ordenes Cerrada";
		}

        /// <summary>
        /// Obtiene el Estado Cerrado de una entidad
        /// </summary>
        public static ClosedAccountStatus Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ClosedAccountStatus();

                return _instance;
            }
        }

        /// <summary>
        /// Retrona una descripcion de este estado
        /// </summary>
        /// <returns>Cerrado en String</returns>
        public override string ToString()
        {
            return "Cerrado";
        }
    }
}
