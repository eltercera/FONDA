using System;

namespace com.ds201625.fonda.BackEndLogic.Exceptions
{
    /// <summary>
    /// Representa los errores que se generan al eliminar
    /// un Perfil de un Commensal en DeleteProfileCommand
    /// </summary>
    public class DeleteProfileCommandException : FondaBackendLogicException
    {
        public DeleteProfileCommandException  () : base() {	}

		public DeleteProfileCommandException  (string message) : base(message) {	}

        public DeleteProfileCommandException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
