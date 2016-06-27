using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.Restaurant
{
    public class CommandExceptionGetAllZones : CommandException
    {
        public CommandExceptionGetAllZones(string message) : base(message)
        {
        }
        public CommandExceptionGetAllZones(string message, Exception ex) : base(message, ex)
        {
        }
        public CommandExceptionGetAllZones(string id, string classname, string method, string message, Exception ex)
                : base(id, classname, method, message, ex)
        {
        }

    }
}
