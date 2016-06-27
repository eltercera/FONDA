using com.ds201625.fonda.BackEndLogic.Exceptions;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Logic.FondaLogic;
using com.ds201625.fonda.Logic.FondaLogic.Factory;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.Restaurant;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using com.ds201625.fonda.Resources.FondaResources.Restaurant;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FondaBackOfficeLogicTest.Restaurante
{
    class BOCommandRestaurantTest
    {
        private FactoryDAO _facDAO;
        private IRestaurantDAO _restaurantDAO;
        private Restaurant _restaurant;
        private Restaurant _restaurantE;
        private Object[] _addlist = new Object[13];
        private Object[] _modifylist = new Object[2];
        private Command _commandGenerateRestaurant;
        private Command _commandModifyRestaurant;
        private Command _commandSaveRestaurant;
        private Command _commandGetRestaurants;
        private Command _commandGetAllCategories;
        private Command _commandGetAllCurrencies;
        private Command _commandGetAllZones;
        private IList<RestaurantCategory> listCategories;
        private IList<Currency> listCurrencies;
        private IList<Zone> listZones;
        private IList<Restaurant> listRestaurants;

        #region Variables restaurante
        int idRestaurant;
        string name;
        string logo;
        char nationality;
        string rif;
        string address;
        string category;
        string currency;
        string zone;
        double _long;
        double _lat;
        TimeSpan openingTime;
        TimeSpan closingTime;
        bool[] days;
        #endregion

        [SetUp]
        public void init()
        {
            _facDAO = FactoryDAO.Intance;
            _restaurantDAO = _facDAO.GetRestaurantDAO();
            _restaurant = new Restaurant();
            idRestaurant = 3;
            name = "Salon Canton";
            logo = "C:/";
            nationality = 'V';
            rif = "326598";
            address = "Av. Paez";
            category = "China";
            currency = "Bolivar Fuerte";
            zone = "Montalban";
            _long = 10.6;
            _lat = 18.9;
            openingTime = TimeSpan.Parse("11:00:00");
            closingTime = TimeSpan.Parse("22:00:00");
            days = new bool[] { true, true, true, true, true, true, true };
        }

        [TearDown]
        public void clean()
        {
            _facDAO = null;
        }

        #region Commands Test

        [Test(Description = "Genera un objeto restaurante")]
        public void commandGenerateRestaurantTest()
        {            
            _addlist[0] = name;
            _addlist[1] = logo;
            _addlist[2] = nationality;
            _addlist[3] = rif;
            _addlist[4] = address;
            _addlist[5] = category;
            _addlist[6] = currency;
            _addlist[7] = zone;
            _addlist[8] = _long;
            _addlist[9] = _lat;
            _addlist[10] = openingTime;
            _addlist[11] = closingTime;
            _addlist[12] = days;

            _commandGenerateRestaurant = CommandFactory.GetCommandGenerateRestaurant(_addlist);
            _commandGenerateRestaurant.Execute();
            _restaurant = (Restaurant)_commandGenerateRestaurant.Receiver;
            _restaurantE.Name = "Salon Canton";
            Assert.AreEqual(_restaurant.Name, _restaurantE.Name);
        }

        [Test(Description = "Modifica un objeto restaurante")]
        public void commandModifyRestaurantTest()
        {
            _addlist[0] = name;
            _addlist[1] = logo;
            _addlist[2] = nationality;
            _addlist[3] = rif;
            _addlist[4] = address;
            _addlist[5] = category;
            _addlist[6] = currency;
            _addlist[7] = zone;
            _addlist[8] = _long;
            _addlist[9] = _lat;
            _addlist[10] = openingTime;
            _addlist[11] = closingTime;
            _addlist[12] = days;
            
            _commandGenerateRestaurant = CommandFactory.GetCommandGenerateRestaurant(_addlist);
            _commandGenerateRestaurant.Execute();
            _restaurantE = (Restaurant)_commandGenerateRestaurant.Receiver;

            _modifylist[0] = _restaurantE;
            _modifylist[1] = idRestaurant;

            _commandModifyRestaurant = CommandFactory.GetCommandModifyRestaurant(_modifylist);
            _commandModifyRestaurant.Execute();
            _restaurant = (Restaurant)_commandModifyRestaurant.Receiver;
            Assert.AreEqual("Salon Canton", _restaurant.Name);

        }

        [Test(Description = "Guarda un objeto restaurante en la bd")]
        public void commandSaveRestaurantTest()
        {
            _restaurant = _restaurantDAO.FindById(2);

            _commandSaveRestaurant = CommandFactory.GetCommandSaveRestaurant(_restaurant);
            _commandSaveRestaurant.Execute();

            _restaurantE = _restaurantDAO.FindById(2);
            Assert.AreEqual(_restaurantE.Name, _restaurant.Name);
        }

        [Test(Description = "Devuelve todas las categorias")]
        public void commandGetAllCategories()
        {
            _commandGetAllCategories = CommandFactory.GetCommandGetAllCategories();
            _commandGetAllCategories.Execute();
            listCategories = (IList<RestaurantCategory>) _commandGetAllCategories.Receiver;

            Assert.NotNull(listCategories);
            Assert.AreEqual(listCategories[0].Name, "China");            
        }

        [Test(Description = "Devuelve todas las Monedas")]
        public void commandGetAllCurrencies()
        {
            _commandGetAllCurrencies = CommandFactory.GetCommandGetAllCurrencies();
            _commandGetAllCurrencies.Execute();
            listCurrencies = (IList<Currency>)_commandGetAllCurrencies.Receiver;

            Assert.NotNull(listCurrencies);
            Assert.AreEqual(listCurrencies[0].Name, "Dolar");
        }

        [Test(Description = "Devuelve todas las zonas")]
        public void commandGetAllZones()
        {
            _commandGetAllZones = CommandFactory.GetCommandGetAllZones();
            _commandGetAllZones.Execute();
            listZones = (IList<Zone>)_commandGetAllZones.Receiver;

            Assert.NotNull(listZones);
            Assert.AreEqual(listZones[0].Name, "Altamira");
        }

        [Test(Description = "Devuelve todas las restaurantes")]
        public void commandGetRestaurants()
        {
            _commandGetRestaurants = CommandFactory.GetCommandGetRestaurants("null");
            _commandGetRestaurants.Execute();
            listRestaurants = (IList<Restaurant>)_commandGetRestaurants.Receiver;

            Assert.NotNull(listRestaurants);
            Assert.AreEqual(listRestaurants[1].Name, "El Mundo del Pollo");
        }

        #endregion

        #region Exceptions Test

        [ExpectedException(typeof(NullReferenceException))]
        [Test]
        public void GenerateRestaurantNullExceptionTest()
        {
            _addlist[0] = name;
            _commandGenerateRestaurant = CommandFactory.GetCommandGenerateRestaurant(_addlist);
            _commandGenerateRestaurant.Execute();
        }
        [ExpectedException(typeof(InvalidCastException))]
        [Test]
        public void GenerateRestaurantInvalidExceptionTest()
        {
            _addlist[0] = 13546;
            _commandGenerateRestaurant = CommandFactory.GetCommandGenerateRestaurant(_addlist);
            _commandGenerateRestaurant.Execute();
        }


        [ExpectedException(typeof(NullReferenceException))]
        [Test]
        public void ModifyRestauranteNullExceptionTest()
        {
            _addlist[0] = name;

            _commandGenerateRestaurant = CommandFactory.GetCommandGenerateRestaurant(_addlist);
            _commandGenerateRestaurant.Execute();
            _restaurantE = (Restaurant)_commandGenerateRestaurant.Receiver;

            _modifylist[0] = _restaurantE;
            _modifylist[1] = idRestaurant;

            _commandModifyRestaurant = CommandFactory.GetCommandModifyRestaurant(_modifylist);
            _commandModifyRestaurant.Execute();
            _restaurant = (Restaurant)_commandModifyRestaurant.Receiver;
        }
        [ExpectedException(typeof(InvalidCastException))]
        [Test]
        public void ModifyRestauranteInvalidExceptionTest()
        {
            _addlist[0] = 1234548;

            _commandGenerateRestaurant = CommandFactory.GetCommandGenerateRestaurant(_addlist);
            _commandGenerateRestaurant.Execute();
            _restaurantE = (Restaurant)_commandGenerateRestaurant.Receiver;

            _modifylist[0] = _restaurantE;
            _modifylist[1] = idRestaurant;

            _commandModifyRestaurant = CommandFactory.GetCommandModifyRestaurant(_modifylist);
            _commandModifyRestaurant.Execute();
            _restaurant = (Restaurant)_commandModifyRestaurant.Receiver;
        }


        [ExpectedException(typeof(NullReferenceException))]
        [Test]
        public void commandGetAllCategoriesExceptionTest()
        {
            _commandGetAllCategories = CommandFactory.GetCommandGetAllCategories();
            _commandGetAllCategories.Execute();
            listCategories = (IList<RestaurantCategory>)_commandGetAllCategories.Receiver;

        }

        [ExpectedException(typeof(NullReferenceException))]
        [Test]
        public void commandGetAllCCurrenciesExceptionTest()
        {
            _commandGetAllCurrencies = CommandFactory.GetCommandGetAllCurrencies();
            _commandGetAllCurrencies.Execute();
            listCurrencies = (IList<Currency>)_commandGetAllCurrencies.Receiver;

        }

        [ExpectedException(typeof(NullReferenceException))]
        [Test]
        public void commandGetAllZonesExceptionTest()
        {
            _commandGetAllZones = CommandFactory.GetCommandGetAllZones();
            _commandGetAllZones.Execute();
            listZones = (IList<Zone>)_commandGetAllZones.Receiver;

        }

        [ExpectedException(typeof(NullReferenceException))]
        [Test]
        public void commandGetRestaurantsExceptionTest()
        {
            _commandGetRestaurants = CommandFactory.GetCommandGetRestaurants("null");
            _commandGetRestaurants.Execute();
            listRestaurants = (IList<Restaurant>)_commandGetRestaurants.Receiver;


        }

        #endregion

    }
}
