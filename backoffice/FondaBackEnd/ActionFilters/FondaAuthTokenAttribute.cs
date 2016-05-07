using System;
using System.Web.Http.Controllers;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System.Net.Http.Headers;

namespace com.ds201625.fonda.BackEnd.ActionFilters
{
	public class FondaAuthTokenAttribute : FondaAuthFilter
	{
		public FondaAuthTokenAttribute () : base () {	}

		protected override bool Authorize (HttpActionContext context)
		{
			HttpRequestHeaders headres = context.Request.Headers;

			if (headres.Authorization == null)
				return false;

			if (headres.Authorization.Scheme != "Fonda")
				return false;

			int commID = ValidateAccount (headres.Authorization.Parameter);
			if (commID == 0 )
				return false;

			context.Request.Headers.Add ("id", ""+commID);

			return true;
		}

		private int ValidateAccount(String token)
		{
			ICommensalDAO commDAO = FactoryDAO.GetCommensalDAO ();

			Commensal comm = commDAO.FindByToken(token);

			if (comm == null)
				return 0;

			return comm.Id;
		}
	}
}

