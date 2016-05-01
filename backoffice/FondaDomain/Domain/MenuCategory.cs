using System;


namespace com.ds201625.fonda.Domain
{
    /// <summary>
    /// Categoria del Menu
    /// </summary>

    class MenuCategory : NounBaseEntity
    {
        /// <summary>
        /// Estado simple de la Categoria
        /// </summary>
        private SimpleStatus _status;

        
		/// <summary>
		/// Constructor
		/// </summary>
		public MenuCategory () : base () {	}



        /// <summary>
        /// Cambia el eltado actual de la Categoria.
        /// </summary>
        public void changeStatus()
        {
            _status = _status.Change();
        }
    }
}
