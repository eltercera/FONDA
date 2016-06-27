using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Logic.FondaLogic.Factory;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using com.ds201625.fonda.Resources.FondaResources.OrderAccount;
using System;
using System.Collections.Generic;

namespace com.ds201625.fonda.Logic.FondaLogic.Commands.OrderAccount
{
    public class CommandGetDetailInvoice : Command
    {
        private IList<int> parameter;
        private IList<object> _list;
        private Account _account;

        public CommandGetDetailInvoice(Object receiver) : base(receiver) { }

        public override void Execute()
        {
            IList<DishOrder> listDishOrder = new List<DishOrder>();
            float subtotal = 0;
            //Invoca al comando
            Command commandGetInvoice;
            Command commandGetDishOrder;
            Command commandGetCurrencyInvoice;
            Command commandGetOrderAccountByInvoice;
            int _invoiceId, _restaurantId;
            try
            {
                parameter = (List<int>) Receiver;
                _invoiceId = parameter[0];
                _restaurantId = parameter[1];
                _list = new List<object>();
                //Obtiene la instancia del comando enviado el restaurante como parametro
                commandGetInvoice = CommandFactory.GetCommandGetInvoice(_invoiceId);
                commandGetCurrencyInvoice = CommandFactory.GetCommandGetCurrencyInvoice(_invoiceId);

                //Ejecuta el comando deseado
                commandGetInvoice.Execute();

                _list.Add ( (Invoice)commandGetInvoice.Receiver);
                _list.Add ( _restaurantId);

                commandGetOrderAccountByInvoice = CommandFactory.GetCommandGetOrderAccountByInvoice(_list);
                commandGetOrderAccountByInvoice.Execute();
                _account = (Account) commandGetOrderAccountByInvoice.Receiver;

                commandGetDishOrder = CommandFactory.GetCommandGetDishOrdersByAccountId(_account.Id);

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
                        subtotal,
                        _account
                    };

            }
            catch (Exception ex)
            {
                CommandExceptionCommandGetDetailInvoice exception = new CommandExceptionCommandGetDetailInvoice(
                    OrderAccountResources.CommandExceptionCommandGetDetailInvoiceCode,
                    OrderAccountResources.ClassNameGetDetailInvoice,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionGenerateInvoice,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                throw exception;
            }

            Logger.WriteSuccessLog(OrderAccountResources.ClassNameGetDetailInvoice
            , OrderAccountResources.SuccessMessageCommandGetDetailInvoice
            , System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
            );
        }
    }
}

  
