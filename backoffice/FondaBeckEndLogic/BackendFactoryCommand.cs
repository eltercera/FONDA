using System;
using com.ds201625.fonda.Logic;

namespace com.ds201625.fonda.BackEndLogic
{
	public class BackendFactoryCommand
	{

		private static BackendFactoryCommand _instance;

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


		public BaseCommand CreateCreateProfileCommand()
		{
			return new CreateProfileCommand ();
		}
	}
}

