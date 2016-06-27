using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.Restaurant
{
    public class CommandExceptionGetAllCategories : FondaCommandLogicException
    {
        public CommandExceptionGetAllCategories() : base() { }

        public CommandExceptionGetAllCategories(string message) : base(message) { }

        public CommandExceptionGetAllCategories(string message, Exception InnerException)
            : base(message, InnerException) { }
    }
}

