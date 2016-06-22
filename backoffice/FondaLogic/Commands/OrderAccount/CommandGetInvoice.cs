using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Factory;
using FondaLogic.FondaCommandException;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using FondaResources.OrderAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.Commands.OrderAccount
{
    public class CommandGetInvoice : Command
    {
        FactoryDAO _facDAO = FactoryDAO.Intance;
        int _invoiceId = 0;

        public CommandGetInvoice(Object receiver) : base(receiver) { }

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
                Receiver = _invoice;

            }
            catch (NullReferenceException ex)
            {
                CommandExceptionGetInvoice exception = new CommandExceptionGetInvoice(
                    OrderAccountResources.CommandExceptionGetInvoiceCode,
                    OrderAccountResources.ClassNameGetInvoice,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionGetInvoice,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                Invoice _invoice = EntityFactory.GetInvoice();
                Receiver = _invoice;

                throw exception;
            }
            catch (Exception ex)
            {
                CommandExceptionGetInvoice exception = new CommandExceptionGetInvoice(
                    OrderAccountResources.CommandExceptionGetInvoiceCode,
                    OrderAccountResources.ClassNameGetInvoice,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionGetInvoice,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                Invoice _invoice = EntityFactory.GetInvoice();
                Receiver = _invoice;

                throw exception;
            }

            Logger.WriteSuccessLog(OrderAccountResources.ClassNameGetInvoice
                , OrderAccountResources.SuccessMessageCommandGetInvoice
                , System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
                );

        }
    }
}
