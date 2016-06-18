using NUnit.Framework;
using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;

using com.ds201625.fonda.Domain;
using com.ds201625.fonda.BackEndLogic;
using System.Collections.Generic;
using com.ds201625.fonda.BackEndLogic.Exceptions;

namespace FondaBackEndLogicTest
{
	[TestFixture]
	public class GetAllRestaurantManagementTest
	{
        Commensal commensal;
        ICommand getRestaurant;
        IList<Restaurant> listRestaurant;

        [SetUp]
        public void Init()
        {
            commensal = new Commensal();
            commensal.Id = 1;
            getRestaurant = BackendFactoryCommand.Instance.GetAllRestaurantCommand();
        }

        [TearDown]
        public void Clean()
        {
            commensal = null;
        }

		[Test]
		public void GetAllRestaurantCommandTest()
		{
            getRestaurant.Run();
            listRestaurant = (IList<Restaurant>)getRestaurant.Result;
         
            Assert.NotNull(listRestaurant);
            Assert.NotNull(listRestaurant[3].RestaurantCategory);
            Assert.AreEqual("Burger Shack", listRestaurant[3].Name);
            Assert.AreEqual("Mexicana", listRestaurant[3].RestaurantCategory.Name);
		}

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetRestaurantCommandNullReferenceTest()
        {
            listRestaurant = (IList<Restaurant>)getRestaurant.Result;

            Assert.AreNotEqual("Burger Shack", listRestaurant[3].Name);
            Assert.IsNull(listRestaurant[1]);
        }

        [Test]
        [ExpectedException(typeof(ParameterIndexOutOfRangeException))]
        public void GetRestaurantsCommandOfRangeParametersTest()
        {
            getRestaurant.SetParameter(1, commensal);
            getRestaurant.Run();
        }
	}
}

