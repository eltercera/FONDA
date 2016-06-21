using com.ds201625.fonda;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using FondaLogic.FondaCommandException;
using FondaLogic.FondaCommandException.OrderAccount;
using FondaLogic.Log;
using System;
using System.Collections.Generic;


namespace FondaLogic.Commands.OrderAccount
{
    public class CommandFindInvoicesByAccount : Command
    {
        private FactoryDAO _facDAO = FactoryDAO.Intance;
        private int _accountId = 0;
        private IList<Invoice> listInvoices;

        public CommandFindInvoicesByAccount(Object receiver) : base(receiver)
        {
            try
            {
                _accountId = (int)receiver;
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
                IInvoiceDao _invoicerDAO;
                //Obtengo la instancia del DAO a utilizar
                _invoicerDAO = _facDAO.GetInvoiceDao();
                //Obtengo el objeto con la informacion enviada
                IList<Invoice> listInvoices = _invoicerDAO.FindInvoicesByAccount(_accountId);
                Receiver = listInvoices;

            }
            catch (NullReferenceException ex)
            {
                //TODO: Arrojar Excepcion personalizada
                CommandExceptionFindInvoicesByAccount exception = new CommandExceptionFindInvoicesByAccount(
                    FondaResources.General.Errors.NullExceptionReferenceCode,
                    FondaResources.OrderAccount.Errors.ClassNameFindInvoicesByAccount,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    FondaResources.General.Errors.NullExceptionReferenceMessage,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                listInvoices = new List<Invoice>();
                Receiver = listInvoices;

            }
        }
    }
}
