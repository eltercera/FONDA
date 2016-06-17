using NUnit.Framework;
using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;

using com.ds201625.fonda.Domain;
using com.ds201625.fonda.BackEndLogic;
using System.Collections.Generic;

namespace FondaBackEndLogicTest
{
	[TestFixture]
	public class GetFavoriteRestaurantManagementTest
	{
		
		[Test]
		public void GetFavoriteRestaurantCommandTest()
		{

			Commensal comm = generateCommensal();

            ICommand cmd = BackendFactoryCommand.Instance.GetFavoriteRestaurantCommand();

			cmd.SetParameter(0, comm);

			cmd.Run();

			Commensal result = (Commensal)cmd.Result;

			Assert.AreNotEqual(0, result.Id);
            Assert.AreEqual(comm.Id, result.Id);
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
			Commensal commensal = new Commensal();
            commensal.Id = 1;
			return commensal;
		}

	}
}

