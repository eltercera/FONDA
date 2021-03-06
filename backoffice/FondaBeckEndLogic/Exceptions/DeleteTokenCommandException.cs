﻿using System;

namespace com.ds201625.fonda.BackEndLogic.Exceptions
{
    /// <summary>
    /// Representa los errores que se generan al eliminar
    /// un Token de un Commensal en DeleteTokenCommand
    /// </summary>
    public class DeleteTokenCommandException : FondaBackendLogicException
    {
        public DeleteTokenCommandException  () : base() {	}

		public DeleteTokenCommandException  (string message) : base(message) {	}

        public DeleteTokenCommandException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
