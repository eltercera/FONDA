using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.FondaCommandException
{
    public class CommandExceptionGetUserAccount : CommandException
    {
      

            #region Constructors

            public CommandExceptionGetUserAccount(string message, Exception ex) : base(message, ex)
            {
            }

            public CommandExceptionGetUserAccount(string id, string classname, string method, string message, Exception ex)
                : base(id, classname, method, message, ex)
            {
            }

            #endregion




        
    }
}
