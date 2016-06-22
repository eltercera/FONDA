using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Factory;
using FondaLogic.Factory;
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
    public class CommandGetGenerateInvoice : Command
    {

        private FactoryDAO _facDAO = FactoryDAO.Intance;
        private Account _account = EntityFactory.GetAccount();

        public CommandGetGenerateInvoice(Object receiver) : base(receiver) { }

        /// <summary>
        /// Metodo que ejecuta el comando que consulta las ordenes segun un Restaurante
        /// </summary>
        public override void Execute()
        {
            try
            {
                _account = (Account)Receiver;
                //Defino el DAO
                IInvoiceDao _invoiceDAO;
                //Obtengo la instancia del DAO a utilizar
                _invoiceDAO = _facDAO.GetInvoiceDao();
                //Obtengo el objeto con la informacion enviada
                Invoice _invoice = new Invoice();
                _invoice = _invoiceDAO.FindGenerateInvoiceByAccount(_account.Id);
                Receiver = _invoice;

            }
            catch (NullReferenceException ex)
            {
                CommandExceptionGetGenerateInvoice exception = new CommandExceptionGetGenerateInvoice(
                    OrderAccountResources.CommandExceptionGetGenerateInvoiceCode,
                    OrderAccountResources.ClassNameGetGenerateInvoice,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionGetGenerateInvoice,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                Invoice _invoice = new Invoice();
                Receiver = _invoice;
                throw exception;
            }
            catch (Exception ex)
            {
                CommandExceptionGetGenerateInvoice exception = new CommandExceptionGetGenerateInvoice(
                    OrderAccountResources.CommandExceptionGetGenerateInvoiceCode,
                    OrderAccountResources.ClassNameGetGenerateInvoice,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionGetGenerateInvoice,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                Invoice _invoice = new Invoice();
                Receiver = _invoice;
                throw exception;
            }

            Logger.WriteSuccessLog(OrderAccountResources.ClassNameGetGenerateInvoice
                , OrderAccountResources.SuccessMessageCommandGetGenerateInvoice
                , System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
                );
        }

    }
}
