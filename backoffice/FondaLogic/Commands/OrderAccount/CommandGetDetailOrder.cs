using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Logic.FondaLogic.Factory;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using com.ds201625.fonda.Resources.FondaResources.OrderAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.Commands.OrderAccount
{
    public class CommandGetDetailOrder : Command
    {
        private List<int> parameter;

        public CommandGetDetailOrder(Object receiver) : base (receiver) { }

        public override void Execute()
        {
            //Invoca al comando
            Command commandGetDishOrders;
            Command commandGetOrder;
            Command commandGetCurrency;

            try
            {
                    parameter = (List<int>) Receiver;
                    
                    //Obtiene la instancia del comando enviado el restaurante como parametro
                    commandGetDishOrders = CommandFactory.GetDetailOrder(parameter[0]);
                    commandGetOrder = CommandFactory.GetCommandGetOrder(parameter[0]);
                    commandGetCurrency = CommandFactory.GetCommandGetCurrency(parameter[1]);

                    //Ejecuta el comando deseado
                    commandGetDishOrders.Execute();
                    commandGetOrder.Execute();
                    commandGetCurrency.Execute();

                    //Respuesta a devolver
                    Receiver = new List<Object>
                    {
                        commandGetDishOrders.Receiver,
                        commandGetOrder.Receiver,
                        commandGetCurrency.Receiver
                    };

            }
            catch (NullReferenceException ex)
            {
                CommandExceptionGetDetailOrder exceptionGetOrders = new CommandExceptionGetDetailOrder(
                    OrderAccountResources.CommandExceptionGetDetailOrderCode,
                    OrderAccountResources.ClassNameGetDetailOrder,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionGetDetailOrder,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exceptionGetOrders);

                IList<Object> _list = new List<Object>();
                Receiver = _list;

            }
            catch (Exception ex)
            {
                CommandExceptionGetDetailOrder exceptionGetOrders = new CommandExceptionGetDetailOrder(
                    OrderAccountResources.CommandExceptionGetDetailOrderCode,
                    OrderAccountResources.ClassNameGetDetailOrder,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionGetDetailOrder,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exceptionGetOrders);

                IList<Object> _list = new List<Object>();
                Receiver = _list;

            }

            Logger.WriteSuccessLog(OrderAccountResources.ClassNameValidateProfileByCommensal
                , OrderAccountResources.SuccessMessageCommandExceptionValidateProfileByCommensal
                , System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
                );
        }
    }
}
