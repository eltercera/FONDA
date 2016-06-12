using System;

namespace com.ds201625.fonda.Domain
{
    /// <summary>
	/// Estado abierto de una entidad
	/// </summary>
    public class OpenAccountStatus : AccountStatus
    {
        /// <summary>
		/// La intancia unica
		/// </summary>
		private static OpenAccountStatus _instance;

        /// <summary>
		/// Consructor
		/// </summary>
		public OpenAccountStatus() : base ()
		{
			StatusId =11;
			Description = "Cuenta de Ordenes Abierta";
		}

        /// <summary>
        /// Obtiene el Estado Abierto de una entidad
        /// </summary>
        public static OpenAccountStatus Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new OpenAccountStatus();

                return _instance;
            }
        }

        /// <summary>
        /// Retrona una descripcion de este estado
        /// </summary>
        /// <returns>Abierto en String</returns>
        public override string ToString()
        {
            return "Abierto";
        }
    }
}
