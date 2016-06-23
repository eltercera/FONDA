using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Domain
{
    /// <summary>
    /// Representa las coordenadas de un Restaurante
    /// </summary>
    public class Coordinate : BaseEntity
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Coordinate() : base() { }

        /// <summary>
        /// Ubicación del restaurante, medido en longitud
        /// </summary>
        private Double _longitude;

        /// <summary>
        /// Ubicación del restaurante, medido en latitud
        /// </summary>
        private Double _latitude;

        [DataMember]
        public virtual Double Longitude
        {
            /// <summary>
            /// Obtiene la longitud
            /// </summary>
            get { return _longitude; }
            /// <summary>
            /// Asigna la longitud
            /// </summary>
            /// <value>Recibe el valor de la longitud</value>
            set { _longitude = value; }
        }

        [DataMember]
        public virtual Double Latitude
        {
            /// <summary>
            /// Obtiene la latitud
            /// </summary>
            get { return _latitude; }
            /// <summary>
            /// Asigna la latitud
            /// </summary>
            /// <value>Recibe el valor de la latitud</value>
            set { _latitude = value; }
        }


    }
}
