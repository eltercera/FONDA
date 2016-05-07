using System;
using System.Web.Http;
using com.ds201625.fonda.DataAccess.FactoryDAO;

namespace com.ds201625.fonda.BackEnd.Controllers
{
	/// <summary>
	/// Base para los controladores
	/// </summary>
	public abstract class FondaWebApi : ApiController
	{
		public FondaWebApi () : base () { }

		/// <summary>
		/// Obtencion de la Fabrica de DAO
		/// </summary>
		/// <value>The factory DA.</value>
		public FactoryDAO FactoryDAO
		{
			get { return WebApiApplication.FactoryDAO; }
		}

	}
}

