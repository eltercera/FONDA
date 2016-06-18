using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.FondaCommandException
{
    class CommandExceptionGetRestaurant : CommandException
    {

    
            #region Constructors

            public CommandExceptionGetRestaurant(string message, Exception ex) : base(message, ex)
            {
            }

            public CommandExceptionGetRestaurant(string id, string classname, string method, string message, Exception ex)
                : base(id, classname, method, message, ex)
            {
            }

            #endregion
      



    }
}
