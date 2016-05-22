using System;
using System.Collections.Generic;

namespace com.ds201625.fonda.Domain
{
    /// <summary>
    /// Representa a un restaurante
    /// </summary>
	public class Restaurant : Company
	{
        /// <summary>
        /// Logo del restaurante
        /// </summary>
        private string _logo;

        /// <summary>
        /// Tipo de moneda usada por el Restaurante
        /// </summary>
        private Currency _currency;

        /// <summary>
        /// Coordenadas de ubicacion del Restaurante
        /// </summary>
        private Coordinate _coordinate;

        /// <summary>
        /// Categoria de un restaurante
        /// </summary>
        private RestaurantCategory _category;

        /// <summary>
        /// Zona de ubicacion de un restaurante
        /// </summary>
        private Zone _zone;

        /// <summary>
        /// Horario de un restaurante
        /// </summary>
        private Schedule _schedule;

        /// <summary>
        /// Lista de categorias del menu de un restaurante
        /// </summary>
		private IList <MenuCategory> _menuCategories;

        /// <summary>
        /// Lista de empleados de un restaurante
        /// </summary>
        private IList <Employee> _employees;

        /// <summary>
        /// Lista de las mesas de un restaurante
        /// </summary>
        private IList <Table> _tables;

        /// <summary>
        /// Lista de commensal que tienen restaurante como favorito
        /// </summary>

        private IList<Commensal> _favoritesCommensal;

        /// <summary>
        /// Constructor.
        /// </summary>
        public Restaurant () : base () {

            _favoritesCommensal = new List<Commensal>();
        }

        public virtual string Logo
        {
            /// <summary>
            /// Obtiene el logo de un restaurante
            /// </summary>
            get { return _logo; }
            /// <summary>
            /// Asigna el logo de un restaurante
            /// </summary>
            /// <value>Recibe el logo de un restaurante </value>
            set { _logo = value; }
        }

        public virtual Currency Currency
        {
            /// <summary>
            /// Obtiene el tipo de moneda de un restaurante
            /// </summary>
            get { return _currency; }
            /// <summary>
            /// Asigna el tipo de moneda de un restaurante 
            /// </summary>
            /// <value>Recibe el tipo de moneda de un restaurante </value>
            set { _currency = value; }
        }

        public virtual Coordinate coordinate
        {
            /// <summary>
            /// Obtiene las coordenadas de un restaurante
            /// </summary>
            get { return _coordinate; }
            /// <summary>
            /// Asigna las coordenadas de un restaurante 
            /// </summary>
            /// <value>Recibe las coordenadas de un restaurante </value>
            set { _coordinate = value; }
        }

        public virtual RestaurantCategory RestaurantCategory
        {
            /// <summary>
            /// Obtiene la categoria del tipo de comida que se sirve en un restaurante
            /// </summary>
            get { return _category; }
            /// <summary>
            /// Asigna la categoria del tipo de comida que se sirve en un restaurante
            /// </summary>
            /// <value>Recibe la categoria del tipo de comida que se sirve en un restaurante</value>
            set { _category = value; }
        }

        public virtual Zone Zone
        {
            /// <summary>
            /// Obtiene la zona de ubicacion del restaurante
            /// </summary>
            get { return _zone; }
            /// <summary>
            /// Asigna la zona de ubicacion del restaurante
            /// </summary>
            /// <value>Recibe la zona de ubicacion del restaurante</value>
            set { _zone = value; }
        }

        public virtual Schedule Schedule
        {
            /// <summary>
            /// Obtiene el horario del restaurante
            /// </summary>
            get { return _schedule; }
            /// <summary>
            /// Asigna el horario del restaurante
            /// </summary>
            /// <value>Recibe el horario disponible del restaurante</value>
            set { _schedule = value; }
        }

        public virtual IList <MenuCategory> MenuCategories
        {
            /// <summary>
            /// Obtiene una lista de categorias del menu de un Restaurante
            /// </summary>
            get { return _menuCategories; }
            /// <summary>
            /// Asigna una lista de categorias del menu de un Restaurante
            /// </summary>
            /// <value>Recibe la lista de categorias de un Restaurante</value>
            set { _menuCategories = value; }
        }

        public virtual IList <Employee> Employees
        {
            /// <summary>
            /// Obtiene una lista de empleados de un Restaurante
            /// </summary>
            get { return _employees; }
            /// <summary>
            /// Asigna una lista de empleados de un Restaurante
            /// </summary>
            /// <value>Recibe la lista de empleados de un Restaurante</value>
            set { _employees = value; }
        }

        public virtual IList <Table> Tables
        {
            /// <summary>
            /// Obtiene una lista de mesas de un Restaurante
            /// </summary>
            get { return _tables; }
            /// <summary>
            /// Asigna una lista de mesas de un Restaurante
            /// </summary>
            /// <value>Recibe la lista de mesas de un Restaurante</value>
            set { _tables = value; }
        }

        public virtual IList<Commensal> FavoritesCommensals
        {
            get { return _favoritesCommensal; }
            set { _favoritesCommensal = value; }
        }
        
        public virtual void AddFavoriteCommensal(Commensal commensal)
        {
            _favoritesCommensal.Add(commensal);
           
        }

        public virtual void RemoveFavoriteCommensal(Commensal commensal)
        {
            _favoritesCommensal.Remove(commensal);
        }



    }
}

