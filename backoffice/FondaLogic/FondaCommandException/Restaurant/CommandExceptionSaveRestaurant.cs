using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.Restaurant
{
    public class CommandExceptionSaveRestaurant : FondaCommandLogicException
    {
        public CommandExceptionSaveRestaurant() : base() { }

        public CommandExceptionSaveRestaurant(string message) : base(message) { }

        public CommandExceptionSaveRestaurant(string message, Exception InnerException)
            : base(message, InnerException) { }
    }
}
