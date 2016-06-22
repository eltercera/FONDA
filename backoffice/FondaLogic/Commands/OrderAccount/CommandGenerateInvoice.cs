using com.ds201625.fonda;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System;
using System.Collections.Generic;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using com.ds201625.fonda.Factory;
using FondaResources.OrderAccount;

namespace com.ds201625.fonda.Logic.FondaLogic.Commands.OrderAccount
{
    public class CommandGenerateInvoice : Command
    {
        private FactoryDAO _facDAO = FactoryDAO.Intance;
        private IList<object> _list;
        private Invoice _invoice;
        private Profile profile;

        public CommandGenerateInvoice(Object receiver) : base(receiver) { }

        public override void Execute()
        {
            List<Object> parameters;
            Payment payment;
            Account account;
            try
            {
                _list = (IList<object>)Receiver;

                IPaymentDao<Payment> _paymentDAO = _facDAO.GetPaymentDAO();
                IProfileDAO _profileDAO = _facDAO.GetProfileDAO();
                IOrderAccountDao _accountDAO = _facDAO.GetOrderAccountDAO();

                parameters = (List<Object>)Receiver;

                payment = (Payment)parameters[0];
                int orderId = (int)parameters[1];
                int restaurantId = (int)parameters[2];
                int profileId = (int)parameters[3];

                account = _accountDAO.FindById(orderId);
                profile = _profileDAO.FindById(profileId);

                float totalInvoice = account.GetAmount();
                //ESTO TIENE QUE CAMBIARSE POR UN RECURSO
                totalInvoice += totalInvoice * 0.12F;

                //VERIFICA QUE EL PAGO SEA MAYOR O IGUAL QUE EL TOTAL DE LA FACTURA
                //ES OTRO COMANDO?
                if (payment.Amount >= totalInvoice)
                {
                    //ESTE CONSTRUCTOR DEBO REVISARLO
                    Invoice invoice = EntityFactory.GetInvoice(payment, profile, payment.Amount, totalInvoice, null, 100, null);

                    _invoice = _accountDAO.SaveInvoice(invoice, orderId, restaurantId);
                }
                else
                    throw new NullReferenceException();



                Receiver = _invoice;

            }
            catch (NullReferenceException ex)
            {
                CommandExceptionGenerateInvoice exception = new CommandExceptionGenerateInvoice(
                    OrderAccountResources.CommandExceptionGenerateInvoiceCode,
                    OrderAccountResources.ClassNameGenerateInvoice,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionGenerateInvoice,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                _invoice = EntityFactory.GetInvoice(); ;
                Receiver = _invoice;
            }
            catch (Exception ex)
            {
                CommandExceptionGenerateInvoice exception = new CommandExceptionGenerateInvoice(
                    OrderAccountResources.CommandExceptionGenerateInvoiceCode,
                    OrderAccountResources.ClassNameGenerateInvoice,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionGenerateInvoice,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                _invoice = EntityFactory.GetInvoice(); ;
                Receiver = _invoice;
            }

            Logger.WriteSuccessLog(OrderAccountResources.ClassNameGenerateInvoice
                , OrderAccountResources.SuccessMessageCommandGenerateInvoice
                , System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
                );

        }

    }
}
