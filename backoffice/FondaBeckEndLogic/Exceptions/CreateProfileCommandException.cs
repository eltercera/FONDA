using com.ds201625.fonda.BackEndLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.BackEndLogic.Exceptions
{
    /// <summary>
    /// Representa los errores que se generan al crear
    /// un Perfil de un Commensal en CreateProfileCommand
    /// </summary>
    public class CreateProfileCommandException : FondaBackendLogicException
    {
         public CreateProfileCommandException  () : base() {	}

		public CreateProfileCommandException (string message) : base(message) {	}

        public CreateProfileCommandException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
