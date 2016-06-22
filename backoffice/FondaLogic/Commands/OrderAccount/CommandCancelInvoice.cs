using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Factory;
using FondaLogic.FondaCommandException;
using FondaLogic.FondaCommandException.OrderAccount;
using FondaLogic.Log;
using FondaResources.OrderAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.Commands.OrderAccount
{
    public class CommandCancelInvoice: Command
    {
        private FactoryDAO _facDAO = FactoryDAO.Intance;
        private List<int> _list;
        private string _symbol = null;
        private float _totalOrders = 0;
        private Invoice _invoice;
        private Account _account;

        public CommandCancelInvoice(Object receiver) : base(receiver){ }

        public override void Execute()
        {
            try
            {
                //Defino el DAO
                _list = (List<int>)Receiver;

                IInvoiceDao _invoiceDAO = _facDAO.GetInvoiceDao();
                IOrderAccountDao _accountDAO = _facDAO.GetOrderAccountDAO();
                int _invoiceId = _list[0];
                int accountId = _list[1];
                _invoice = _invoiceDAO.FindById(_invoiceId);
                _invoice = _accountDAO.CancelInvoice(_invoice, accountId);

                Receiver = (Invoice) _invoice;
            }

            catch (NullReferenceException ex)
            {
                CommandExceptionCancelInvoice exception = new CommandExceptionCancelInvoice(
                    OrderAccountResources.CommandExceptionCancelInvoiceCode,
                    OrderAccountResources.ClassNameCancelInvoice,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionCancelInvoice,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                _invoice = EntityFactory.GetInvoice();
                Receiver = _invoice;
            }
            catch(Exception ex)
            {
                CommandExceptionCancelInvoice exception = new CommandExceptionCancelInvoice(
                    OrderAccountResources.CommandExceptionCancelInvoiceCode,
                    OrderAccountResources.ClassNameCancelInvoice,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionCancelInvoice,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                _invoice = EntityFactory.GetInvoice();
                Receiver = _invoice;
            }

            Logger.WriteSuccessLog(OrderAccountResources.ClassNameCancelInvoice
                , OrderAccountResources.SuccessMessageCommandCancelInvoice
                , System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
                );
        }
    }
}
