using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.Restaurant
{
    public class CommandExceptionSaveCategory : FondaCommandLogicException
    {
        public CommandExceptionSaveCategory() : base() { }

        public CommandExceptionSaveCategory(string message) : base(message) { }

        public CommandExceptionSaveCategory(string message, Exception InnerException)
            : base(message, InnerException) { }
    }
}
