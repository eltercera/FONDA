using System;
using System.Web.Http;
using System.Net.Http.Headers;
using System.Linq;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using log4net;
using com.ds201625.fonda.BackEnd.Log;

using com.ds201625.fonda.BackEndLogic;
using com.ds201625.fonda.Factory;
using com.ds201625.fonda.BackEnd.Exceptions;
using FondaBeckEndLogic.Exceptions;

namespace com.ds201625.fonda.BackEnd.Controllers
{
    /// <summary>
    /// Base para los controladores
    /// </summary>
    public abstract class FondaWebApi : ApiController
    {
        public FondaWebApi() : base() { }

        /// <summary>
        /// Obtencion de la Fabrica de DAO
        /// </summary>
        /// <value>The factory DA.</value>
        protected FactoryDAO FactoryDAO
        {
            get { return WebApiApplication.FactoryDAO; }
        }

		/// <summary>
		/// Obtiene el ID del Commensal al que
		/// se encuentra en el Header
		/// </summary>
		/// <returns>El identificador del commensal.</returns>
		/// <param name="header">Header de la peticion.</param>
        protected int GetCommensalId(HttpRequestHeaders header)
        {
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   GeneralRes.BeginLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            String values;
            int value = 0;
            try
            {
                if (header.Contains(GeneralRes.CommensalIDHeader))
                {
                    values = header.GetValues(GeneralRes.CommensalIDHeader).First();
                    value = Int32.Parse(values);
                    Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   GeneralRes.Commensal + value, System.Reflection.MethodBase.GetCurrentMethod().Name);
                }
            }
            catch (Exception e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetCommensalIdFondaWebApiException(GeneralRes.GetCommensalIdException, e);
            }
            //Logger al Culminar el metodo
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, value.ToString(),
                 System.Reflection.MethodBase.GetCurrentMethod().Name);
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                GeneralRes.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            //retorna el id del commensal
            return value;
        }

        protected int GetRestaurantId(HttpRequestHeaders header)
        {
            String values;
            int value = 0;
            if (header.Contains(GeneralRes.RestaurantIDHeader))
            {
                values = header.GetValues(GeneralRes.RestaurantIDHeader).First();
                value = Int32.Parse(values);
            }


            return value;
        }

        /// <summary>
        /// Obtiene el comensal al que pertenese el token pasado por la petición
        /// </summary>
        /// <returns>The commensal.</returns>
        /// <param name="header">Header.</param>
        protected Commensal GetCommensal(HttpRequestHeaders header)
        {
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   GeneralRes.BeginLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            Commensal result = null;
            try
            {
                Commensal commensal = EntityFactory.GetCommensal();
                commensal.Id = GetCommensalId(header);

                // Se obtiene el commando GetCommensalIdCommand
                ICommand command = FacCommand.GetCommensalCommand();
                // Se agrega el comensal como parametro
                command.SetParameter(0, commensal);
                //se ejecuta el comando
                command.Run();

                result = (Commensal)command.Result;

                Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   GeneralRes.Commensal + commensal.Id, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (GetCommensalIdFondaWebApiException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetCommensalFondaWebApiException(GeneralRes.GetCommensalException, e);
            }
            catch (Exception e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetCommensalFondaWebApiException(GeneralRes.AddProfileException, e);
            }
            //Logger al Culminar el metodo
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, result.ToString(),
                 System.Reflection.MethodBase.GetCurrentMethod().Name);
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                GeneralRes.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            //se retorna el comensal que tiene como resultado el comando
            return result;
        }

        protected Restaurant GetRestaurant(HttpRequestHeaders header, int id)
        {
            IRestaurantDAO RestaurantDao = FactoryDAO.GetRestaurantDAO();

            return RestaurantDao.FindById(id);
        }

        protected MenuCategory GetMenuCategory(HttpRequestHeaders header, int id)
        {
            IMenuCategoryDAO MenuCategoryDao = FactoryDAO.GetMenuCategoryDAO();

            return MenuCategoryDao.FindById(id);
        }

		protected BackendFactoryCommand FacCommand
		{
			get { return BackendFactoryCommand.Instance; }
		}

		protected ILog Logger
		{
			get { return Log.Log.Logger; }
		}

		protected void LogDebug (string msg = "")
		{
			if (Logger.IsDebugEnabled)
				Logger.Debug("("+this.ToString () + "): " + msg);
		}

		protected void LogException (Exception e,string msg = "")
		{
			Logger.Error (
				"("+this.ToString () + ") "
				+ msg +	": " + e.Message);
		}

        /// <summary>
        /// Obtiene el Profile solicitado
        /// </summary>
        /// <returns>The Profile.</returns>
        /// <param name="header">Header.</param>
        protected Profile GetProfile(int id)
        {
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   GeneralRes.BeginLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            Profile resultp = null;
            Profile profile = EntityFactory.GetProfile();
            profile.Id = id;
            
            // Se obtiene el commando GetProfileIdCommand
            ICommand command = FacCommand.GetProfileIdCommand();
            // Se agrega el profile como parametro
            command.SetParameter(0, profile);
            //se ejecuta el comando
            try
            {
                command.Run();
                //se retorna el profile que tiene como resultado el comando
                resultp = (Profile)command.Result;
                Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   GeneralRes.Profile + resultp.ProfileName, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (GetCommensalFondaWebApiException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetProfileFondaWebApiException(GeneralRes.GetProfileException, e);
            }
            catch (GetProfileCommandException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetProfileFondaWebApiException(GeneralRes.GetProfileException, e);
            }
            catch (Exception e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetProfileFondaWebApiException(GeneralRes.GetProfileException, e);
            }

            //Logger al Culminar el metodo
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, resultp.ToString(),
                 System.Reflection.MethodBase.GetCurrentMethod().Name);
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                GeneralRes.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            //se retorna el perfil que tiene como resultado el comando
            return resultp;
        }
    }


} 



