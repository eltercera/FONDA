using System;
using System.Web.Http.Controllers;
using System.Net.Http.Headers;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System.Text;

namespace com.ds201625.fonda.BackEnd.ActionFilters
{
	public class FondaAuthLoginAttribute : FondaAuthFilter
	{
		public FondaAuthLoginAttribute () : base () { }

		protected override bool Authorize (HttpActionContext context)
		{
			HttpRequestHeaders headres = context.Request.Headers;

			if (headres.Authorization == null 
				| headres.Authorization.Scheme == null
				| headres.Authorization.Parameter == null
			)
				return false;

			if (headres.Authorization.Scheme != "Basic")
				return false;

			String base64 = headres.Authorization.Parameter;
			String data = Encoding.Default.GetString(Convert.FromBase64String(base64));
			String[] crede = data.Split (':');

			if (crede.Length != 2 )
				return false;

			String email = crede[0];
			String password = crede[1];

			int commID = ValidateAccount (email,password);
			if (commID == 0 )
				return false;

			context.Request.Headers.Add ("id", ""+commID);

			return true;
		}

		private int ValidateAccount(String email, String password)
		{
			ICommensalDAO commDAO = FactoryDAO.GetCommensalDAO ();

			UserAccount comm = commDAO.FindByEmail (email);

			if (comm == null)
				return 0;

			if (comm.Password != password)
				return 0;

			return comm.Id;
		}
	}
}

