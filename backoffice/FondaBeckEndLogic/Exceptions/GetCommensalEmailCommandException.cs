using com.ds201625.fonda.BackEndLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.FondaBackEndLogic.Exceptions
{
    /// <summary>
    /// Clase GetCommensalEmailCommandException 
    /// </summary>
    public class GetCommensalEmailCommandException : FondaBackendLogicException
    {
        public GetCommensalEmailCommandException () : base() {	}

		public GetCommensalEmailCommandException(string message) : base(message) {	}

        public GetCommensalEmailCommandException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
