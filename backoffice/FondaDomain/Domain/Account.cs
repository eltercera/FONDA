using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace com.ds201625.fonda.Domain
{
    /// <summary>
    /// Representa una cuenta de un restaurante.
    /// </summary>
    public class Account : BaseEntity
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
        [DataMember]
        public virtual Table Table
        {
            get { return _table; }
            set { _table = value; }
        }

        [DataMember]
        public virtual List<DishOrder> ListDish
        {
            get { return _listDish; }
            set { _listDish = value; }
        }

        /// <summary>
        /// Obtiene o asigna un estado a la cuenta
        /// </summary>
        public virtual AccountStatus Status
        {
            get { return _status; }
            set { _status = value; }
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
