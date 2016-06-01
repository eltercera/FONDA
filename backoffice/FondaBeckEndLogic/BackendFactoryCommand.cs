using System;
using com.ds201625.fonda.Logic;

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
		public BaseCommand CreateCreateProfileCommand()
		{
			return new CreateProfileCommand ();
		}
	}
}

