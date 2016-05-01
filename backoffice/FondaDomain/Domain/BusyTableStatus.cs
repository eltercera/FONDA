using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Domain
{
    /// <summary>
    /// Estado ocupado de la Mesa
    /// </summary>
    public class BusyTableStatus : TableStatus
    {
        /// <summary>
        /// La intancia unica
        /// </summary>
        private static BusyTableStatus _instance;

        /// <summary>
		/// Consructor
		/// </summary>
		public BusyTableStatus() : base () { }

        /// <summary>
        /// Obtiene el Estado Ocupado de una entidad
        /// </summary>
        public static BusyTableStatus Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BusyTableStatus();

                return _instance;
            }
        }

        /// <summary>
        /// Retorna una descripcion del estado
        /// </summary>
        /// <returns>Ocupada en String</returns>
        public override string ToString()
        {
            return "Ocupada";
        }

    }
}
