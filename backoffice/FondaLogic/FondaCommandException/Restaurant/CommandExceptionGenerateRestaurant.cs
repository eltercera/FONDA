using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.Restaurant
{
    public class CommandExceptionGenerateRestaurant : FondaCommandLogicException
    {
        public CommandExceptionGenerateRestaurant() : base() { }

        public CommandExceptionGenerateRestaurant(string message) : base(message) { }

        public CommandExceptionGenerateRestaurant(string message, Exception InnerException)
            : base(message, InnerException) { }
    }
}
