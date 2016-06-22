using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using FondaResources.OrderAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.Commands.OrderAccount
{
    public class CommandFindInvoicesByRestaurant : Command
    {
        private FactoryDAO _facDAO = FactoryDAO.Intance;
        private Restaurant _restaurant = new Restaurant();
        private int _restaurantId = 0;
        private IList<Invoice> listInvoices;

        public CommandFindInvoicesByRestaurant(Object receiver) : base(receiver){ }

        public override void Execute()
        {
            try
            {
                _restaurantId = (int)Receiver;
                //Defino el DAO
                IInvoiceDao _invoicerDAO;
                IRestaurantDAO _restaurantDAO;
                //Obtengo la instancia del DAO a utilizar
                _invoicerDAO = _facDAO.GetInvoiceDao();
                _restaurantDAO = _facDAO.GetRestaurantDAO();
                _restaurant = _restaurantDAO.FindById(_restaurantId);
                //Obtengo el objeto con la informacion enviada
                IList<Invoice> listInvoices = _invoicerDAO.FindInvoicesByRestaurant(_restaurant);
                Receiver = listInvoices;

            }
            catch (NullReferenceException ex)
            {
                //TODO: Arrojar Excepcion personalizada
                CommandExceptionFindInvoicesByRestaurant exception= new CommandExceptionFindInvoicesByRestaurant(
                    OrderAccountResources.CommandExceptionFindInvoicesByRestaurantCode,
                    OrderAccountResources.ClassNameFindInvoicesByRestaurant,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionFindInvoicesByRestaurant,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                listInvoices = new List<Invoice>();
                Receiver = listInvoices;
            }
            catch (Exception ex)
            {
                //TODO: Arrojar Excepcion personalizada
                CommandExceptionFindInvoicesByRestaurant exception = new CommandExceptionFindInvoicesByRestaurant(
                    OrderAccountResources.CommandExceptionFindInvoicesByRestaurantCode,
                    OrderAccountResources.ClassNameFindInvoicesByRestaurant,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionFindInvoicesByRestaurant,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                listInvoices = new List<Invoice>();
                Receiver = listInvoices;
            }

            Logger.WriteSuccessLog(OrderAccountResources.ClassNameFindInvoicesByRestaurant
                , OrderAccountResources.SuccessMessageCommandCancelInvoice
                , System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
                );

        }
    }
}
