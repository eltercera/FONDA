using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using com.ds201625.fonda.DataAccess.FactoryDAO;

namespace com.ds201625.fonda.BackEnd
{
    public class WebApiApplication : System.Web.HttpApplication
    {

		private static FactoryDAO _factoryDAO = FactoryDAO.Intance;

		public static FactoryDAO FactoryDAO
		{
			get { return _factoryDAO; }
		}

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
