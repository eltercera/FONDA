using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using FondaLogic.FondaCommandException.OrderAccount;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.Commands.OrderAccount
{
    public class CommandGetInvoicesByProfile : Command
    {
        private FactoryDAO _facDAO = FactoryDAO.Intance;

        public CommandGetInvoicesByProfile(Object receiver) : base(receiver) { }

        public override void Execute()
        {
            IInvoiceDao _invoicesDAO;
            IProfileDAO _profileDAO;
            Profile profile;
            int _profileId = 0;
            IList<Invoice> listInvoices;

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
                CommandExceptionGetInvoicesByProfile e = new CommandExceptionGetInvoicesByProfile("Falta personalizar");
                Logger.WriteErrorLog("Null", ex);
                throw e;
            }
            catch (findAllInvoiceFondaDAOException ex)
            {
                CommandExceptionGetInvoicesByProfile e = new CommandExceptionGetInvoicesByProfile("Falta personalizar");
                Logger.WriteErrorLog("Null", ex);
                throw e;
            }
            catch (Exception ex)
            {
                CommandExceptionGetInvoicesByProfile e = new CommandExceptionGetInvoicesByProfile("Falta personalizar");
                Logger.WriteErrorLog("general", ex);
                throw e;

            }
        }

    }
}
