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
    /// class  CreateFavoriteRestaurantManagementTest
    /// Clase que realiza las pruebas unitarias del comando Crear Restaurant favorito.
    /// </summary>
	[TestFixture]
	public class CreateFavoriteRestaurantManagementTest   
    {
        private  Restaurant restaurant;
        private  Commensal commensal;
        private  ICommand createFavorite;

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
            createFavorite = BackendFactoryCommand.Instance.CreateFavoriteRestaurantCommand();
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
        /// prueba unitaria de crear un restaurant favorito 
        /// </summary>
		[Test]
		public void CreateFavoriteRestaurantCommandTest()
		{

            createFavorite.SetParameter(0, commensal);
            createFavorite.SetParameter(1, restaurant);
            createFavorite.Run();

            Commensal result = (Commensal)createFavorite.Result;

			Assert.AreNotEqual(0, result.Id);
            Assert.AreEqual(commensal.Id, result.Id);
		}


        /// <summary>
        /// prueba unitaria de excepcion de parametros invalidos
        /// </summary>
		[Test]
        [ExpectedException(typeof(InvalidTypeOfParameterException))]
		public void CreateFavoriteRestaurantCommandBadParameter0Test()
		{
             createFavorite.SetParameter(0, "2");
		}

        /// <summary>
        /// prueba unitaria de excepcion de parametros invalidos
        /// </summary>
		[Test]
        [ExpectedException(typeof(InvalidTypeOfParameterException))]
		public void CreateFavoriteRestaurantCommandBadParameter1Test()
		{
             createFavorite.SetParameter(1, "hola");
		}

        /// <summary>
        /// prueba unitaria de excepcion de parametros invalidos
        /// </summary>
		[Test]
        [ExpectedException(typeof(ParameterIndexOutOfRangeException))]
		public void CreateFavoriteRestaurantCommandOfRangeParametersTest()
		{
            createFavorite.SetParameter(3, "hola");
            createFavorite.Run();
		}

        /// <summary>
        /// prueba unitaria de excepcion de parametros invalidos
        /// </summary>
        [Test]
        [ExpectedException(typeof(RequieredParameterNotFoundException))]
        public void CreateFavoriteRestaurantCommandRequieredParametersTest()
        {
            createFavorite.Run();
        }

	}
}

