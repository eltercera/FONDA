using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.FondaCommandException.OrderAccount
{
    public class CommandExceptionValidateProfileByCommensal : CommandException
    {
        #region Constructors

        public CommandExceptionValidateProfileByCommensal(string message) : base(message)
        {
        }
        public CommandExceptionValidateProfileByCommensal(string message, Exception ex) : base(message, ex)
        {
        }
        public CommandExceptionValidateProfileByCommensal(string id, string classname, string method, string message, Exception ex)
                : base(id, classname, method, message, ex)
        {
        }

        #endregion
    }
}
