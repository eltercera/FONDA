using com.ds201625.fonda;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using com.ds201625.fonda.Resources.FondaResources.OrderAccount;
using System;
using System.Collections.Generic;


namespace com.ds201625.fonda.Logic.FondaLogic.Commands.OrderAccount
{
    public class CommandFindInvoicesByAccount : Command
    {
        private FactoryDAO _facDAO = FactoryDAO.Intance;
        private int _accountId = 0;
        private IList<Invoice> listInvoices;

        public CommandFindInvoicesByAccount(Object receiver) : base(receiver) { }

        public override void Execute()
        {
            try
            {
                _accountId = (int)Receiver;
                //Defino el DAO
                IInvoiceDao _invoicerDAO;
                //Obtengo la instancia del DAO a utilizar
                _invoicerDAO = _facDAO.GetInvoiceDao();
                //Obtengo el objeto con la informacion enviada
                IList<Invoice> listInvoices = _invoicerDAO.FindInvoicesByAccount(_accountId);
                Receiver = listInvoices;

            }
            catch (ArgumentOutOfRangeException ex)
            {
                CommandExceptionFindInvoicesByAccount exception = new CommandExceptionFindInvoicesByAccount(
                    OrderAccountResources.CommandExceptionFindInvoicesByAccountCode,
                    OrderAccountResources.ClassNameFindInvoicesByAccount,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionFindInvoicesByAccount,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);
                listInvoices = new List<Invoice>();
                Receiver = listInvoices;
                throw exception;
            }
            catch (NullReferenceException ex)
            {
                CommandExceptionFindInvoicesByAccount exception = new CommandExceptionFindInvoicesByAccount(
                    OrderAccountResources.CommandExceptionFindInvoicesByAccountCode,
                    OrderAccountResources.ClassNameFindInvoicesByAccount,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionFindInvoicesByAccount,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);
                listInvoices = new List<Invoice>();
                Receiver = listInvoices;
                throw exception;

            }
            catch(Exception ex)
            {
                CommandExceptionFindInvoicesByAccount exception = new CommandExceptionFindInvoicesByAccount(
                    OrderAccountResources.CommandExceptionFindInvoicesByAccountCode,
                    OrderAccountResources.ClassNameFindInvoicesByAccount,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionFindInvoicesByAccount,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);
                listInvoices = new List<Invoice>();
                Receiver = listInvoices;
                throw exception;
            }

            Logger.WriteSuccessLog(OrderAccountResources.ClassNameFindInvoicesByAccount
                , OrderAccountResources.SuccessMessageCommandExceptionFindInvoicesByAccount
                , System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
                );
        }
    }
}
