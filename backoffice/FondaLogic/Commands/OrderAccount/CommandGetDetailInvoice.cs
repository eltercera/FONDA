using FondaLogic.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.Commands.OrderAccount
{
    public class CommandGetDetailInvoice : Command
    {
        private List<int> parameter;

        public CommandGetDetailInvoice(Object receiver) : base(receiver) { }

        public override void Execute()
        {
            //Invoca al comando
            Command commandGetInvoice;
            Command commandGetDishOrder;
            Command commandGetCurrencyInvoice;

            try
            {
                parameter = (List<int>)Receiver;

                //Obtiene la instancia del comando enviado el restaurante como parametro
                commandGetInvoice = CommandFactory.GetCommandGetInvoice(parameter[0]);
                commandGetCurrencyInvoice = CommandFactory.GetCommandGetCurrencyInvoice(parameter[0]);
                commandGetDishOrder = CommandFactory.GetDetailOrder(parameter[1]);

                //Ejecuta el comando deseado
                commandGetInvoice.Execute();
                commandGetCurrencyInvoice.Execute();
                commandGetDishOrder.Execute();

                //Respuesta a devolver
                Receiver = new List<Object>
                    {
                        commandGetInvoice.Receiver,
                        commandGetCurrencyInvoice.Receiver,
                        commandGetDishOrder.Receiver
                    };

            }
            catch (Exception ex)
            {

            }
        }
    }
}

  
