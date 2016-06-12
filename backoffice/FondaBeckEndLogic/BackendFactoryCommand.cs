using System;
using System.Windows.Input;
using com.ds201625.fonda.BackEndLogic.FavoriteManagement;


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
		public ICommand CreateCreateProfileCommand()
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
     
	}
	
}

