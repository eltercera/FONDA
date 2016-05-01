using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Domain
{
    /// <summary>
    /// Tipo de moneda del Restaurante
    /// </summary>
    public class Currency
    {
        /// <summary>
        /// Nombre de la moneda usada en un restaurante
        /// </summary>
        private float _currency;

        /// <summary>
        /// Simbolo de la moneda de un restaurante
        /// </summary>
        private string _symbol;

        public string Symbol
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


        public float _Currency
        {
            /// <summary>
            /// Obtiene el nombre de la moneda usada en el restaurante
            /// </summary>
            get { return _currency; }
            /// <summary>
            /// Asigna el nombre de la moneda usada en el restaurante
            /// </summary>
            /// <value>Recibe el nombre de la moneda usada en el restaurante</value>
            set { _currency = value; }
        }

    }
}
