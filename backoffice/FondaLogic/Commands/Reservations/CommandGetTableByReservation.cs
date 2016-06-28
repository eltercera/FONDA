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
    public class CommandGetTableByReservation : Command
    {
        private Table _table;
        private FactoryDAO _facDAO = FactoryDAO.Intance;
        private int _reservationId;
        //private Reservation _reservation;
        //private IList<object> _list;
        public CommandGetTableByReservation(Object receiver) : base(receiver) { }

        public override void Execute()
        {
            ITableDAO _tableDAO = _facDAO.GetTableDAO();
         //   int _restaurantId;
            try
            {

                _reservationId = (int)Receiver;
                _table = _tableDAO.GetTableByReservation(_reservationId);

                Receiver = _table;

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
