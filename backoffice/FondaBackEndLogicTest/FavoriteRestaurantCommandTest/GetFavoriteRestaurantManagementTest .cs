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
    /// <summary>
    /// class  GetFavoriteRestaurantManagementTest
    /// Clase que realiza las pruebas unitarias del comando obtener restaurant favorito de un comensal.
    /// </summary>
	[TestFixture]
	public class GetFavoriteRestaurantManagementTest
	{

        private Commensal commensal;
        private ICommand getFavoriteRestaurant;

        /// <summary>
        /// metodo que instancia e inicializa el objeto y variables respectivamente.
        /// </summary>
        [SetUp]
        protected void Init()
        {
            commensal = EntityFactory.GetCommensal();
            commensal.Id = 1;
            getFavoriteRestaurant = BackendFactoryCommand.Instance.GetFavoriteRestaurantCommand();
        }

        /// <summary>
        /// metodo que se encarga de limpiar el objeto.
        /// </summary>
        [TearDown]
        protected void Clean()
        {
          commensal = null;
        }

        /// <summary>
        /// prueba unitaria de obtener un restaurant favorito.
        /// </summary>
		[Test]
		public void GetFavoriteRestaurantCommandTest()
		{
            getFavoriteRestaurant.SetParameter(0, commensal);

            getFavoriteRestaurant.Run();

            Commensal result = (Commensal)getFavoriteRestaurant.Result;

			Assert.AreNotEqual(0, result.Id);
            Assert.AreEqual(commensal.Id, result.Id);
		}

     
        /// <summary>
        /// prueba unitaria de excepcion de parametros invalidos
        /// </summary>
        [Test]
        [ExpectedException(typeof(InvalidTypeOfParameterException))]
        public void GetFavoriteRestaurantCommandBadParameter0Test()
        {
            getFavoriteRestaurant.SetParameter(0, "2");
        }

        /// <summary>
        /// prueba unitaria de excepcion de parametros invalidos
        /// </summary>
        [Test]
        [ExpectedException(typeof(ParameterIndexOutOfRangeException))]
        public void DeleteFavoriteRestaurantCommandOfRangePaametersTest()
        {
            getFavoriteRestaurant.SetParameter(3, commensal);
            getFavoriteRestaurant.Run();
        }

        /// <summary>
        /// prueba unitaria de excepcion de parametros invalidos
        /// </summary>
        [Test]
        [ExpectedException(typeof(RequieredParameterNotFoundException))]
        public void DeleteFavoriteRestaurantCommandRequieredPaametersTest()
        {
           getFavoriteRestaurant.Run();
        }

	}
}

