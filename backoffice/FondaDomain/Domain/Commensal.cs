using System;
using System.Linq;
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
		private IList<Token> _sesionTokens;

		/// <summary>
		/// Lista de restaurante favoritos de un comansal
		/// </summary>
		private IList <Restaurant> _favoritesRestaurants;

		private IList <Profile> _profiles;

		public Commensal () : base ()
		{
			_favoritesRestaurants = new List<Restaurant> ();
			_profiles = new List<Profile> ();
			_sesionTokens = new List<Token> ();
		}

		public virtual IList<Token> SesionTokens
		{
			get { return _sesionTokens; }
			set { _sesionTokens= value; }
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
			_favoritesRestaurants.Add (restaurant);
		}

		public virtual void AddProfile ( Profile restaurant )
		{
			_profiles.Add (restaurant);
		}

		public virtual void AddToken ( Token token )
		{
			token.Commensal = this;
			_sesionTokens.Add (token);
		}

	}
}

