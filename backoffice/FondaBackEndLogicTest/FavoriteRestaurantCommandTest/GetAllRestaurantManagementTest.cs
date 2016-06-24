using NUnit.Framework;
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
        private Commensal commensal;
        private ICommand getRestaurant;
        private IList<Restaurant> listRestaurant;

        /// <summary>
        /// metodo que instancia e inicializa el objeto y variables respectivamente.
        /// </summary>
        [SetUp]
        protected void Init()
        {
            commensal = EntityFactory.GetCommensal();
            commensal.Id = 1;
            getRestaurant = BackendFactoryCommand.Instance.GetAllRestaurantCommand();
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

