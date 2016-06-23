using System;
using System.Runtime.Serialization;

namespace com.ds201625.fonda.Domain
{
    /// <summary>
    /// Representa la orden de una cuenta
    /// </summary>
    public class DishOrder : BaseEntity
    {

        #region Fields

        /// <summary>
        /// Plato ordenado
        /// </summary>
        private Dish _dish;

        /// <summary>
        /// Cantidad de veces que se ordeno el plato
        /// </summary>
        private int _count;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor vacio
        /// </summary>
        public DishOrder() : base () { }

        #endregion

        #region Properties

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
        public virtual float Dishcost
        {
            get { return _dish.Cost; }
        }

        #endregion 
    }
}
