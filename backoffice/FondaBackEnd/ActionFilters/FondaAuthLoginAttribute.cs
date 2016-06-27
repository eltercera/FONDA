using System;
using System.Web.Http.Controllers;
using System.Net.Http.Headers;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System.Text;
using com.ds201625.fonda.BackEnd.Log;
using com.ds201625.fonda.BackEndLogic;
using com.ds201625.fonda.BackEnd.Exceptions;
using com.ds201625.fonda.BackEndLogic.Exceptions;

namespace com.ds201625.fonda.BackEnd.ActionFilters
{
	/// <summary>
	/// Filtro que implementa una autenticación basica.
	/// Authorization: Basic xxxxxx:xxxxxxx
	/// </summary>
	public class FondaAuthLoginAttribute : FondaAuthFilter
	{
		public FondaAuthLoginAttribute () : base () { }

		/// <summary>
		/// Metodo para implementar la autenticación basica.
		/// </summary>
		/// <param name="context">Context.</param>
		protected override bool Authorize (HttpActionContext context)
		{
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   GeneralRes.BeginLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
			HttpRequestHeaders headres = context.Request.Headers;

            try
            {
                // Verificacion de la existencia de 
                // Authorization: Basic xxxxxxx:xxxxxx
                if (headres.Authorization == null
                    | headres.Authorization.Scheme == null
                    | headres.Authorization.Parameter == null
                )
                    return false;

                if (headres.Authorization.Scheme != GeneralRes.BasicAuthSheme)
                    return false;

                // Obtencion de los datos en xxxxxxx:xxxxxx
                String base64 = headres.Authorization.Parameter;
                String data = Encoding.Default.GetString(Convert.FromBase64String(base64));
                String[] crede = data.Split(':');

                if (crede.Length != 2)
                    return false;

                String email = crede[0];
                String password = crede[1];

                // Validadcion
                int commID = ValidateAccount(email, password);
                if (commID == 0)
                    return false;

                // Agregacion en el header el id del usuario
                // para el uso interno de las acciones
                context.Request.Headers.Add(GeneralRes.CommensalIDHeader, "" + commID);
            }
            catch (FondaAuthLoginAttributeException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new FondaAuthLoginAttributeException(GeneralRes.Authorize, e);
            }
            catch (Exception e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new FondaAuthLoginAttributeException(GeneralRes.Authorize, e);
            }
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                GeneralRes.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            
			return true;
		}

		/// <summary>
		/// Valida una la cuenta de usuario
		/// </summary>
		/// <returns>Identificador de la cuenta.</returns>
		/// <param name="email">Email.</param>
		/// <param name="password">Password.</param>
		private int ValidateAccount(String email, String password)
		{
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   GeneralRes.BeginLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            UserAccount user;
            int idCommensal;
            try
            {
                 // Se obtiene el commando CreateCreateProfileCommand 
                ICommand command = BackendFactoryCommand.Instance.GetAccountEmailCommands();

                // Se agrega el email como parametro
                command.SetParameter(0, email);
                
                //se ejecuta el comando
                command.Run();

                user = (UserAccount)command.Result;

                if (user == null || user.Password != password)
                    idCommensal = 0;
                else
                    idCommensal = user.Id;
                Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   GeneralRes.Commensal + idCommensal, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (GetAccountEmailCommandException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new FondaAuthLoginAttributeException(GeneralRes.ValidateAccountEmailException, e);
            }
            catch (Exception e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new FondaAuthLoginAttributeException(GeneralRes.ValidateAccountEmailException, e);
            }
            //Logger al Culminar el metodo
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, idCommensal.ToString(),
                 System.Reflection.MethodBase.GetCurrentMethod().Name);
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                GeneralRes.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            // Se retorna el resultado
			return idCommensal;
		}
	}
}

