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
        [Route("open_order")]
        [FondaAuthToken]
        public IHttpActionResult requestOpenOrder()
        {
            Console.WriteLine("-------------------------------");
            Commensal commensal = GetCommensal(Request.Headers);
            if (commensal == null)
                return BadRequest();
            IList<Invoice> invoiceList = GetInvoiceList(commensal);
            if (invoiceList == null)
                return BadRequest();
            return Ok(invoiceList);
        }

        private IList<Invoice> GetInvoiceList(Commensal commensal)
        {
            IInvoiceDao invoice = GetInvoiceDao();
            return null;
        }

        private IInvoiceDao GetInvoiceDao()
        {
            return FactoryDAO.GetInvoiceDao();
        }
    }
}