using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Domain
{
    /// <summary>
    /// Estado disponible de una mesa
    /// </summary>
    public class FreeTableStatus : TableStatus
    {
        /// <summary>
        /// La intancia unica
        /// </summary>
        private static FreeTableStatus _instance;

        /// <summary>
		/// Consructor
		/// </summary>
		public FreeTableStatus() : base () { }

        /// <summary>
        /// Obtiene el Estado Disponible de una entidad
        /// </summary>
        public static FreeTableStatus Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FreeTableStatus();

                return _instance;
            }
        }

        /// <summary>
        /// Retorna una descripcion del estado
        /// </summary>
        /// <returns>Disponible en String</returns>
        public override string ToString()
        {
            return "Disponible";
        }
    }
}
