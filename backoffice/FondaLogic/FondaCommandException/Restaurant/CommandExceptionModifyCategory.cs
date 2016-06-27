using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.Restaurant
{
    public class CommandExceptionModifyCategory : FondaCommandLogicException
    {
        public CommandExceptionModifyCategory() : base() { }

        public CommandExceptionModifyCategory(string message) : base(message) { }

        public CommandExceptionModifyCategory(string message, Exception InnerException)
            : base(message, InnerException) { }
    }
}

