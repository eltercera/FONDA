using System;

namespace com.ds201625.fonda.BackEndLogic.Exceptions
{
    /// <summary>
    /// Representa los errores que se generan al crear
    /// un Commensal en CreateCommensalCommand
    /// </summary>
    public class CreateCommensalCommandException : FondaBackendLogicException
    {
        public CreateCommensalCommandException  () : base() {	}

		public CreateCommensalCommandException (string message) : base(message) {	}

        public CreateCommensalCommandException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
