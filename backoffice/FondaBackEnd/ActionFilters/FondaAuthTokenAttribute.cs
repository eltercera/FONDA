using com.ds201625.fonda.BackEnd.Exceptions;
using com.ds201625.fonda.BackEnd.Log;
using com.ds201625.fonda.BackEndLogic;
using com.ds201625.fonda.BackEndLogic.Exceptions;
using com.ds201625.fonda.Domain;
using System;
using System.Net.Http.Headers;
using System.Web.Http.Controllers;

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
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   GeneralRes.BeginLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
			HttpRequestHeaders headres = context.Request.Headers;
            try
            {
                // Valida si existe Authorization: Fonda xxxxxxxxxxxxxxxxxx
                if (headres.Authorization == null)
                    return false;

                if (headres.Authorization.Scheme != GeneralRes.FondaAuthSheme)
                    return false;

                // validacion del token
                int commID = ValidateAccount(headres.Authorization.Parameter);
                if (commID == 0)
                    return false;

                context.Request.Headers.Add(GeneralRes.CommensalIDHeader, commID.ToString());
            }
            catch (FondaAuthTokenAttributeException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new FondaAuthTokenAttributeException(GeneralRes.Authorize, e);
            }
            catch (Exception e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new FondaAuthTokenAttributeException(GeneralRes.Authorize, e);
            }
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                GeneralRes.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            
			return true;
		}

		/// <summary>
		/// Valizacion de la cuenta por su token
		/// </summary>
		/// <returns>Idnetificacion de la cuenta</returns>
		/// <param name="token">Token.</param>
		private int ValidateAccount(String token)
		{
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   GeneralRes.BeginLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            Token tok;
            int idCommensal;
            try 
            {
                // Se obtiene el commando GetCommensalIdCommand
                ICommand command = BackendFactoryCommand.Instance.GetTokenStrCommands();
                // Se agrega el token como parametro
                command.SetParameter(0, token);
                //se ejecuta el comando
                command.Run();

                tok = (Token)command.Result;
                if (tok == null)
                    idCommensal = 0;
                else
                    idCommensal = tok.Commensal.Id;
                Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   GeneralRes.Commensal + idCommensal, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (GetTokenStrCommandException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new FondaAuthTokenAttributeException(GeneralRes.ValidateAccountTokenException, e);
            }
            catch (Exception e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new FondaAuthTokenAttributeException(GeneralRes.ValidateAccountTokenException, e);
            }
            //Logger al Culminar el metodo
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, idCommensal.ToString(),
                 System.Reflection.MethodBase.GetCurrentMethod().Name);
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                GeneralRes.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            
            //retorna id de commensal
			return idCommensal;
		}
	}
}

