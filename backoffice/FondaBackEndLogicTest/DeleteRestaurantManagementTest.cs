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
	public class DeleteFavoriteRestaurantManagementTest
	{
        Restaurant restaurant;
        Commensal commensal;
        ICommand deleteFavorite;

        [SetUp]
        public void Init()
        {
            commensal = EntityFactory.GetCommensal();
            commensal.Id = 1;
            restaurant = EntityFactory.GetRestaurant();
            restaurant.Id = 1;
            deleteFavorite = BackendFactoryCommand.Instance.DeleteFavoriteRestaurantCommand();
        }

        [TearDown]
        public void Clean()
        {
            commensal = null;
            restaurant = null;
        }

    	[Test]
		public void DeleteFavoriteRestaurantCommandTest()
		{

			deleteFavorite.SetParameter(0, commensal);
            deleteFavorite.SetParameter(1, restaurant);
            deleteFavorite.Run();
            
            Commensal result = (Commensal)deleteFavorite.Result;
        	
            Assert.AreNotEqual(0, result.Id);
            Assert.AreEqual(commensal.Id, result.Id);
		}

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void DeleteteRestaurantCommandNullReferenceTest()
        {
            deleteFavorite.SetParameter(0, commensal);
            deleteFavorite.SetParameter(1, restaurant);
            Commensal result = (Commensal)deleteFavorite.Result;
            Assert.AreNotEqual(commensal.Id, result.Id);
            Assert.IsNull(result.Id);
        }

        [Test]
        [ExpectedException(typeof(InvalidTypeOfParameterException))]
        public void DeleteFavoriteRestaurantCommandBadParameter0Test()
        {
            deleteFavorite.SetParameter(0, "2");
        }

        [Test]
        [ExpectedException(typeof(InvalidTypeOfParameterException))]
        public void DeleteFavoriteRestaurantCommandBadParameter1Test()
        {
            deleteFavorite.SetParameter(1, "hola");
        }

        [Test]
        [ExpectedException(typeof(ParameterIndexOutOfRangeException))]
        public void DeleteFavoriteRestaurantCommandOfRangePaametersTest()
        {
            deleteFavorite.SetParameter(3, commensal);
            deleteFavorite.Run();
        }

        [Test]
        [ExpectedException(typeof(RequieredParameterNotFoundException))]
        public void DeleteFavoriteRestaurantCommandRequieredPaametersTest()
        {
            deleteFavorite.Run();
        }

	}
}

