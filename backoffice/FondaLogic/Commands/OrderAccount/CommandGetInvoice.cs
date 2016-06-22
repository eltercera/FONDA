using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Factory;
using FondaLogic.FondaCommandException;
using FondaLogic.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.Commands.OrderAccount
{
    public class CommandGetInvoice : Command
    {
        FactoryDAO _facDAO = FactoryDAO.Intance;
        int _invoiceId = 0;

        public CommandGetInvoice(Object receiver) : base(receiver)
        {
            try
            {
                _invoiceId = (int)receiver;
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
                IInvoiceDao _invoiceDAO;
                //Obtengo la instancia del DAO a utilizar
                _invoiceDAO = _facDAO.GetInvoiceDao();
                //Obtengo el objeto con la informacion enviada
                Invoice _invoice = _invoiceDAO.FindById(_invoiceId);
                Receiver = _invoice;

            }
            catch (NullReferenceException ex)
            {
                //TODO: Arrojar Excepcion personalizada
                CommandExceptionGetInvoice exception = new CommandExceptionGetInvoice(
                    FondaResources.General.Errors.NullExceptionReferenceCode,
                    FondaResources.OrderAccount.Errors.ClassNameGetInvoice,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    FondaResources.General.Errors.NullExceptionReferenceMessage,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                Invoice _invoice = EntityFactory.GetInvoice();
                Receiver = _invoice;
            }
        }
    }
}
