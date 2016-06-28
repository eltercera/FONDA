using NUnit.Framework;
using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;

using com.ds201625.fonda.Domain;
using com.ds201625.fonda.BackEndLogic;
using com.ds201625.fonda.BackEndLogic.Exceptions;

namespace FondaBackEndLogicTest
{
    [TestFixture]
    class RestaurantsSearchCommandTest
    {

        #region CreateGetZonesCommandTests
        [Test]
		[ExpectedException(typeof(InvalidTypeOfParameterException))]
		public void GetZonesCommandBadParameter0Test()
        {
            ICommand cmd = BackendFactoryCommand.Instance.CreateGetZonesCommand();
            cmd.SetParameter(0, 2);
        }

        [Test]
        [ExpectedException(typeof(InvalidTypeOfParameterException))]
        public void GetZonesCommandBadParameter1Test()
        {
            ICommand cmd = BackendFactoryCommand.Instance.CreateGetZonesCommand();
            cmd.SetParameter(1, "hola");
        }

        [Test]
        [ExpectedException(typeof(InvalidTypeOfParameterException))]
        public void GetZonesCommandBadParameter2Test()
        {
            ICommand cmd = BackendFactoryCommand.Instance.CreateGetZonesCommand();
            cmd.SetParameter(2, "hola");
        }

        [Test]
        public void GetZonesCommandTest()
        {
            ICommand cmd = BackendFactoryCommand.Instance.CreateGetZonesCommand();

            cmd.SetParameter(0, "a");
            cmd.SetParameter(1, 2);
            cmd.SetParameter(2, 2);

            cmd.Run();

            Assert.IsNotNull(cmd.Result);
        }
        #endregion


        #region GetRestaurantsCategoriesCommandTests
        [Test]
        [ExpectedException(typeof(InvalidTypeOfParameterException))]
        public void GetRestaurantsCategoriesCommandBadParameter0Test()
        {
            ICommand cmd = BackendFactoryCommand.Instance.CreateGetRestaurantsCategoriesCommand();
            cmd.SetParameter(0, 2);
        }

        [Test]
        [ExpectedException(typeof(InvalidTypeOfParameterException))]
        public void GetRestaurantsCategoriesCommandBadParameter1Test()
        {
            ICommand cmd = BackendFactoryCommand.Instance.CreateGetRestaurantsCategoriesCommand();
            cmd.SetParameter(1, "hola");
        }

        [Test]
        [ExpectedException(typeof(InvalidTypeOfParameterException))]
        public void GetRestaurantsCategoriesCommandBadParameter2Test()
        {
            ICommand cmd = BackendFactoryCommand.Instance.CreateGetRestaurantsCategoriesCommand();
            cmd.SetParameter(2, "hola");
        }

        [Test]
        public void GetRestaurantsCategoriesCommandTest()
        {
            ICommand cmd = BackendFactoryCommand.Instance.CreateGetRestaurantsCategoriesCommand();

            cmd.SetParameter(0, "a");
            cmd.SetParameter(1, 2);
            cmd.SetParameter(2, 2);

            cmd.Run();

            Assert.IsNotNull(cmd.Result);
        }
        #endregion

        #region GetRestaurantsCommand
        [Test]
        [ExpectedException(typeof(InvalidTypeOfParameterException))]
        public void GetRestaurantsCommandBadParameter0Test()
        {
            ICommand cmd = BackendFactoryCommand.Instance.CreateGetRestaurantsCommand();
            cmd.SetParameter(0, 2);
        }

        [Test]
        [ExpectedException(typeof(InvalidTypeOfParameterException))]
        public void GetRestaurantsCommandBadParameter1Test()
        {
            ICommand cmd = BackendFactoryCommand.Instance.CreateGetRestaurantsCommand();
            cmd.SetParameter(1, "hola");
        }

        [Test]
        [ExpectedException(typeof(InvalidTypeOfParameterException))]
        public void GetRestaurantsCommandBadParameter2Test()
        {
            ICommand cmd = BackendFactoryCommand.Instance.CreateGetRestaurantsCommand();
            cmd.SetParameter(2, "hola");
        }

        [Test]
        [ExpectedException(typeof(InvalidTypeOfParameterException))]
        public void GetRestaurantsCommandBadParameter3Test()
        {
            ICommand cmd = BackendFactoryCommand.Instance.CreateGetRestaurantsCommand();
            cmd.SetParameter(3, "hola");
        }

        [Test]
        [ExpectedException(typeof(InvalidTypeOfParameterException))]
        public void GetRestaurantsCategoriesCommandBadParameter4Test()
        {
            ICommand cmd = BackendFactoryCommand.Instance.CreateGetRestaurantsCommand();
            cmd.SetParameter(4, "hola");
        }

        [Test]
        public void GetRestaurantsCommandTest()
        {
            ICommand cmd = BackendFactoryCommand.Instance.CreateGetRestaurantsCommand();

            cmd.SetParameter(0, "a");
            cmd.SetParameter(1, 2);
            cmd.SetParameter(2, 2);
            cmd.SetParameter(3, 2);
            cmd.SetParameter(4, 2);

            cmd.Run();

            Assert.IsNotNull(cmd.Result);
        }
        #endregion

    }
}
