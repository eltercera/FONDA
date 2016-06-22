using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.FondaCommandException
{
    public class CommandExceptionGetCurrencyByRestaurant: CommandException
    {
        #region Constructors

        public CommandExceptionGetCurrencyByRestaurant(string message) : base(message)
        {
        }
        public CommandExceptionGetCurrencyByRestaurant(string message, Exception ex) : base(message, ex)
        {
        }
        public CommandExceptionGetCurrencyByRestaurant(string id, string classname, string method, string message, Exception ex)
                : base(id, classname, method, message, ex)
        {
        }

        #endregion
    }
}
