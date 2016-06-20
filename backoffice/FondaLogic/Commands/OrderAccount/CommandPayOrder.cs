using FondaLogic.FondaCommandException;
using FondaLogic.Log;
using System;

namespace FondaLogic.Commands.OrderAccount
{
    /// <summary>
    /// Comando para pagar una orden abierta
    /// </summary>
    public class CommandPayOrder : Command
    {
        public CommandPayOrder(Object receiver) : base() { }

        public override void Execute()
        {
            try
            {

            }
            catch (NullReferenceException ex)
            {
                //TODO: Arrojar Excepcion personalizada
                CommandExceptionPayOrder exception = new CommandExceptionPayOrder(
                    FondaResources.General.Errors.NullExceptionReferenceCode,
                    FondaResources.OrderAccount.Errors.ClassNamePayOrder,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    FondaResources.General.Errors.NullExceptionReferenceMessage,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);
                //Receiver Pago

            }
        }
    }
}
