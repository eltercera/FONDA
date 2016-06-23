using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace com.ds201625.fonda.Domain
{
    /// <summary>
    /// Categoria del Menu
    /// </summary>

    public class MenuCategory : NounBaseEntity
    {
        /// <summary>
        /// Estado simple de la Categoria
        /// </summary>
        private SimpleStatus _status;

        /// <summary>
        /// Lista de platos en la categoria
        /// </summary>
        private  IList<Dish> _listDish;

        
		/// <summary>
		/// Constructor
		/// </summary>
		public MenuCategory () : base () {

            _listDish = new List<Dish>();
        }


        /// <summary>
        /// Obtiene o asigna el estatus
        /// </summary>
        /// <value>El Estatus</value>
        public virtual SimpleStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }


        /// <summary>
        /// Retorna o asigna una lista de platos
        /// </summary>
        [DataMember]
        public virtual IList<Dish> ListDish
        {
            get { return _listDish; }
            set { _listDish = value; }
        }

        /// <summary>
        /// Agrega un plato a la categoria
        /// </summary>
        /// <param name="dish"> plato categoria </param>

        public virtual void addDish(Dish dish)
        {
            _listDish.Add(dish);

        }

        /// <summary>
        /// Cambia el estado actual de la Categoria.
        /// </summary>
        public virtual void changeStatus()
        {
            _status = _status.Change();
        }


        
    }
}
