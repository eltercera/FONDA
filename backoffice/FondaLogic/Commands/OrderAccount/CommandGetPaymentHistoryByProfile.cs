using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Logic.FondaLogic.Factory;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.OrderAccount;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using com.ds201625.fonda.Resources.FondaResources.OrderAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.Commands.OrderAccount
{
    public class CommandGetPaymentHistoryByProfile : Command
    {
        public CommandGetPaymentHistoryByProfile(Object receiver) : base(receiver) { }
        

        public override void Execute()
        {
            List<Object> parameters = new List<object>();
            List<Invoice> paymentHistory;
            Command validate, command;

            try
            {
                parameters = (List<Object>)Receiver;
                int profileId = (int) parameters[0];

                validate = CommandFactory.GetCommandValidateProfileByCommensal(parameters);
                command = CommandFactory.GetCommandGetInvoicesByProfile(profileId);
                validate.Execute();

                if ((bool)validate.Receiver)
                    command.Execute();
                else
                    throw new NullReferenceException();

                Receiver = command.Receiver;


            }
            catch (NullReferenceException ex)
            {
                //TODO: Arrojar Excepcion personalizada
                CommandExceptionGetPaymentHistoryByProfile exception = new CommandExceptionGetPaymentHistoryByProfile(
                    OrderAccountResources.CommandExceptionGetPaymentHistoryByProfileCode,
                    OrderAccountResources.ClassNameGetPaymentHistoryByProfile,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionGetPaymentHistoryByProfile,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);
                throw exception;
                paymentHistory = new List<Invoice>();
                Receiver = paymentHistory;
            }
            catch(InvalidCastException ex)
            {
                //TODO: Arrojar Excepcion personalizada
                CommandExceptionGetPaymentHistoryByProfile exception = new CommandExceptionGetPaymentHistoryByProfile(
                    OrderAccountResources.CommandExceptionGetPaymentHistoryByProfileCode,
                    OrderAccountResources.ClassNameGetPaymentHistoryByProfile,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionGetPaymentHistoryByProfile,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);
                throw exception;
                paymentHistory = new List<Invoice>();
                Receiver = paymentHistory;
            }
            catch (CommandExceptionValidateProfileByCommensal ex)
            {
                CommandExceptionGetPaymentHistoryByProfile exception = new CommandExceptionGetPaymentHistoryByProfile(
                    OrderAccountResources.CommandExceptionGetPaymentHistoryByProfileCode,
                    OrderAccountResources.ClassNameGetPaymentHistoryByProfile,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionGetPaymentHistoryByProfile,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);
                throw exception;
                paymentHistory = new List<Invoice>();
                Receiver = paymentHistory;
            }
            catch (CommandExceptionGetInvoicesByProfile ex)
            {
                //TODO: Arrojar Excepcion personalizada
                CommandExceptionGetPaymentHistoryByProfile exception = new CommandExceptionGetPaymentHistoryByProfile(
                    OrderAccountResources.CommandExceptionGetPaymentHistoryByProfileCode,
                    OrderAccountResources.ClassNameGetPaymentHistoryByProfile,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionGetPaymentHistoryByProfile,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);
                throw exception;
                paymentHistory = new List<Invoice>();
                Receiver = paymentHistory;
            }
            catch (Exception ex)
            {
                CommandExceptionGetPaymentHistoryByProfile exception = new CommandExceptionGetPaymentHistoryByProfile(
                    OrderAccountResources.CommandExceptionGetPaymentHistoryByProfileCode,
                    OrderAccountResources.ClassNameGetPaymentHistoryByProfile,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionGetPaymentHistoryByProfile,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);
                throw exception;
                paymentHistory = new List<Invoice>();
                Receiver = paymentHistory;
            }

            Logger.WriteSuccessLog(OrderAccountResources.ClassNameGetPaymentHistoryByProfile
                    , OrderAccountResources.SuccessMessageCommandGetPaymentHistoryByProfile
                    , System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
                    );
        }

    }
}
