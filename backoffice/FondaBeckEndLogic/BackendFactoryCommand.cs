using System;
using com.ds201625.fonda.BackEndLogic.FavoriteManagement;
using FondaBeckEndLogic.ProfileManagement;
using FondaBeckEndLogic.TokenManagement;
using FondaBeckEndLogic.CommensalManagement;

namespace com.ds201625.fonda.BackEndLogic
{
	/// <summary>
	/// Fabrica de Commandos
	/// </summary>
	public class BackendFactoryCommand
	{
		/// <summary>
		/// Instancia de la fabrica
		/// </summary>
		private static BackendFactoryCommand _instance;

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>The instance.</value>
		public static BackendFactoryCommand Instance
		{
			get
			{
				if (_instance == null)
					_instance = new BackendFactoryCommand ();
				
				return _instance;
			}
		}

		private BackendFactoryCommand () { }

		/// <summary>
		/// Obtiene un CreateProfileCommand.
		/// </summary>
		/// <returns>Comando CreateProfileCommand.</returns>
		public ICommand GetCreateProfileCommand()
		{
			return new CreateProfileCommand ();
		}

   
        /// <summary>
        /// Obtiene un GetFavoriteRestaurantCommand.
        /// </summary>
        /// <returns>Comando GetFavoriteRestaurantCommand().</returns>
        public ICommand GetFavoriteRestaurantCommand()
        {
            return new GetFavoriteRestaurantCommand();
        }

        /// <summary>
        /// Obtiene un GetCommensalEmailCommand.
        /// </summary>
        /// <returns>Comando GetCommensalEmailCommand.</returns>
        public ICommand GetCommensalEmailCommand()
        {
            return new GetCommensalEmailCommand();
        }

        /// <summary>
        /// Obtiene un GetCommensalEmailCommand.
        /// </summary>
        /// <returns>Comando GetCommensalEmailCommand.</returns>
        public ICommand GetAllRestaurantCommand()
        {
            return new GetAllRestaurantCommand();
        }
        
        public ICommand CreateFavoriteRestaurantCommand()
        {
            return new CreateFavoriteRestaurantCommand();
        }

        public ICommand DeleteFavoriteRestaurantCommand()
        {
            return new DeleteFavoriteRestaurantCommand();
        }

		public ICommand CreateGetZonesCommand ()
		{
			return new GetZonesCommand ();
		}

		public ICommand CreateGetRestaurantsCategoriesCommand ()
		{
			return new GetRestaurantsCategoriesCommand ();
		}

		public ICommand CreateGetRestaurantsCommand ()
		{
			return new GetRestaurantsCommand ();
		}

        /// <summary>
        /// Obtiene un GetCommensalIdCommand
        /// </summary>
        /// <returns>Comando GetCommensalIdCommand.</returns>
        public ICommand GetCommensalCommand()
        {
            return new GetCommensalCommand();
        }

        /// <summary>
        /// Obtiene un GetProfileIdCommand
        /// </summary>
        /// <returns>Comando GetProfileIdCommand.</returns>
        public ICommand GetProfileIdCommand()
        {
            return new GetProfileCommand();
        }

        /// <summary>
        /// Obtiene un UpdateProfileCommand
        /// </summary>
        /// <returns>Comando UpdateProfileCommand.</returns>
        public ICommand UpdateProfileCommand()
        {
            return new UpdateProfileCommand();
        }

        /// <summary>
        /// Obtiene un DeleteProfileCommand
        /// </summary>
        /// <returns>Comando DeleteProfileCommand.</returns>
        public ICommand DeleteProfileCommand()
        {
            return new DeleteProfileCommand();
        }

        /// <summary>
        /// Obtiene un GetTokenCommand
        /// </summary>
        /// <returns>Comando GetTokenCommand.</returns>
        public ICommand GetTokenCommand()
        {
            return new GetTokenCommand();
        }
     
	}
	
}

