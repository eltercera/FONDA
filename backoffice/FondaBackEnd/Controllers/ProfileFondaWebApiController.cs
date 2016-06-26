
﻿using System;
using System.Web.Http;
using System.Linq;
using System.Collections;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.BackEnd.ActionFilters;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.BackEndLogic;
using com.ds201625.fonda.BackEndLogic.Exceptions;
using com.ds201625.fonda.BackEnd.Log;
using com.ds201625.fonda.Factory;
using com.ds201625.fonda.BackEnd.Exceptions;
using System.Collections.Generic;


namespace com.ds201625.fonda.BackEnd.Controllers
{
	[RoutePrefix("api")]
	/// <summary>
	/// Profile fonda web API controller.
	/// </summary>
	public class ProfileFondaWebApiController : FondaWebApi
	{
        private Profile result;
        /// <summary>
        /// Constructor de ProfileFondaWebApiController
        /// </summary>
		public ProfileFondaWebApiController () : base () {}

		[Route("profiles")]
		[HttpGet]
		[FondaAuthToken]
		/// <summary>
		/// Obtiene los perfiles del commensal
		/// </summary>
		/// <returns>The profiles.</returns>
		public IHttpActionResult getProfiles()
		{
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   GeneralRes.BeginLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            IList<Profile> profiles;
            try
            {

                Commensal commensal = GetCommensal(Request.Headers);
                profiles = commensal.Profiles;
                Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   GeneralRes.Commensal + commensal.Id, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (GetCommensalFondaWebApiException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                GetProfilesFondaWebApiControllerException ex = new GetProfilesFondaWebApiControllerException(GeneralRes.GetProfilesException, e);
                return InternalServerError(ex);
            }
            catch (Exception e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                GetProfilesFondaWebApiControllerException ex = new GetProfilesFondaWebApiControllerException(GeneralRes.GetProfilesException, e);
                return InternalServerError(ex);
            }
            //Logger al Culminar el metodo
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, profiles.ToString(),
                 System.Reflection.MethodBase.GetCurrentMethod().Name);
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                GeneralRes.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            //retorna los perfiles
			return Ok(profiles);
		}

        [Route("profile")]
        [HttpPost]
        [FondaAuthToken]
		/// <summary>
		/// Posts the profile.
		/// </summary>
		/// <returns>The profile.</returns>
		/// <param name="profile">Profile.</param>
        public IHttpActionResult postProfile(Profile profile)
        {
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   GeneralRes.BeginLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                //Se obtiene el Commensal
                Commensal commensal = GetCommensal(Request.Headers);
                if (commensal == null)
                    return BadRequest();

                // Se obtiene el commando CreateCreateProfileCommand 
                ICommand command = FacCommand.GetCreateProfileCommand();

                // Se agrega el commensal como parametro
                command.SetParameter(0, commensal);
                // Se agrega el profile como parametro
                command.SetParameter(1, profile);

                //se ejecuta el comando
                command.Run();

                //Se obtiene la respuesta del Comando
                result = (Profile)command.Result;
                Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   GeneralRes.ProfileAdded + commensal.Id + GeneralRes.Slash + profile.ProfileName,
                   System.Reflection.MethodBase.GetCurrentMethod().Name);
                
            }
            catch (CreateProfileCommandException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                PostProfileFondaWebApiControllerException ex = new PostProfileFondaWebApiControllerException(GeneralRes.AddProfileException, e);
                return InternalServerError(ex);
            }
            catch (GetCommensalFondaWebApiException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                PostProfileFondaWebApiControllerException ex = new PostProfileFondaWebApiControllerException(GeneralRes.AddProfileException, e);
                return InternalServerError(ex);
            }
            catch (Exception e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                PostProfileFondaWebApiControllerException ex = new PostProfileFondaWebApiControllerException(GeneralRes.AddProfileException, e);
                return InternalServerError(ex);
            }
            //Logger al Culminar el metodo
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, result.ToString(),
                 System.Reflection.MethodBase.GetCurrentMethod().Name);
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                GeneralRes.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            // Se retorna el resultado
            return Created("", result);
        }

        [Route("profile/{id}")]
        [HttpPut]
        [FondaAuthToken]
		/// <summary>
		/// Puts the profile.
		/// </summary>
		/// <returns>The profile.</returns>
		/// <param name="profile">Profile.</param>
		/// <param name="id">Identifier.</param>
        public IHttpActionResult putProfile(Profile profile, int id)
        {
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   GeneralRes.BeginLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                //Se obtiene el Commensal
                Commensal commensal = GetCommensal(Request.Headers);
                if (commensal == null)
                    return BadRequest();
                //Se obtiene el Profile
                Profile oldProfile = GetProfile(id);

                if (!commensal.Profiles.Contains(oldProfile))
                    return BadRequest();

                // Se obtiene el commando CreateCreateProfileCommand 
                ICommand command = FacCommand.UpdateProfileCommand();

                // Se agrega el commensal como parametro
                command.SetParameter(0, commensal);
                // Se agrega el profile original como parametro
                command.SetParameter(1, oldProfile);
                // Se agrega el profile a modificar como parametro
                command.SetParameter(2, profile);
                //se ejecuta el comando
                command.Run();

                //Se obtiene la respuesta del Comando
                result = (Profile)command.Result;

                Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   GeneralRes.ProfileUpdated + commensal.Id + GeneralRes.Slash + profile.ProfileName,
                   System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (UpdateProfileCommandException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                PutProfileFondaWebApiControllerException ex = new PutProfileFondaWebApiControllerException(GeneralRes.UpdateProfileException, e);
                return InternalServerError(ex);
            }
            catch (Exception e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                PutProfileFondaWebApiControllerException ex = new PutProfileFondaWebApiControllerException(GeneralRes.UpdateProfileException, e);
                return InternalServerError(ex);
            }

            //Logger al Culminar el metodo
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, result.ToString(),
                 System.Reflection.MethodBase.GetCurrentMethod().Name);
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                GeneralRes.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return Created("", result);
        }

        [Route("profile/{id}")]
        [HttpDelete]
        [FondaAuthToken]
		/// <summary>
		/// Deletes the profile.
		/// </summary>
		/// <returns>The profile.</returns>
		/// <param name="id">Identifier.</param>
        public IHttpActionResult deleteProfile(int id)
        {
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   GeneralRes.BeginLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                Commensal commensal = GetCommensal(Request.Headers);
                if (commensal == null)
                    return BadRequest();

                //Se obtiene el Profile
                Profile profile = GetProfile(id);

                if (!commensal.Profiles.Contains(profile))
                    return BadRequest();

                // Se obtiene el commando CreateCreateProfileCommand 
                ICommand command = FacCommand.DeleteProfileCommand();

                // Se agrega el commensal como parametro
                command.SetParameter(0, commensal);
                // Se agrega el profile a eliminar como parametro
                command.SetParameter(1, profile);

                //se ejecuta el comando
                command.Run();
                Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                  GeneralRes.ProfileDeleted + commensal.Id + GeneralRes.Slash + profile.ProfileName,
                  System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (DeleteProfileCommandException e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                DeleteProfileFondaWebApiControllerException ex = new DeleteProfileFondaWebApiControllerException(GeneralRes.DeleteProfileException, e);
                return InternalServerError(ex);
            }
            catch (Exception e)
            {
                Loggers.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                DeleteProfileFondaWebApiControllerException ex = new DeleteProfileFondaWebApiControllerException(GeneralRes.DeleteProfileException, e);
                return InternalServerError(ex);
            }

            //Logger al Culminar el metodo
            Loggers.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                GeneralRes.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            return Ok(id);
        }

    }
}

