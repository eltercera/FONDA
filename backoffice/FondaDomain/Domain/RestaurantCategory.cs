using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace com.ds201625.fonda.Domain
{
    /// <summary>
    /// Representa el tipo de comida que prepara el Restaurante
    /// </summary>
    public class RestaurantCategory : NounBaseEntity
    {
        /// <summary>
        /// Nombre de la categoria del restaurant
        /// </summary>
        private string _nameCategory;

        /// <summary>
        /// Constructor.
        /// </summary>
        public RestaurantCategory() : base() { }

        [DataMember]
        public virtual string NameCategory
        {
            /// <summary>
            /// Obtiene el Nombre de la categoria del restaurante
            /// </summary>
            get { return _nameCategory; }
            /// <summary>
            /// Asigna el Nombre de la categoria del restaurante
            /// </summary>
            /// <value>Recibe el Nombre de la categoria del restaurante</value>
            set { _nameCategory = value; }
        }

    }
}
