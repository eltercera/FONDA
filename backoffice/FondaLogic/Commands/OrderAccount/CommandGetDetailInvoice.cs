using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Logic.FondaLogic.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.Commands.OrderAccount
{
    public class CommandGetDetailInvoice : Command
    {
        private List<int> parameter;

        public CommandGetDetailInvoice(Object receiver) : base(receiver) { }

        public override void Execute()
        {
            IList<DishOrder> listDishOrder = new List<DishOrder>();
            float subtotal = 0;
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
                commandGetDishOrder = CommandFactory.GetCommandGetDishOrdersByAccountId(parameter[1]);

                //Ejecuta el comando deseado
                commandGetInvoice.Execute();
                commandGetCurrencyInvoice.Execute();
                commandGetDishOrder.Execute();

                listDishOrder = (IList<DishOrder>) commandGetDishOrder.Receiver;

                foreach(DishOrder d in listDishOrder)
                {
                    subtotal += d.Dish.Cost * d.Count;
                }

                //Respuesta a devolver
                Receiver = new List<Object>
                    {
                        commandGetInvoice.Receiver,
                        commandGetCurrencyInvoice.Receiver,
                        commandGetDishOrder.Receiver,
                        subtotal
                    };

            }
            catch (Exception ex)
            {

            }
        }
    }
}

  
