using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.FondaCommandException.Login
{
   public class FondaLogicException : Exception
    {
        public FondaLogicException() : base() { }

        public FondaLogicException(string message) : base(message) { }

        public FondaLogicException(string message, Exception InnerException)
			: base(message, InnerException) { }

    }
}
