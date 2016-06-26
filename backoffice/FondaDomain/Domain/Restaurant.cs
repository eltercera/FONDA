using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
        /// Lista de mesas que tiene un restaurante
        /// </summary>
       private IList<Table> _tables;


        /// <summary>
        /// Lista de commensal que tienen restaurante como favorito
        /// </summary>
        private IList<Commensal> _favoritesCommensal;

        /// <summary>
        /// Lista de cuentas 
        /// </summary>
        private IList<Account> _accounts;

		/// <summary>
		/// Si es favorito
		/// </summary>
		private bool _favorite = false;

        /// <summary>
        /// Constructor.
        /// </summary>
        public Restaurant () : base () {

            _favoritesCommensal = new List<Commensal>();
        }
        [DataMember]
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

        public virtual Coordinate Coordinate
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
        [DataMember]
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

		[DataMember]
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

		[DataMember]
		public virtual bool Favorite
		{
			get { return _favorite; }
			set { _favorite = value; }
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

        public virtual IList<Table> Tables
        {
            /// <summary>
            /// Obtiene una lista de categorias del menu de un Restaurante
            /// </summary>
            get { return _tables; }
            /// <summary>
            /// Asigna una lista de mesas de un Restaurante
            /// </summary>
            /// <value>Recibe la lista de mesas de un Restaurante</value>
            set { _tables = value; }
        }

        public virtual IList<Account> Accounts
        {
            /// <summary>
            /// Obtiene una lista de cuentas de un restaurante
            /// </summary>
            get { return _accounts; }
            /// <summary>
            /// Asigna una lista de cuentas de un restaurante
            /// </summary>
            /// <value>Recibe la lista de cuentas de un restaurante </value>
            set { _accounts = value; }
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

