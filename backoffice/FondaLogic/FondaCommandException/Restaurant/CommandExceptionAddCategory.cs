using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.Restaurant
{
    public class CommandExceptionAddCategory : CommandException
    {
        public CommandExceptionAddCategory(string message) : base(message)
        {
        }
        public CommandExceptionAddCategory(string message, Exception ex) : base(message, ex)
        {
        }
        public CommandExceptionAddCategory(string id, string classname, string method, string message, Exception ex)
                : base(id, classname, method, message, ex)
        {
        }
    }
}
