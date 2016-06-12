using System;

namespace com.ds201625.fonda.BackEndLogic.Exceptions
{
	public class InvalidTypeOfParameterException : FondaBackendLogicException
	{
		public InvalidTypeOfParameterException (string message) : base(message) { }

		public static InvalidTypeOfParameterException Generate(Type spected, Type recive)
		{
			string msg = "Error de tipo de parametro se espera ("
			             + spected.ToString () +
			             ") y se recivio de tipo ("
			             + recive.ToString () +
			             ")";
			return new InvalidTypeOfParameterException (msg);
		}
	}
}

