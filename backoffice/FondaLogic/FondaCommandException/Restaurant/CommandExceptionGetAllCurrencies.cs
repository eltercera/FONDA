using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.Restaurant
{
    public class CommandExceptionGetAllCurrencies : FondaCommandLogicException
    {
        public CommandExceptionGetAllCurrencies() : base() { }

        public CommandExceptionGetAllCurrencies(string message) : base(message) { }

        public CommandExceptionGetAllCurrencies(string message, Exception InnerException)
            : base(message, InnerException) { }
    }

}

