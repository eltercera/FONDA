using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace com.ds201625.fonda.Domain
{
    /// <summary>
    /// Tipo de moneda del Restaurante
    /// </summary>
	public class Currency : NounBaseEntity
    {

        /// <summary>
        /// Simbolo de la moneda de un restaurante
        /// </summary>
        private string _symbol;

		public Currency () : base () { }
        [DataMember]
        public virtual string Symbol
        {
            /// <summary>
            /// Obtiene el simbolo de la moneda usada en un restaurante
            /// </summary>
            get { return _symbol; }
            /// <summary>
            /// Asigna el simbolo de la moneda usada en un restaurante
            /// </summary>
            /// <value>Recibe simbolo de la moneda usada en un restaurante</value>
            set { _symbol = value; }
        }
			
    }
}
