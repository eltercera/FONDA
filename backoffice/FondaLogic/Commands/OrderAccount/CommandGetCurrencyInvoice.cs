using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.Commands.OrderAccount
{
    public class CommandGetCurrencyInvoice : Command
    {

        FactoryDAO _facDAO = FactoryDAO.Intance;
        int _invoiceId = 0;
        string _symbol = null;

        public CommandGetCurrencyInvoice(Object receiver) : base(receiver)
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
                Currency curr = new Currency();
                curr = _invoice.Currency;
                _symbol = curr.Symbol;

                Receiver = _symbol;
            }
            catch (Exception ex)
            {
            }
        }
    }
}
