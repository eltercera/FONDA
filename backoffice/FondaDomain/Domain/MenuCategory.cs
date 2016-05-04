using System;
using System.Collections.Generic;


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
        private  List<Dish> _listDish;

        
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
        public virtual List<Dish> ListDish
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
        /// Cambia el eltado actual de la Categoria.
        /// </summary>
        public void changeStatus()
        {
            _status = _status.Change();
        }


        
    }
}
