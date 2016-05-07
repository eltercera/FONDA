using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using com.ds201625.fonda.DataAccess.FactoryDAO;


namespace com.ds201625.fonda.BackEnd.ActionFilters
{
	public abstract class FondaAuthFilter : AuthorizationFilterAttribute
	{

		public FactoryDAO FactoryDAO
		{
			get { return WebApiApplication.FactoryDAO; }
		}

		public FondaAuthFilter () : base () { }

		public override void OnAuthorization(HttpActionContext context)
		{
			if( !Authorize(context) )
				throw new HttpResponseException(HttpStatusCode.BadGateway);
			
			base.OnAuthorization(context);
		}

		protected abstract bool Authorize (HttpActionContext context);
	}
}

