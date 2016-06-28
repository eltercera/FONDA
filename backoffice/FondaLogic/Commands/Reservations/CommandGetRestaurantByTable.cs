using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
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
    public class CommandGetRestaurantByTable : Command
    {
        private Restaurant _restaurant;
        private FactoryDAO _facDAO = FactoryDAO.Intance;
        private int _tableId;
        //private Reservation _reservation;
        //private IList<object> _list;
        public CommandGetRestaurantByTable(Object receiver) : base(receiver) { }

        public override void Execute()
        {
            IRestaurantDAO _restaurantDAO = _facDAO.GetRestaurantDAO();
         //   int _restaurantId;
            try
            {

                _tableId = (int)Receiver;
                _restaurant = _restaurantDAO.GetRestaurantByTable(_tableId);

                Receiver = _restaurant;

            }
            catch (Exception ex)
            {
                //CommandExceptionGetOrderAccountByInvoice exception = new CommandExceptionGetOrderAccountByInvoice(
                //    OrderAccountResources.CommandExceptionGetOrderAccountByInvoiceCode,
                //    OrderAccountResources.ClassNameGetOrderAccountByInvoice,
                //    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                //    OrderAccountResources.MessageCommandExceptionGetOrderAccountByInvoice,
                //    ex);

                //Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                //throw exception;
            }
            //Logger.WriteSuccessLog(OrderAccountResources.ClassNameGetOrderAccountByInvoice
            //, OrderAccountResources.SuccessMessageCommandGetOrderAccountByInvoice
            //, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
            //);
        }
        }
}
