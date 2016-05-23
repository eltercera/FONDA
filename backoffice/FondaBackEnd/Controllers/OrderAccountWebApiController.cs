using System;
using com.ds201625.fonda.Domain;
using System.Net;
using System.Web.Http;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.BackEnd.ActionFilters;

namespace com.ds201625.fonda.BackEnd.Controllers
{
    [RoutePrefix("api")]
    public class OrderAccountWebApiController : FondaWebApi
    {

        public OrderAccountWebApiController() : base() { }

        [HttpGet]
        [Route("open_order")]
        [FondaAuthToken]
        public IHttpActionResult requestOpenOrder()
        {
            Commensal commensal = GetCommensal(Request.Headers);
            if (commensal == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            Account account = GetAccount(commensal);
            if (account == null)
                return BadRequest();
            /// Cambiar a Excepcion
            return Ok(account);
        }
        
        [Route("profile/{id}/{tip}/CreditCarPayment/")]
        [HttpPost]
        [FondaAuthToken]
        public IHttpActionResult requestClosedOrder(int id, float tip,[FromBody] CreditCarPayment payment)
        {
            Commensal commensal = GetCommensal(Request.Headers);
            if (commensal == null)
                return BadRequest();
            
            IProfileDAO profileDAO = FactoryDAO.GetProfileDAO();
            IOrderAccountDao orderAccountDao = GetOrderAccountDao();
            IInvoiceDao invoiceDAO = FactoryDAO.GetInvoiceDao();
            //IRestaurantDAO restaurantDAO = FactoryDAO.GetRestaurantDAO();
            ICreditCardPaymentDAO  paymentDAO= FactoryDAO.GetCreditCardPaymentDAO();
            Profile profile = profileDAO.FindById(id);
            if (profile == null)
                return BadRequest();
            try
            {
                paymentDAO.Save(payment);
            }
            catch (SaveEntityFondaDAOException e)
            {
                Console.WriteLine(e.ToString());
                return InternalServerError(e);
            }
            
            Account account = GetAccount(commensal);
            account.Status = FactoryDAO.GetClosedAccountStatus();
            try
            {
                orderAccountDao.Save(account);
            }
            catch (SaveEntityFondaDAOException e)
            {
                Console.WriteLine(e.ToString());
                return InternalServerError(e);
            }

            float total = 0;
            foreach (DishOrder dish in account.ListDish)
            {
                total += dish.Dishcost * dish.Count;
            }
            
            Invoice invoice = new Invoice();
            invoice.Account = account;
            invoice.Payment = payment;
            invoice.Status = FactoryDAO.GetGeneratedInvoiceStatus();
            invoice.Restaurant = account.Table.Restaurant;// restaurantDAO.findByTable(account.Table);
            invoice.Tip = tip;
            invoice.Tax = 10;
            invoice.Total = total;
            invoice.Profile = profile;
            invoice.Date = DateTime.Now;

            try
            {
                invoiceDAO.Save(invoice);
            }
            catch (SaveEntityFondaDAOException e)
            {
                Console.WriteLine(e.ToString());
                return InternalServerError(e);
            }
            
            return Ok(invoice);
        }

        private Account GetAccount(Commensal commensal)
        {
            IOrderAccountDao orderAccount = GetOrderAccountDao();
            return (Account) orderAccount.FindByCommensal(commensal);
        }

        private IOrderAccountDao GetOrderAccountDao()
        {
            return FactoryDAO.GetOrderAccountDAO();
        }
        
    }
}