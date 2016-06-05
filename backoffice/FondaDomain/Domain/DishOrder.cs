using System;

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
        public virtual int Count
        {
            get { return _count;  }
            set { _count = value; }
        }
        
        /// <summary>
        /// Obtiene o asigna un plato
        /// </summary>
        public virtual Dish Dish
        {
            get { return _dish; }
            set { _dish = value; }
        }
    }
}
