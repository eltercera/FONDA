using System;
using com.ds201625.fonda.Domain;
using System.Net;
using System.Web.Http;
using com.ds201625.fonda.BackEnd.Log;
using com.ds201625.fonda.BackEndLogic;
using com.ds201625.fonda.BackEnd.Exceptions;
using com.ds201625.fonda.BackEndLogic.Exceptions;

namespace com.ds201625.fonda.BackEnd.Controllers
{
	[RoutePrefix("api")]
	/// <summary>
	/// Commensal web API controller.
	/// </summary>
	public class CommensalWebApiController : FondaWebApi
	{
        /// <summary>
        /// Constructor de la clase CommensalWebApiController
        /// </summary>
		public CommensalWebApiController () { }


		[HttpPost]
		[Route("commensal")]
		/// <summary>
		/// Posts de un commensal.
		/// </summary>
		/// <returns>El commensal.</returns>
		/// <param name="commensal">Commensal creado.</param>
		public IHttpActionResult PostCommensal(Commensal commensal)
		{
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   GeneralRes.BeginLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
			if (commensal == null | commensal.Id != 0)
				throw new HttpResponseException (HttpStatusCode.BadRequest);

			try
			{
                // Se obtiene el commando CreateCreateProfileCommand 
                ICommand command = FacCommand.GetCreateCommensalCommand();

                // Se agrega el commensal como parametro
                command.SetParameter(0, commensal);

                //se ejecuta el comando
                command.Run();
                //Se obtiene la respuesta del Comando
                commensal = (Commensal)command.Result;
                Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   GeneralRes.Commensal + commensal.Id, System.Reflection.MethodBase.GetCurrentMethod().Name);
			}
            catch (CreateCommensalCommandException e)
			{
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new AddCommensalWebApiControllerException(GeneralRes.AddCommensal, e);
            }
            catch (Exception e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new AddCommensalWebApiControllerException(GeneralRes.AddCommensal, e);
            }
            //Logger al Culminar el metodo
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, commensal.ToString(),
                 System.Reflection.MethodBase.GetCurrentMethod().Name);
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                GeneralRes.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

			return Created ("",commensal);
		}

	}
}

