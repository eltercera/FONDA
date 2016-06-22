using NUnit.Framework;
using System;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.BackEndLogic;
using System.Collections.Generic;
using com.ds201625.fonda.BackEndLogic.Exceptions;
using com.ds201625.fonda.Factory;

namespace FondaBackEndLogicTest
{
    /// <summary>
    /// class  DeleteFavoriteRestaurantManagementTest
    /// Clase que realiza las pruebas unitarias del comando borrar Restaurant favorito.
    /// </summary>
	[TestFixture]
	public class DeleteFavoriteRestaurantManagementTest
	{
        private Restaurant restaurant;
        private Commensal commensal;
        private ICommand deleteFavorite;

        /// <summary>
        /// metodo que instancia e inicializa el objeto y variables respectivamente.
        /// </summary>
        [SetUp]
        protected void Init()
        {
            commensal = EntityFactory.GetCommensal();
            commensal.Id = 1;
            restaurant = EntityFactory.GetRestaurant();
            restaurant.Id = 1;
            deleteFavorite = BackendFactoryCommand.Instance.DeleteFavoriteRestaurantCommand();
        }

        /// <summary>
        /// metodo que se encarga de limpiar el objeto.
        /// </summary>
        [TearDown]
        protected void Clean()
        {
            commensal = null;
            restaurant = null;
        }

        /// <summary>
        /// prueba unitaria de borrar un restaurant favorito.
        /// </summary>
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

        /// <summary>
        /// prueba unitaria de excepcion de parametros invalidos
        /// </summary>
        [Test]
        [ExpectedException(typeof(InvalidTypeOfParameterException))]
        public void DeleteFavoriteRestaurantCommandBadParameter0Test()
        {
            deleteFavorite.SetParameter(0, "2");
        }

        /// <summary>
        /// prueba unitaria de excepcion de parametros invalidos
        /// </summary>
        [Test]
        [ExpectedException(typeof(InvalidTypeOfParameterException))]
        public void DeleteFavoriteRestaurantCommandBadParameter1Test()
        {
            deleteFavorite.SetParameter(1, "hola");
        }

        /// <summary>
        /// prueba unitaria de excepcion de parametros invalidos
        /// </summary>
        [Test]
        [ExpectedException(typeof(ParameterIndexOutOfRangeException))]
        public void DeleteFavoriteRestaurantCommandOfRangePaametersTest()
        {
            deleteFavorite.SetParameter(3, commensal);
            deleteFavorite.Run();
        }

        /// <summary>
        /// prueba unitaria de excepcion de parametros invalidos
        /// </summary>
        [Test]
        [ExpectedException(typeof(RequieredParameterNotFoundException))]
        public void DeleteFavoriteRestaurantCommandRequieredPaametersTest()
        {
            deleteFavorite.Run();
        }

	}
}

