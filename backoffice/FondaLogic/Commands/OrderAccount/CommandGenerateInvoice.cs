using com.ds201625.fonda;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System;
using System.Collections.Generic;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using com.ds201625.fonda.Factory;
using com.ds201625.fonda.Resources.FondaResources.OrderAccount;

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
            float _tip=0;
            float tax = 0.12F;
            CreditCardPayment _creditCard;
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
                tax += totalInvoice * tax;
                totalInvoice += tax;

                 if (payment.GetType().Name.Equals(OrderAccountResources.CreditCard))
                {
                    _creditCard = (CreditCardPayment)payment;
                    _tip = _creditCard.Tip;
                }


                if (payment.Amount >= totalInvoice)
                {
                    Invoice invoice = EntityFactory.GetInvoice(payment, profile, totalInvoice, tax);
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
                throw exception;
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
                throw exception;
            }

            Logger.WriteSuccessLog(OrderAccountResources.ClassNameGenerateInvoice
                , OrderAccountResources.SuccessMessageCommandGenerateInvoice
                , System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
                );

        }

    }
}
