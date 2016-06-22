using System;

namespace com.ds201625.fonda.Logic.FondaLogic.FondaCommandException
{
    /// <summary>
    /// Excepcion arrojada en caso de que falle el cierre de caja
    /// </summary>
    public class CommandExceptionCloseCashRegister : CommandException
    {


        #region Constructors

        public CommandExceptionCloseCashRegister(string message) : base(message)
        {
        }
        public CommandExceptionCloseCashRegister(string message, Exception ex) : base(message, ex)
        {
        }
        public CommandExceptionCloseCashRegister(string id, string classname, string method, string message, Exception ex)
                : base(id, classname, method, message, ex)
        {
        }

        #endregion

    }
}
