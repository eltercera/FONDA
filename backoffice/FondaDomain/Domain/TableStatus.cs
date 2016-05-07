using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Domain
{
    /// <summary>
    /// Estados posibles de la Clase Table
    /// </summary>
	public abstract class TableStatus : Status
    {
        /// <summary>
        /// Constructor
        /// </summary>
		protected TableStatus() : base()	{ }

		public virtual TableStatus Change()
        {
            if (Equals(FreeTableStatus.Instance))
                return BusyTableStatus.Instance;

            return FreeTableStatus.Instance;
        }


    }
}
