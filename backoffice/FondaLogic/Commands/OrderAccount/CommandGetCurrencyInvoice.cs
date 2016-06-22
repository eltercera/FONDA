using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Logic.FondaCommandException.OrderAccount;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using com.ds201625.fonda.Resources.FondaResources.OrderAccount;
using System;


namespace com.ds201625.fonda.Logic.FondaLogic.Commands.OrderAccount
{
    public class CommandGetCurrencyInvoice : Command
    {

        private FactoryDAO _facDAO = FactoryDAO.Intance;
        private int _invoiceId = 0;
        private string _symbol = null;

        public CommandGetCurrencyInvoice(Object receiver) : base(receiver) { }
        public override void Execute()
        {
            try
            {
                _invoiceId = (int)Receiver;
                //Defino el DAO
                IInvoiceDao _invoiceDAO;
                //Obtengo la instancia del DAO a utilizar
                _invoiceDAO = _facDAO.GetInvoiceDao();
                //Obtengo el objeto con la informacion enviada
                Invoice _invoice = _invoiceDAO.FindById(_invoiceId);
                Currency curr = new Currency();
                curr = _invoice.Currency;
                _symbol = curr.Symbol;

                Receiver = _symbol;
            }
            catch (Exception ex)
            {
                CommandExceptionGetCurrencyInvoice exception = new CommandExceptionGetCurrencyInvoice(
                    OrderAccountResources.CommandExceptionGetCurrencyInvoiceCode,
                    OrderAccountResources.ClassNameGetCurrencyInvoice,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionGetCurrencyInvoice,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                Receiver = string.Empty;

                throw exception;
            }

            Logger.WriteSuccessLog(OrderAccountResources.ClassNameGetCurrencyInvoice
                , OrderAccountResources.SuccessMessageCommandGetCurrencyInvoice
                , System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
                );
        }
    }
}
