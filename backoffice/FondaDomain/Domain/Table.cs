using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Domain
/// <summary>
/// Representa las mesas.
/// </summary>
{
    public class Table
    {
        /// <summary>
		/// El number es el numero único por el que se identifica cada mesa 
		/// </summary>
		private int _number;
        /// <summary>
		/// La capacidad de la mesa (Mesa de 2, 4, 8, 16 personas)
		/// </summary>
		private int _capacity;
        
        /// <summary>
        /// Estado simple de la mesa (Disponible, No Disponible)
        /// </summary>
        private TableStatus _status;

        public virtual int Number
        {
            get { return _number; }
            set { _number = value; }
        }

        public virtual int Capacity
        {
            get { return _capacity; }
            set { _capacity = value; }
        }

        public virtual TableStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }

    }
}
