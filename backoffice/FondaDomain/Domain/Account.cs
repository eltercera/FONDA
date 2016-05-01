using System;
using System.Collections.Generic;

namespace com.ds201625.fonda.Domain
{
    /// <summary>
    /// Representa una cuenta de un restaurante.
    /// </summary>
    class Account : BaseEntity
    {
        /// <summary>
        /// Estado de la cuenta
        /// </summary>
        private AccountStatus _status;

        /// <summary>
        /// Mesa de la cuenta 
        /// </summary>
        private Table _table;

        /// <summary>
        /// Lista de ordenes de la cuenta.
        /// </summary>
        private List<DishOrder> _listDish;

        /// <summary>
        /// Constructor
        /// </summary>
        public Account() : base()
        {
            _listDish = new List<DishOrder>();
        }

        /// <summary>
        /// Retorna o asigna la mesa de una cuenta
        /// </summary>
        public virtual Table Table
        {
            get { return _table; }
            set { _table = value; }
        }

        /// <summary>
        /// Retorna o asigna una lista de ordenes
        /// </summary>
        public virtual List<DishOrder> ListDish
        {
            get { return _listDish; }
            set { _listDish = value; }
        }

        /// <summary>
        /// Agrega una orden a la cuenta
        /// </summary>
        /// <param name="dish"> orden pedida </param>
        public virtual void addDish(DishOrder dish)
        {
            _listDish.Add(dish);
        }

        /// <summary>
        /// Cambia el eltado actual del cuenta.
        /// </summary>
        public virtual void changeStatus()
        {
            _status = _status.Change();
        }

    }
}
