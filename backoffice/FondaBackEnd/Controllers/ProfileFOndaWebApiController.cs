using System;
using System.Web.Http;
using System.Collections.Generic;
using System.Collections;
using com.ds201625.fonda.Domain;

namespace com.ds201625.fonda.BackEnd.Controllers
{
	[RoutePrefix("api/profiles")]
	public class ProfileFOndaWebApiController : FondaWebApi
	{
		public ProfileFOndaWebApiController () : base () {}

		[Route]
		[HttpGet]
		public IList<Profile> getProfiles()
		{
			Console.WriteLine ("asdasdasdaaaaaaa");

			Profile pro;
			Person per;
			List<Profile> profiles = new List<Profile> ();

			per = new Person ();
			per.Name = "Romulo";
			per.LastName = "Rodriguez";
			per.Gender = 'M';
			per.BirthDate = DateTime.Now;
			per.Address = "asdasdasdasd";
			per.Ssn = "16135413";
			per.PhoneNumber = "5565135";

			pro = new Profile ();
			pro.ProfileName = "Primer nombre";
			pro.Person = per;

			profiles.Add (pro);

			per = new Person ();
			per.Name = "Jose";
			per.LastName = "Rojas";
			per.Gender = 'M';
			per.BirthDate = DateTime.Now;
			per.Address = "asdasdasdasd";
			per.Ssn = "16135413";
			per.PhoneNumber = "5565135";

			pro = new Profile ();
			pro.ProfileName = "Segundo nombre";
			pro.Person = per;

			profiles.Add (pro);

			return profiles;
		}

	}
}

