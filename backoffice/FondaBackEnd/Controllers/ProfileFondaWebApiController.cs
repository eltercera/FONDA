using System;
using System.Web.Http;
using System.Linq;
using System.Collections;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.BackEnd.ActionFilters;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.DataAccess.Exceptions;

using com.ds201625.fonda.BackEndLogic;


namespace com.ds201625.fonda.BackEnd.Controllers
{
	[RoutePrefix("api")]
	/// <summary>
	/// Profile fonda web API controller.
	/// </summary>
	public class ProfileFondaWebApiController : FondaWebApi
	{
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
			Commensal commensal = GetCommensal (Request.Headers);
			if (commensal == null)
				return BadRequest ();

			return Ok(commensal.Profiles);
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
            Commensal commensal = GetCommensal(Request.Headers);
            if (commensal == null)
                return BadRequest();

            /*//IProfileDAO profileDAO = GetProfileDao();
            ICommensalDAO commensalDAO = FactoryDAO.GetCommensalDAO();

            if (profile.ProfileName == null || profile.Person == null || profile.Person.Name == null
                || profile.Person.LastName == null || profile.Person.Ssn == null)
                return BadRequest();

            profile.Status = FactoryDAO.GetActiveSimpleStatus();
            profile.Person.Status = FactoryDAO.GetActiveSimpleStatus();
            commensal.Profiles.Add(profile);
            profile.Person.Gender = ' ';
            profile.Person.BirthDate = DateTime.Now;

            try
            {
                commensalDAO.Save(commensal);
            }
            catch (SaveEntityFondaDAOException e)
            {
                Console.WriteLine(e.ToString());
                return InternalServerError(e);
            }*/

			// TODO: Uso de Excepciones personalizadas.

			// Obtención del commando
			ICommand command = FacCommand.CreateCreateProfileCommand ();

			// Agregacion de parametros
			command.SetParameter (0, commensal);
			command.SetParameter (1, profile);

			// Ejecucion del commando
			command.Run ();

			//obtención de respuesta
			Profile result = (Profile) command.Result;

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
            Commensal commensal = GetCommensal(Request.Headers);
            if (commensal == null)
                return BadRequest();

            ICommensalDAO commensalDAO = FactoryDAO.GetCommensalDAO();

            if (profile.ProfileName == null || profile.Person == null || profile.Person.Name == null
                || profile.Person.LastName == null || profile.Person.Ssn == null)
                return BadRequest();

            Profile oldProfile = GetProfileDao().FindById(id);
            if (!commensal.Profiles.Contains(oldProfile))
                return BadRequest();

            oldProfile.ProfileName = profile.ProfileName;
            oldProfile.Person.Name = profile.Person.Name;
            oldProfile.Person.LastName = profile.Person.LastName;
            oldProfile.Person.PhoneNumber = profile.Person.PhoneNumber;
            oldProfile.Person.Address = profile.Person.Address;
            oldProfile.Person.Ssn = profile.Person.Ssn;

            try
            {
                commensalDAO.Save(commensal);
            }
            catch (SaveEntityFondaDAOException e)
            {
                Console.WriteLine(e.ToString());
                return InternalServerError(e);
            }

            return Created("", oldProfile);
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
            Commensal commensal = GetCommensal(Request.Headers);
            if (commensal == null)
                return BadRequest();

            ICommensalDAO commensalDAO = FactoryDAO.GetCommensalDAO();

            Profile profile = GetProfileDao().FindById(id);
            if (!commensal.Profiles.Contains(profile))
                return BadRequest();

            commensal.Profiles.Remove(profile);
			profile.Status = FactoryDAO.GetDisabledSimpleStatus();

            try
            {
                commensalDAO.Save(commensal);
            }
            catch (SaveEntityFondaDAOException e)
            {
                Console.WriteLine(e.ToString());
                return InternalServerError(e);
            }

            return Ok();
        }

        //[Route("profiles")]
        //[HttpDelete]
        //[FondaAuthToken]
        //public IHttpActionResult deleteProfiles(Profile[] profiles)
        //{
        //    Commensal commensal = GetCommensal(Request.Headers);
        //    if (commensal == null)
        //        return BadRequest();

        //    ICommensalDAO commensalDAO = FactoryDAO.GetCommensalDAO();

        //    Profile profile = GetProfileDao().FindById(id);
        //    if (!commensal.Profiles.Contains(profile))
        //        return BadRequest();

        //    commensal.Profiles.Remove(profile);
        //    profile.Status = FactoryDAO.GetDisabledSimpleStatus();

        //    try
        //    {
        //        commensalDAO.Save(commensal);
        //    }
        //    catch (SaveEntityFondaDAOException e)
        //    {
        //        Console.WriteLine(e.ToString());
        //        return InternalServerError(e);
        //    }

        //    return Ok();
        //}

		/// <summary>
		/// Gets the profile DAO.
		/// </summary>
		/// <returns>The profile DAO.</returns>
        private IProfileDAO GetProfileDao()
        {
            return FactoryDAO.GetProfileDAO();
        }
    }
}

