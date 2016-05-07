using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using Newtonsoft.Json.Serialization;

namespace com.ds201625.fonda.BackEnd
{
    public class WebApiApplication : System.Web.HttpApplication
    {
		/// <summary>
		/// instancia del la Fabrica de DAO
		/// </summary>
		private static FactoryDAO _factoryDAO = FactoryDAO.Intance;

		public static FactoryDAO FactoryDAO
		{
			get { return _factoryDAO; }
		}

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
			HttpConfiguration config = GlobalConfiguration.Configuration;
			config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver ();
			config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;
        }
    }
}
