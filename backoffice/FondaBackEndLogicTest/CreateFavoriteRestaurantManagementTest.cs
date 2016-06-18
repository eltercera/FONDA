using NUnit.Framework;
using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;

using com.ds201625.fonda.Domain;
using com.ds201625.fonda.BackEndLogic;
using System.Collections.Generic;
using com.ds201625.fonda.BackEndLogic.Exceptions;
using com.ds201625.fonda.DataAccess.Exceptions;

namespace FondaBackEndLogicTest
{
	[TestFixture]
	public class CreateFavoriteRestaurantManagementTest
	{
        Restaurant restaurant;
        Commensal commensal;
		
        [SetUp]
         public void Init()
        {

			commensal = new Commensal();
            commensal.Id = 1;
            restaurant = new Restaurant();
            restaurant.Id = 1;
			
		}

        [TearDown]
        public void Clean()
        {
        
            commensal = null;
            restaurant = null;

        }

		
		[Test]
		public void CreateFavoriteRestaurantCommandTest()
		{
            ICommand cmd = BackendFactoryCommand.Instance.CreateFavoriteRestaurantCommand();

			cmd.SetParameter(0,  commensal);
			cmd.SetParameter(1, restaurant);

			cmd.Run();

			Commensal result = (Commensal)cmd.Result;

			Assert.AreNotEqual(0, result.Id);
            Assert.AreEqual(commensal.Id, result.Id);
		}


		[Test]
        [ExpectedException(typeof(InvalidTypeOfParameterException))]
		public void CreateFavoriteRestaurantCommandBadParameter0Test()
		{
            ICommand cmd = BackendFactoryCommand.Instance.CreateFavoriteRestaurantCommand();
            cmd.SetParameter(0, 1);
		}

		[Test]
        [ExpectedException(typeof(InvalidTypeOfParameterException))]
		public void CreateFavoriteRestaurantCommandBadParameter1Test()
		{
            ICommand cmd = BackendFactoryCommand.Instance.CreateCreateProfileCommand ();
            cmd.SetParameter (1, "hola");
		}

		[Test]
        [ExpectedException(typeof(ParameterIndexOutOfRangeException))]
		public void CreateFavoriteRestaurantCommandOfRangePaametersTest()
		{
            ICommand cmd = BackendFactoryCommand.Instance.CreateFavoriteRestaurantCommand();
            cmd.SetParameter(3, "hola");
			cmd.Run ();
		}

        [Test]
        [ExpectedException(typeof(RequieredParameterNotFoundException))]
        public void CreateFavoriteRestaurantCommandRequieredPaametersTest()
        {
           ICommand cmd = BackendFactoryCommand.Instance.CreateFavoriteRestaurantCommand();
            cmd.Run();
        }


        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CreateFavoriteRestaurantCommandNullReferenceTest()
        {
            ICommand cmd = BackendFactoryCommand.Instance.CreateFavoriteRestaurantCommand();
            cmd.SetParameter(0, null);
            cmd.SetParameter(1, restaurant);
            cmd.Run();
            Commensal result = (Commensal)cmd.Result;
            
            Assert.IsNull(result);
        }

	}
}

