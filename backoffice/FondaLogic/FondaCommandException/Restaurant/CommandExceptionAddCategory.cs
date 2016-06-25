using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.Restaurant
{
    public class CommandExceptionAddCategory : FondaCommandLogicException
    {
        public CommandExceptionAddCategory() : base() { }

        public CommandExceptionAddCategory(string message) : base(message) { }

        public CommandExceptionAddCategory(string message, Exception InnerException)
            : base(message, InnerException) { }
    }
}
