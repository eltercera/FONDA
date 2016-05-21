using System;
using System.Collections.Generic;
using System.Linq;
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
        /// Estado simple de la mesa (Activo, No Activo)
        /// </summary>
        private TableStatus _status;

        /// <summary>
        /// Estado simple de la mesa (Activo, No Activo)
        /// </summary>
        private Restaurant _restaurant;

        public override int GetHashCode()
        {
            int hashCode = 0;
            hashCode = hashCode ^ Id.GetHashCode() ^ Restaurant.GetHashCode();
            return hashCode;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Table;

            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return this.Id == other.Id && this.Restaurant == other.Restaurant;
        }

        public virtual Restaurant Restaurant
        {
            get { return _restaurant; }
            set { _restaurant = value; }
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
