using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace com.ds201625.fonda.BackEnd.Controllers
{
    [RoutePrefix("api")]
    public class PaymentFondaWebApiController : FondaWebApi
    {
        public PaymentFondaWebApiController() : base() { }

        [Route("payment")]
        [HttpPost]
        public IHttpActionResult setPayments(Invoice invoice)
        {

            return Created("", invoice);

        }
    }
}