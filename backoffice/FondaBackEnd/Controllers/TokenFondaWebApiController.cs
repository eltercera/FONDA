using System;
using System.Web.Http;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.BackEnd.ActionFilters;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.DataAccess.Exceptions;

namespace com.ds201625.fonda.BackEnd.Controllers
{
	[RoutePrefix("api")]
	public class TokenFondaWebApiController : FondaWebApi
	{
		public TokenFondaWebApiController () : base () {}

		[FondaAuthLogin]
		[Route("token")]
		[HttpPost]
		public IHttpActionResult getToken()
		{
			Commensal commensal = GetCommensal (Request.Headers);
			if (commensal == null)
				return BadRequest ();

			ICommensalDAO commensalDao = FactoryDAO.GetCommensalDAO ();
			Token token = new Token ();
			commensal.AddToken (token);

			try
			{
				commensalDao.Save (commensal);
			}
			catch (SaveEntityFondaDAOException e)
			{
				Console.WriteLine (e.ToString ());
				return InternalServerError (e);
			}

			return Ok (token);
		}

        [FondaAuthLogin]
        [Route("token/{id}")]
        [HttpDelete]
        public IHttpActionResult deleteToken(int id)
        {
            Commensal commensal = GetCommensal(Request.Headers);
            if (commensal == null)
                return BadRequest();

            ICommensalDAO commensalDao = FactoryDAO.GetCommensalDAO();
            ITokenDAO tokenDAO = FactoryDAO.GetTokenDAO();
            Token token = tokenDAO.FindById(id);

            commensal.RemoveToken(token);

            try
            {
                commensalDao.Save(commensal);
                tokenDAO.Delete(token);
            }
            catch (SaveEntityFondaDAOException e)
            {
                Console.WriteLine(e.ToString());
                return InternalServerError(e);
            }

            return Ok();
        }



    }
}

