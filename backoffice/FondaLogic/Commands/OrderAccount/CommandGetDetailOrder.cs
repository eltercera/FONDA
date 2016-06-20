using com.ds201625.fonda.Domain;
using FondaLogic.Factory;
using FondaLogic.FondaCommandException;
using FondaLogic.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.Commands.OrderAccount
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
            catch (Exception ex)
            {
                //TODO: Arrojar Excepcion personalizada
                CommandExceptionGetDetailOrder exceptionGetOrders = new CommandExceptionGetDetailOrder(
                    FondaResources.General.Errors.NullExceptionReferenceCode,
                    FondaResources.OrderAccount.Errors.ClassNameGetDetailOrder,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    FondaResources.General.Errors.NullExceptionReferenceMessage,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exceptionGetOrders);

                IList<Object> _list = new List<Object>();
                Receiver = _list;

            }
        }
    }
}
