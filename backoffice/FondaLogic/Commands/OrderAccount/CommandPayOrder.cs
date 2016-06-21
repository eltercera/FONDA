using com.ds201625.fonda.Domain;
using FondaLogic.Factory;
using FondaLogic.FondaCommandException;
using FondaLogic.Log;
using System;
using System.Collections.Generic;

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
            List<Object> parameters = new List<object>();
            List<Invoice> paymentHistory;
            Command generateInvoice, releaseTable;

            try
            {
                parameters = (List<Object>)Receiver;
                int restaurantId = (int)parameters[0];
                int orderId = (int)parameters[1];
                Payment payment = (Payment)parameters[2];

                generateInvoice = CommandFactory.GetCommandValidateProfileByCommensal(parameters);
                //releaseTable = CommandFactory.get(profileId);
                //validate.Execute();

                //if ((bool)validate.Receiver)
                //    command.Execute();
                //else
                //    throw new NullReferenceException();

                //Receiver = command.Receiver;




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
