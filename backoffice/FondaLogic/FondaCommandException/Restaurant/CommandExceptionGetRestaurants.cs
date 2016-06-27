using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.Restaurant
{
    public class CommandExceptionGetRestaurants : FondaCommandLogicException
    {
        public CommandExceptionGetRestaurants() : base() { }

        public CommandExceptionGetRestaurants(string message) : base(message) { }

        public CommandExceptionGetRestaurants(string message, Exception InnerException)
            : base(message, InnerException) { }
    }
}
