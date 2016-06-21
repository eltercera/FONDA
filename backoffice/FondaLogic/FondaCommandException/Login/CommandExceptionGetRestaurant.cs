using FondaLogic.FondaCommandException.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.FondaCommandException
{
    public class CommandExceptionGetRestaurant : FondaLogicException
    {


        public CommandExceptionGetRestaurant() : base() { }

        public CommandExceptionGetRestaurant(string message) : base(message) { }

        public CommandExceptionGetRestaurant(string message, Exception InnerException)
			: base(message, InnerException) { }




    }
}
