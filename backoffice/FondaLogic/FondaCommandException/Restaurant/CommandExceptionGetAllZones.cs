using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.Restaurant
{
    public class CommandExceptionGetAllZones : FondaCommandLogicException
    {
        public CommandExceptionGetAllZones() : base() { }

        public CommandExceptionGetAllZones(string message) : base(message) { }

        public CommandExceptionGetAllZones(string message, Exception InnerException)
            : base(message, InnerException) { }

    }
}
