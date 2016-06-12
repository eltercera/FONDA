using System;
using com.ds201625.fonda.BackEndLogic;

namespace com.ds201625.fonda.BackEndLogic.Exceptions
{
	public class ParameterIndexOutOfRangeException : FondaBackendLogicException
	{

		private ParameterIndexOutOfRangeException (string message) : base(message)
		{ }

		public static ParameterIndexOutOfRangeException Generate(BaseCommand cmd, int index)
		{
			string msj = "Indice " + index + "fuera de rango " + cmd.ToString ();
			return new ParameterIndexOutOfRangeException (msj);
		}
	}
}

