using System;
using com.ds201625.fonda.BackEndLogic;

namespace com.ds201625.fonda.BackEndLogic.Exceptions
{
	public class RequieredParameterNotFoundException : FondaBackendLogicException
	{

		private RequieredParameterNotFoundException (string message) : base (message)
		{ }

		public static RequieredParameterNotFoundException Generate (BaseCommand cmd, int index)
		{
			String msj = "Parametro " + index + " es requerido para " + cmd.ToString ();
			return  new RequieredParameterNotFoundException (msj);
		}
	}
}

