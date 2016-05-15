using System;
using System.Web.Http;
using System.Net.Http.Headers;
using System.Linq;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;

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
		protected FactoryDAO FactoryDAO
		{
			get { return WebApiApplication.FactoryDAO; }
		}

		protected int GetCommensalId(HttpRequestHeaders header)
		{
			String values;
			int value = 0;
            if (header.Contains(GeneralRes.CommensalIDHeader))
            {
                values = header.GetValues(GeneralRes.CommensalIDHeader).First();
				value =  Int32.Parse(values);
			}


			return value;
		}

		protected Commensal GetCommensal(HttpRequestHeaders header)
		{
			ICommensalDAO commensalDao = FactoryDAO.GetCommensalDAO ();

			return (Commensal) commensalDao.FindById(GetCommensalId(header));
		}
	} 
}

