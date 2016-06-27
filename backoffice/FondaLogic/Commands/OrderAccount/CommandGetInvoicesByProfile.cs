using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.OrderAccount;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using com.ds201625.fonda.Resources.FondaResources.OrderAccount;
using System;
using System.Collections.Generic;

namespace com.ds201625.fonda.Logic.FondaLogic.Commands.OrderAccount
{
    public class CommandGetInvoicesByProfile : Command
    {
        private FactoryDAO _facDAO = FactoryDAO.Intance;
        private IInvoiceDao _invoicesDAO;
        private IProfileDAO _profileDAO;
        private Profile profile;
        private int _profileId = 0;
        private IList<Invoice> listInvoices;

        public CommandGetInvoicesByProfile(Object receiver) : base(receiver) { }

        public override void Execute()
        {
            try
            {

                _profileId = (int) Receiver;
                _invoicesDAO = _facDAO.GetInvoiceDao();
                _profileDAO = _facDAO.GetProfileDAO();

                profile = _profileDAO.FindById(_profileId);
                listInvoices = _invoicesDAO.findAllInvoice(profile);
                Receiver = listInvoices;

            }
            catch(NullReferenceException ex)
            {
                CommandExceptionGetInvoicesByProfile e = new CommandExceptionGetInvoicesByProfile
                    (OrderAccountResources.CommandExceptionGetInvoicesByProfileCode,
                    OrderAccountResources.ClassNameGetInvoicesByProfile,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionGetInvoicesByProfile,
                    ex);
                Logger.WriteErrorLog(e.ClassName, e);
                throw e;
            }
            catch (FindAllInvoiceFondaDAOException ex)
            {
                CommandExceptionGetInvoicesByProfile e = new CommandExceptionGetInvoicesByProfile
                    (OrderAccountResources.CommandExceptionGetInvoicesByProfileCode,
                    OrderAccountResources.ClassNameGetInvoicesByProfile,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionGetInvoicesByProfile,
                    ex);
                Logger.WriteErrorLog(e.ClassName, e);
                throw e;
            }
            catch (Exception ex)
            {
                CommandExceptionGetInvoicesByProfile e = new CommandExceptionGetInvoicesByProfile
                    (OrderAccountResources.CommandExceptionGetInvoicesByProfileCode,
                    OrderAccountResources.ClassNameGetInvoicesByProfile,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionGetInvoicesByProfile,
                    ex);
                Logger.WriteErrorLog(e.ClassName, e);
                throw e;

            }

            Logger.WriteSuccessLog(OrderAccountResources.ClassNameGetInvoicesByProfile
                , OrderAccountResources.SuccessMessageCommandGetInvoicesByProfile
                , System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
                );


        }

    }
}
