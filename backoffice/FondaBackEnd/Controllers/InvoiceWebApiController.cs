using System;
using com.ds201625.fonda.Domain;
using System.Net;
using System.Web.Http;
using System.Collections.Generic;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.BackEnd.ActionFilters;

namespace com.ds201625.fonda.BackEnd.Controllers
{
    [RoutePrefix("api")]
    public class InvoiceWebApiController : FondaWebApi
    {
        public InvoiceWebApiController() : base() { }

        [HttpGet]
        [Route("profile/{id}/invoices")]
        [FondaAuthToken]
        public IHttpActionResult requestOpenOrder(int id)
        {
            Profile profile = (FactoryDAO.GetProfileDAO()).FindById(id);

            IList<Invoice> invoiceList = GetInvoiceList(profile);
            if (invoiceList == null)
                return BadRequest();
            return Ok(invoiceList);
        }
        
        private IList<Invoice> GetInvoiceList(Profile profile)
        {
            IInvoiceDao invoice = GetInvoiceDao();
            return invoice.findAllInvoice(profile);
        }
        
        private IInvoiceDao GetInvoiceDao()
        {
            return FactoryDAO.GetInvoiceDao();
        }
    }
}