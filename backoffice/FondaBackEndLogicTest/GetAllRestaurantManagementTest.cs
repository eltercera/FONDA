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
    /// class  GetAllRestaurantManagementTest
    /// Clase que realiza las pruebas unitarias del comando obtener restaurantes disponibles.
    /// </summary>
	[TestFixture]
	public class GetAllRestaurantManagementTest
	{
        Commensal commensal;
        ICommand getRestaurant;
        IList<Restaurant> listRestaurant;


        /// <summary>
        /// metodo que instancia e inicializa el objeto y variables respectivamente.
        /// </summary>
        [SetUp]
        public void Init()
        {
            commensal = EntityFactory.GetCommensal();
            commensal.Id = 1;
            getRestaurant = BackendFactoryCommand.Instance.GetAllRestaurantCommand();
        }

        /// <summary>
        /// metodo que se encarga de limpiar el objeto.
        /// </summary>
        [TearDown]
        public void Clean()
        {
            commensal = null;
        }

        /// <summary>
        /// prueba unitaria de obtener restaurantes disponibles.
        /// </summary>
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


        /// <summary>
        /// prueba unitaria de comando con referencia nula
        /// </summary>
        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetRestaurantCommandNullReferenceTest()
        {
            listRestaurant = (IList<Restaurant>)getRestaurant.Result;

            Assert.AreNotEqual("Burger Shack", listRestaurant[3].Name);
            Assert.IsNull(listRestaurant[1]);
        }

        /// <summary>
        /// prueba unitaria de excepcion de parametros invalidos
        /// </summary>
        [Test]
        [ExpectedException(typeof(ParameterIndexOutOfRangeException))]
        public void GetRestaurantsCommandOfRangeParametersTest()
        {
            getRestaurant.SetParameter(1, commensal);
            getRestaurant.Run();
        }
	}
}

