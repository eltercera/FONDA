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
        #region Fields
        /// <summary>
        /// Fecha de la cuenta
        /// </summary>
        private DateTime _date;

        /// <summary>
        /// Estado de la cuenta
        /// </summary>
        private AccountStatus _status;

        /// <summary>
        /// Mesa de la cuenta 
        /// </summary>
        private Table _table;

        /// <summary>
        /// Commensal de la cuenta
        /// </summary>
        private Commensal _commensal;

        /// <summary>
        /// Lista de ordenes de la cuenta.
        /// </summary>
        private IList<DishOrder> _listDish;

        /// <summary>
        /// Lista de facturas de la cuenta.
        /// </summary>
        private IList<Invoice> _listInvoice;

        /// <summary>
		/// El numero unico de la orden
		/// </summary>
        private int _number;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public Account() : base()
        {
            this._listDish = new List<DishOrder>();
            this._listInvoice = new List<Invoice>();
        }

        /// <summary>
        /// Constructor para crear una orden nueva
        /// </summary>
        /// <param name="table">Mesa del Restaurante asignada</param>
        /// <param name="commensal">Datos del comensal</param>
        /// <param name="listOrder">Ordenes hechas por el comensal</param>
        /// <param name="number">Numero de la cuenta</param>
        public Account(Table table, Commensal commensal, IList<DishOrder> listOrder, int number) : base()
        {
            this._date = DateTime.Now;
            this._status = new OpenAccountStatus();
            this._table = table;
            this._commensal = commensal;
            this._listDish = listOrder;
            this._number = number;
            this._listInvoice = new List<Invoice>();
        }

        public Account(Table table, IList<DishOrder> listOrder) : base()
        {
            this._date = DateTime.Now;
            this._status = new OpenAccountStatus();
            this._table = table;
            this._listDish = listOrder;
            this._listInvoice = new List<Invoice>();
        }
        #endregion

        #region Properties

        /// <summary>
        /// Retorna o asigna una fecha
        /// </summary>
        public virtual DateTime Date
        {
            get { return _date; }
        }

        /// <summary>
        /// Retorna o asigna la mesa de una cuenta
        /// </summary>
        //[DataMember]
        public virtual Table Table
        {
            get { return _table; }
        }

        /// <summary>
        /// Obtiene o asigna el numero de la orden
        /// </summary>
        public virtual int Number
        {
            get { return _number; }
        }

        [DataMember]
        public virtual IList<DishOrder> ListDish
        {
            get { return _listDish; }
        }

        /// <summary>
        /// Obtiene o asigna el numero de la orden
        /// </summary>
        public virtual IList<Invoice> ListInvoice
        {
            get { return _listInvoice; }
        }
        /// <summary>
        /// Obtiene o asigna un estado a la cuenta
        /// </summary>
        public virtual AccountStatus Status
        {
            get { return _status; }
        }

        /// <summary>
        /// Obtiene o asigna un commensal a la cuenta
        /// </summary>
        public virtual Commensal Commensal
        {
            get{ return _commensal; }
            set{ _commensal = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Agrega una orden a la cuenta
        /// </summary>
        /// <param name="dish"> orden pedida </param>
        public virtual void AddDish(DishOrder dish)
        {
            _listDish.Add(dish);
        }

        /// <summary>
        /// Elimina una orden a la cuenta
        /// </summary>
        /// <param name="dish">orden pedida </param>
        public virtual void RemoveDish(DishOrder dish)
        {
            _listDish.Remove(dish);
        }

        /// <summary>
        /// Agrega una invoice a la cuenta
        /// </summary>
        /// <param name="invoice"> orden pedida </param>
        public virtual void AddInvoice(Invoice invoice)
        {
            _listInvoice.Add(invoice);
        }

        /// <summary>
        /// Elimina una invoice de la cuenta
        /// </summary>
        /// <param name="invoice">orden pedida </param>
        public virtual void RemoveInvoice(Invoice invoice)
        {
            _listInvoice.Remove(invoice);
        }

        /// <summary>
        /// Cambia el eltado actual del cuenta.
        /// </summary>
        public virtual void ChangeStatus()
        {
            _status = _status.Change();
        }

        /// <summary>
        /// Obtiene el precio total de todas las ordenes
        /// </summary>
        public virtual float GetAmount()
        {
            float total = 0;
            for (int i = 0; i < _listDish.Count; i++)
            {
                total += (_listDish[i].Dish.Cost*_listDish[i].Count);
            }
            return total;
        }
        #endregion


    }
}
