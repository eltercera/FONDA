using NUnit.Framework;
using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;

using com.ds201625.fonda.Domain;
using com.ds201625.fonda.BackEndLogic;
using System.Collections.Generic;
using com.ds201625.fonda.BackEndLogic.Exceptions;
using com.ds201625.fonda.Factory;

namespace FondaBackEndLogicTest
{
	[TestFixture]
	public class GetFavoriteRestaurantManagementTest
	{
        
        Commensal commensal;
        ICommand getFavoriteRestaurant;
        [SetUp]
        public void Init()
        {
            commensal = EntityFactory.GetCommensal();
            commensal.Id = 1;
            getFavoriteRestaurant = BackendFactoryCommand.Instance.GetFavoriteRestaurantCommand();
        }

        [TearDown]
        public void Clean()
        {
          commensal = null;
        }

		[Test]
		public void GetFavoriteRestaurantCommandTest()
		{
            getFavoriteRestaurant.SetParameter(0, commensal);

            getFavoriteRestaurant.Run();

            Commensal result = (Commensal)getFavoriteRestaurant.Result;

			Assert.AreNotEqual(0, result.Id);
            Assert.AreEqual(commensal.Id, result.Id);
		}

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetFavoriteeRestaurantCommandNullReferenceTest()
        {
            getFavoriteRestaurant.SetParameter(0, commensal);
            Commensal result = (Commensal)getFavoriteRestaurant.Result;
            Assert.AreNotEqual(commensal.Id, result.Id);
            Assert.IsNull(result.Id);
        }
        [Test]
        [ExpectedException(typeof(InvalidTypeOfParameterException))]
        public void GetFavoriteRestaurantCommandBadParameter0Test()
        {
            getFavoriteRestaurant.SetParameter(0, "2");
        }

        [Test]
        [ExpectedException(typeof(ParameterIndexOutOfRangeException))]
        public void DeleteFavoriteRestaurantCommandOfRangePaametersTest()
        {
            getFavoriteRestaurant.SetParameter(3, commensal);
            getFavoriteRestaurant.Run();
        }

        [Test]
        [ExpectedException(typeof(RequieredParameterNotFoundException))]
        public void DeleteFavoriteRestaurantCommandRequieredPaametersTest()
        {
           getFavoriteRestaurant.Run();
        }

	}
}

