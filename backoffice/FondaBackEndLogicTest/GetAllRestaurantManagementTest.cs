using NUnit.Framework;
using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;

using com.ds201625.fonda.Domain;
using com.ds201625.fonda.BackEndLogic;
using System.Collections.Generic;

namespace FondaBackEndLogicTest
{
	[TestFixture]
	public class GetAllRestaurantManagementTest
	{
		
		[Test]
		public void GetAllRestaurantCommandTest()
		{

            IList<Restaurant> listRestaurant;
         
            ICommand cmd = BackendFactoryCommand.Instance.GetAllRestaurantCommand();

			cmd.Run();
            listRestaurant = (IList<Restaurant>)cmd.Result;

            Assert.NotNull(listRestaurant);
            Assert.NotNull(listRestaurant[3].RestaurantCategory);
            Assert.AreEqual("Burger Shack", listRestaurant[3].Name);
            Assert.AreEqual("Mexicana", listRestaurant[3].RestaurantCategory.Name);
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

