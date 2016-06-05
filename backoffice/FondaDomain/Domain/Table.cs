using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Domain
{
    /// <summary>
    /// Representa las mesas.
    /// </summary>
    public class Table : BaseEntity
    {
        /// <summary>
		/// La capacidad de la mesa (Mesa de 2, 4, 8, 16 personas)
		/// </summary>
		private int _capacity;


        /// <summary>
		/// El numero unico de la mesa en el restaurate
		/// </summary>
        private int _number;

        /// <summary>
        /// Estado simple de la mesa (Activo, No Activo)
        /// </summary>
        private TableStatus _status;

        [DataMember]
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
