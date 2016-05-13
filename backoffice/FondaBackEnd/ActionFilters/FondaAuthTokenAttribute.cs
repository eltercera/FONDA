using System;
using System.Web.Http.Controllers;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System.Net.Http.Headers;

namespace com.ds201625.fonda.BackEnd.ActionFilters
{
	/// <summary>
	/// Autorizacion por token.
	/// </summary>
	public class FondaAuthTokenAttribute : FondaAuthFilter
	{
		public FondaAuthTokenAttribute () : base () {	}

		/// <summary>
		/// Metodo para implementar un tipo de autenticación por token.
		/// Authorization: Fonda xxxxxxxxxxxxxxxxxx
		/// </summary>
		/// <param name="context">Context.</param>
		protected override bool Authorize (HttpActionContext context)
		{
			HttpRequestHeaders headres = context.Request.Headers;

			// Valida si existe Authorization: Fonda xxxxxxxxxxxxxxxxxx
			if (headres.Authorization == null)
				return false;

			if (headres.Authorization.Scheme != "Fonda")
				return false;

			// validacion del token
			int commID = ValidateAccount (headres.Authorization.Parameter);
			if (commID == 0 )
				return false;

			context.Request.Headers.Add ("id", ""+commID);

			return true;
		}

		/// <summary>
		/// Valizacion de la cuenta por su token
		/// </summary>
		/// <returns>Idnetificacion de la cuenta</returns>
		/// <param name="token">Token.</param>
		private int ValidateAccount(String token)
		{
			ITokenDAO tokDAo= FactoryDAO.GetTokenDAO ();

			Token tok = tokDAo.FindByStrToken(token);

			if (tok == null)
				return 0;

			return tok.Commensal.Id;
		}
	}
}

