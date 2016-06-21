using com.ds201625.fonda;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System;
using System.Collections.Generic;
using FondaLogic.FondaCommandException;
using FondaLogic.Log;
using com.ds201625.fonda.Factory;

namespace FondaLogic.Commands.OrderAccount
{
    public class CommandGenerateInvoice : Command
    {
        private FactoryDAO _facDAO = FactoryDAO.Intance;
        private IList<object> _list;
        private Invoice _invoice;
        private Profile profile;

        public CommandGenerateInvoice(Object receiver) : base(receiver)
        {
            try
            {
                _list = (IList<object>)receiver;
            }
            catch (Exception)
            {
                //TODO: Enviar excepcion personalizada
                throw;
            }
        }

        public override void Execute()
        {
            List<Object> parameters;
            Payment payment;
            try
            {
                IPaymentDao<Payment> _paymentDAO = _facDAO.GetPaymentDAO();
                IProfileDAO _profileDAO = _facDAO.GetProfileDAO();
                IOrderAccountDao _accountDAO = _facDAO.GetOrderAccountDAO();

                parameters = (List<Object>)Receiver;

                payment = (Payment)parameters[0];
                int orderId = (int)parameters[1];
                int restaurantId = (int)parameters[2];
                int profileId = (int)parameters[3];

                //ESTO TIENE QUE CAMBIARSE POR UN RECURSO
                float totalInvoice = payment.Amount * 0.12F;
                profile = _profileDAO.FindById(profileId);

                //ESTE CONSTRUCTOR DEBO REVISARLO
                Invoice invoice = EntityFactory.GetInvoice(payment, profile, payment.Amount, totalInvoice , null, 100, null);

                _invoice =_accountDAO.SaveInvoice(invoice, orderId, restaurantId);

                Receiver = _invoice;

            }
            catch (NullReferenceException ex)
            {
                //TODO: Arrojar Excepcion personalizada
                CommandExceptionGenerateInvoice exception = new CommandExceptionGenerateInvoice(
                    FondaResources.General.Errors.NullExceptionReferenceCode,
                    FondaResources.OrderAccount.Errors.ClassNameGenerateInvoice,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    FondaResources.General.Errors.NullExceptionReferenceMessage,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                _invoice = EntityFactory.GetInvoice(); ;
                Receiver = _invoice;
            }

        }

    }
}
