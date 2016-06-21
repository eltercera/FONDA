using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using FondaLogic.FondaCommandException;
using FondaLogic.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.Commands.OrderAccount
{
    public class CommandFindInvoicesByRestaurant : Command
    {
        FactoryDAO _facDAO = FactoryDAO.Intance;
        Restaurant _restaurant = new Restaurant();
        IList<Invoice> listInvoices;

        public CommandFindInvoicesByRestaurant(Object receiver) : base(receiver)
        {
            try
            {
                _restaurant = (Restaurant)receiver;
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
                IList<Invoice> listInvoices = _invoicerDAO.FindInvoicesByRestaurant(_restaurant);
                Receiver = listInvoices;

            }
            catch (NullReferenceException ex)
            {
                //TODO: Arrojar Excepcion personalizada
                CommandExceptionFindInvoicesByRestaurant exception= new CommandExceptionFindInvoicesByRestaurant(
                    FondaResources.General.Errors.NullExceptionReferenceCode,
                    FondaResources.OrderAccount.Errors.ClassNameFindInvoicesByRestaurant,
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
