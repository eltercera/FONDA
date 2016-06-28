using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
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
    public class CommandGetOrderAccountByInvoice : Command
    {
        private Account _account;
        private FactoryDAO _facDAO = FactoryDAO.Intance;
        private Invoice _invoice;
        private IList<object> _list;
        public CommandGetOrderAccountByInvoice(Object receiver) : base(receiver) { }

        public override void Execute()
        {
            IOrderAccountDao _accountDao = _facDAO.GetOrderAccountDAO();
            int _restaurantId;
            try
            {
                _list = (List<object>)Receiver;
                _invoice = (Invoice) _list[0];
                _restaurantId = (int)_list[1];
                _account = _accountDao.GetOrderAccountByInvoice(_invoice,_restaurantId);

                Receiver = _account;

            }
            catch (Exception ex)
            {
                CommandExceptionGetOrderAccountByInvoice exception = new CommandExceptionGetOrderAccountByInvoice(
                    OrderAccountResources.CommandExceptionGetOrderAccountByInvoiceCode,
                    OrderAccountResources.ClassNameGetOrderAccountByInvoice,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionGetOrderAccountByInvoice,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                throw exception;
            }
            Logger.WriteSuccessLog(OrderAccountResources.ClassNameGetOrderAccountByInvoice
            , OrderAccountResources.SuccessMessageCommandGetOrderAccountByInvoice
            , System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
            );
        }
        }
}
