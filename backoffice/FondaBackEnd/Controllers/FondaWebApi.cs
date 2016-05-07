using System;
using System.Web.Http;
using com.ds201625.fonda.DataAccess.FactoryDAO;

namespace com.ds201625.fonda.BackEnd.Controllers
{
	public abstract class FondaWebApi : ApiController
	{
		public FondaWebApi () : base () { }

		public FactoryDAO FactoryDAO
		{
			get { return WebApiApplication.FactoryDAO; }
		}

	}
}

