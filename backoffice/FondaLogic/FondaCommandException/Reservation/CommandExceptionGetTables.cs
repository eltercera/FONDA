using System;

namespace com.ds201625.fonda.Logic.FondaLogic.FondaCommandException
{
    public class CommandExceptionGetTables : CommandException
    {
        #region Constructors

        public CommandExceptionGetTables(string message, Exception ex) : base(message, ex)
        {
        }

        public CommandExceptionGetTables(string id, string classname, string method, string message, Exception ex) 
            : base(id, classname, method, message, ex)
        {
        }

        #endregion
    }
}
