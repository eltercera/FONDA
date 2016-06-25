using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.Restaurant
{
    public class FondaCommandLogicException : Exception
    {
        public FondaCommandLogicException() : base() { }

        public FondaCommandLogicException(string message) : base(message) { }

        public FondaCommandLogicException(string message, Exception InnerException)
            : base(message, InnerException) { }
    }
}
