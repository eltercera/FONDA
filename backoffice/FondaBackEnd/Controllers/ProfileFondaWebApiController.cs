using System;
using System.Web.Http;
using System.Linq;
using System.Collections;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.BackEnd.ActionFilters;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.DataAccess.Exceptions;

namespace com.ds201625.fonda.BackEnd.Controllers
{
	[RoutePrefix("api")]
	public class ProfileFondaWebApiController : FondaWebApi
	{
		public ProfileFondaWebApiController () : base () {}

		[Route("profiles")]
		[HttpGet]
		[FondaAuthToken]
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
        public IHttpActionResult postProfile(Profile profile)
        {
            Commensal commensal = GetCommensal(Request.Headers);
            if (commensal == null)
                return BadRequest();

            //IProfileDAO profileDAO = GetProfileDao();
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
            }

            return Created("", profile);
        }

        [Route("profile/{id}")]
        [HttpPut]
        [FondaAuthToken]
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
            oldProfile.ProfileName = profile.ProfileName;
            oldProfile.Person.Name = profile.Person.Name;
            oldProfile.Person.LastName = profile.Person.LastName;
            oldProfile.Person.PhoneNumber = profile.Person.PhoneNumber;
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

        private IProfileDAO GetProfileDao()
        {
            return FactoryDAO.GetProfileDAO();
        }
    }
}

