using System;
using System.Runtime.Serialization;

namespace com.ds201625.fonda.Domain
{
    /// <summary>
    /// Representa la orden de una cuenta
    /// </summary>
    public class DishOrder : BaseEntity
    {
        /// <summary>
        /// Plato ordenado
        /// </summary>
        private Dish _dish;

        /// <summary>
        /// Cantidad de veces que se ordeno el plato
        /// </summary>
        private int _count;
        
        /// <summary>
        /// Constructor vacio
        /// </summary>
        public DishOrder() : base () { }

        /// <summary>
        /// Obtiene o asigna la cantidad de un plato
        /// </summary>
        [DataMember]
        public virtual int Count
        {
            get { return _count;  }
            set { _count = value; }
        }

        /// <summary>
        /// Obtiene o asigna un plato
        /// </summary>
        [DataMember]
        public virtual Dish Dish
        {
            get { return _dish; }
            set { _dish = value; }
        }

        /// <summary>
        /// Obtiene el precio del plato
        /// </summary>
        [DataMember(Name = "Cost")]
        public virtual float Dishcost
        {
            get { return _dish.Cost;  }
        }

        /// <summary>
        /// Obtiene el nombre del plato
        /// </summary>
        [DataMember(Name = "Name")]
        public virtual String DishName
        {
            get { return _dish.Name; }
        }

        /// <summary>
        /// Obtiene la descripcion del plato
        /// </summary>
        [DataMember (Name = "Description")]
        public virtual String DishDescription
        {
            get { return _dish.Description; }
        }
    }
}
