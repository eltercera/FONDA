using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.Restaurant
{
    public class CommandExceptionModifyRestaurant : FondaCommandLogicException
    {
        public CommandExceptionModifyRestaurant() : base() { }

        public CommandExceptionModifyRestaurant(string message) : base(message) { }

        public CommandExceptionModifyRestaurant(string message, Exception InnerException)
            : base(message, InnerException) { }
    }
}
