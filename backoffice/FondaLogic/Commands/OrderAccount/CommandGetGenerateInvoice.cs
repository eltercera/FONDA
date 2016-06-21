using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Factory;
using FondaLogic.Factory;
using FondaLogic.FondaCommandException;
using FondaLogic.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.Commands.OrderAccount
{
    public class CommandGetGenerateInvoice : Command
    {

        FactoryDAO _facDAO = FactoryDAO.Intance;
        Account _account = EntityFactory.GetAccount();

        public CommandGetGenerateInvoice(Object receiver) : base(receiver)
        {
            try
            {
                _account = (Account)receiver;
            }
            catch (Exception)
            {
                //TODO: Enviar excepcion personalizada
                throw;
            }
        }

        /// <summary>
        /// Metodo que ejecuta el comando que consulta las ordenes segun un Restaurante
        /// </summary>
        public override void Execute()
        {
            try
            {
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
                //TODO: Arrojar Excepcion personalizada
                CommandExceptionGetGenerateInvoice exception = new CommandExceptionGetGenerateInvoice(
                    FondaResources.General.Errors.NullExceptionReferenceCode,
                    FondaResources.OrderAccount.Errors.ClassNameGetGenerateInvoice,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    FondaResources.General.Errors.NullExceptionReferenceMessage,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                Invoice _invoice = new Invoice();
                Receiver = _invoice;
            }
        }

    }
}
