using System;

namespace com.ds201625.fonda.BackEndLogic.Exceptions
{
    /// <summary>
    /// Representa los errores que se generan al buscar
    /// un Token de un Commensal en GetTokenCommand
    /// </summary>
    public class GetTokenCommandException : FondaBackendLogicException
    {
         public GetTokenCommandException  () : base() {	}

		public GetTokenCommandException (string message) : base(message) {	}

        public GetTokenCommandException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
