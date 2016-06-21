using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Factory;
using FondaLogic.FondaCommandException;
using FondaLogic.FondaCommandException.OrderAccount;
using FondaLogic.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.Commands.OrderAccount
{
    public class CommandCancelInvoice: Command
    {
        public FactoryDAO _facDAO = FactoryDAO.Intance;
        public List<int> _list;
        public string _symbol = null;
        public float _totalOrders = 0;
        public Invoice _invoice;
        public Account _account;

        public CommandCancelInvoice(Object receiver) : base(receiver)
        {
            try
            {
                _list = (List<int>)receiver;
            }
            catch (Exception)
            {
                //TODO: Enviar excepcion personalizada
                throw;
            }
        }
        public override void Execute()
        {
            try
            {
                //Defino el DAO
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
                //TODO: Arrojar Excepcion personalizada
                CommandExceptionCancelInvoice exception = new CommandExceptionCancelInvoice(
                    FondaResources.General.Errors.NullExceptionReferenceCode,
                    FondaResources.OrderAccount.Errors.ClassNameCancelInvoice,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    FondaResources.General.Errors.NullExceptionReferenceMessage,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                _invoice = EntityFactory.GetInvoice();
                Receiver = _invoice;
            }
        }
    }
}
