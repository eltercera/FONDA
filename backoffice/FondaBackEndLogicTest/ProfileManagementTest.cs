using NUnit.Framework;
using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;

using com.ds201625.fonda.Domain;
using com.ds201625.fonda.BackEndLogic;

namespace FondaBackEndLogicTest
{
	[TestFixture]
	public class ProfileManagementTest
	{
		
		[Test]
		public void CreateProfileCommandTest()
		{

			Commensal comm = generateCommensal ();
			Profile prof = generateProfile ();

			ICommand cmd = BackendFactoryCommand.Instance.CreateCreateProfileCommand ();

			cmd.SetParameter (0, comm);
			cmd.SetParameter (1, prof);

			cmd.Run ();

			prof = (Profile) cmd.Result;

			Assert.AreNotEqual (0, prof.Id);

			FactoryDAO.Intance.GetCommensalDAO ().Delete (comm);
		}

		[Test]
		// TODO: Exception Personalizada
		[ExpectedException(typeof(Exception))]
		public void CreateProfileCommandBadParameter0Test()
		{

			ICommand cmd = BackendFactoryCommand.Instance.CreateCreateProfileCommand ();

			cmd.SetParameter (0, "hola");
		}

		[Test]
		// TODO: Exception Personalizada
		[ExpectedException(typeof(Exception))]
		public void CreateProfileCommandBadParameter1Test()
		{

			ICommand cmd = BackendFactoryCommand.Instance.CreateCreateProfileCommand ();

			cmd.SetParameter (1, "hola");
		}

		[Test]
		// TODO: Exception Personalizada
		[ExpectedException(typeof(Exception))]
		public void CreateProfileCommandIncompletePaametersTest()
		{

			ICommand cmd = BackendFactoryCommand.Instance.CreateCreateProfileCommand ();

			cmd.Run ();
		}


		private Commensal generateCommensal()
		{
			Commensal commensal = new Commensal ();
			Random rand = new Random ();
			commensal.Email = rand.Next (100, 1000) + "eltercera@eltercera.com";
			commensal.Password = rand.Next (30000, 32000) + "-" + rand.Next (30000, 32000);
			commensal.Status = FactoryDAO.Intance.GetActiveSimpleStatus ();
			return commensal;
		}

		private Profile generateProfile()
		{
			Profile profile = new Profile ();
			Person person = new Person ();
			Random rand = new Random ();
			profile.ProfileName = "PruebaProfile";
			person.Address = "TestAddress";
			person.LastName = "LastnameTest";
			person.PhoneNumber = "451-451455";
			person.Ssn = rand.Next (100, 1000).ToString();
			person.Name = "asdasdasd";
			profile.Person = person;
			return profile;
		}
	}
}

