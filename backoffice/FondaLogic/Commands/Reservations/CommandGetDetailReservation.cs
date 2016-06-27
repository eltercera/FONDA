using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Logic.FondaLogic.Factory;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using com.ds201625.fonda.Resources.FondaResources.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.Commands.Reservations
{
    public class CommandGetDetailReservation : Command
    {
        private List<int> parameter;

        public CommandGetDetailReservation(Object receiver) : base(receiver) { }
       
        public override void Execute()
        {
            // IList<DishOrder> listDishOrder = new List<DishOrder>();
            // float subtotal = 0;
            //Invoca al comando
            Command commandGetReservationById;
            //   Command commandGetDishOrder;
            //   Command commandGetCurrencyInvoice;
            //   Command commandGetOrder;

            try
            {
                parameter = (List<int>)Receiver;

                //Obtiene la instancia del comando enviado el restaurante como parametro
                commandGetReservationById = CommandFactory.GetCommandGetReservationById(parameter[0]);
                //    commandGetCurrencyInvoice = CommandFactory.GetCommandGetCurrencyInvoice(parameter[0]);
                //     commandGetDishOrder = CommandFactory.GetCommandGetDishOrdersByAccountId(parameter[1]);
                //     commandGetOrder = CommandFactory.GetCommandGetOrder(parameter[1]);

                //Ejecuta el comando deseado
                commandGetReservationById.Execute();
          //      commandGetCurrencyInvoice.Execute();
          //      commandGetDishOrder.Execute();
          //      commandGetOrder.Execute();

          //      listDishOrder = (IList<DishOrder>)commandGetDishOrder.Receiver;

          //      foreach (DishOrder d in listDishOrder)
         //       {
         //           subtotal += d.Dish.Cost * d.Count;
          //      }

                //Respuesta a devolver
                Receiver = new List<Object>
                    {
                        commandGetReservationById.Receiver,
                        //commandGetCurrencyInvoice.Receiver,
                        //commandGetDishOrder.Receiver,
                        //subtotal,
                        //commandGetOrder.Receiver
                    };

            }
            catch (Exception ex)
            {
                CommandExceptionGetDetailReservation exception = new CommandExceptionGetDetailReservation(
                    ReservationErrors.CommandExceptionGetDetailReservationCode,
                    ReservationResources.ClassNameGetDetailReservation,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    ReservationErrors.MessageCommandExceptionGetDetailReservation,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                throw exception;
            }
        }
    }
}

  
