using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using com.ds201625.fonda.DataAccess.FactoryDAO;

namespace com.ds201625.fonda.BackEnd.ActionFilters
{
	/// <summary>
	/// Filtro Perzonalizado para la autenticacion
	/// </summary>
	public abstract class FondaAuthFilter : AuthorizationFilterAttribute
	{
		/// <summary>
		/// Obtine la fabrica de DAO instanciada en la aplicacion web.
		/// </summary>
		/// <value>FactoryDAO.</value>
		public FactoryDAO FactoryDAO
		{
			get { return WebApiApplication.FactoryDAO; }
		}

		public FondaAuthFilter () : base () { }

		/// <summary>
		/// Llamada cuando un metodo requere autenticacion.
		/// </summary>
		/// <param name="context">Context.</param>
		public override void OnAuthorization(HttpActionContext context)
		{
            try
            {
                if (!Authorize(context))
                    throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            catch(Exception e)
            {
                throw e;
            }
			
			base.OnAuthorization(context);
		}

		/// <summary>
		/// Metodo para implementar un tipo de autenticación.
		/// </summary>
		/// <param name="context">Context.</param>
		protected abstract bool Authorize (HttpActionContext context);
	}
}

