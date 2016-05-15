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
    public class OpenOrderAccountWebApiController : FondaWebApi
    {

        public OpenOrderAccountWebApiController() : base() { }

        [HttpGet]
        [Route("open_order")]
        [FondaAuthToken]
        public IHttpActionResult requestOpenOrder()
        {
            Commensal commensal = GetCommensal(Request.Headers);
            if (commensal == null)
                return BadRequest();
            Account account = GetAccount(commensal);
            if (account == null)
                return BadRequest();
            /// Cambiar a Excepcion
            return Ok(account.ListDish);
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