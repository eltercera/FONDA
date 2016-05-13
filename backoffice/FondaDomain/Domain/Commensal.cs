using System;
using System.Collections;
using System.Collections.Generic;

namespace com.ds201625.fonda.Domain
{
	/// <summary>
	/// Representa los clientes.
	/// </summary>
	public class Commensal : UserAccount
	{
		/// <summary>
		/// Token de session de la cuenta.
		/// </summary>
		private string _sesionToken;

		/// <summary>
		/// Lista de restaurante favoritos de un comansal
		/// </summary>
		private IList <Restaurant> _favoritesRestaurants;

		private IList <Profile> _profiles;

		public Commensal () : base ()
		{
			_favoritesRestaurants = new List<Restaurant> ();
		}

		/// <summary>
		/// Obtiene o asigna la clave
		/// </summary>
		/// <value>la clave</value>
		public virtual string SesionToken
		{
			get { return _sesionToken; }
			set { _sesionToken= value; }
		}

		public virtual IList<Restaurant> FavoritesRestaurants
		{
			get { return _favoritesRestaurants; }
			set { _favoritesRestaurants = value; }
		}

		public virtual IList<Profile> Profiles
		{
			get { return _profiles; }
			set { _profiles = value; }
		}

		public virtual void AddFavoriteRestaurant ( Restaurant restaurant )
		{
            restaurant.AddFavoriteCommensal(this);
            _favoritesRestaurants.Add (restaurant);
		}

		public virtual void AddProfile ( Profile restaurant )
		{
			_profiles.Add (restaurant);
		}

	}
}

