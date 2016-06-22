using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using FondaLogic.Factory;
using FondaLogic.FondaCommandException;
using FondaLogic.Log;
using System;
using System.Collections.Generic;

namespace FondaLogic.Commands.OrderAccount
{
    /// <summary>
    /// Comando para pagar una orden abierta
    /// </summary>
    public class CommandPayOrder : Command
    {
        private FactoryDAO _facDAO = FactoryDAO.Intance;
        private IList<object> parameters;
        private Command generateInvoice, releaseTable, validate;

        public CommandPayOrder(Object receiver) : base() {

            try
            {
                parameters = (IList<object>)receiver;
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
                //ESTO DEBO REFACTORIZARLO
                IOrderAccountDao _accountDAO = _facDAO.GetOrderAccountDAO();
                IRestaurantDAO _restaurantDAO = _facDAO.GetRestaurantDAO();

                bool valid = false;
                int restaurantId = (int)parameters[0];
                int orderId = (int)parameters[1];
                int profileId = (int)parameters[2];
                Payment payment = (Payment)parameters[3];
                Commensal commensal = (Commensal)parameters[4];

                Account order = _accountDAO.FindById(orderId);
                Restaurant restaurant = _restaurantDAO.FindById(restaurantId);

                parameters.Clear();
                parameters.Add(profileId);
                parameters.Add(commensal);
                //Valida que el perfil suministrado pertenezca al comensal
                validate = CommandFactory.GetCommandValidateProfileByCommensal(parameters);
                validate.Execute();
                valid = (bool)validate.Receiver;
                if (valid)
                {
                    parameters.Clear();
                    parameters.Add(payment);
                    parameters.Add(orderId);
                    parameters.Add(restaurantId);
                    parameters.Add(profileId);
                    //Genera la factura
                    generateInvoice = CommandFactory.GetCommandGenerateInvoice(parameters);
                    generateInvoice.Execute();

                    parameters.Clear();
                    parameters.Add(restaurant);
                    parameters.Add(order.Table.Id);
                    //Libera la mesa
                    releaseTable = CommandFactory.GetCommandReleaseTableByRestaurant(parameters);
                    releaseTable.Execute();

                }

                Receiver = generateInvoice.Receiver;

            }
            catch (NullReferenceException ex)
            {
                //TODO: Arrojar Excepcion personalizada
                CommandExceptionPayOrder exception = new CommandExceptionPayOrder(
                    FondaResources.General.Errors.NullExceptionReferenceCode,
                    FondaResources.OrderAccount.Errors.ClassNamePayOrder,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    FondaResources.General.Errors.NullExceptionReferenceMessage,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);
                //Receiver Pago

            }
        }
    }
}
