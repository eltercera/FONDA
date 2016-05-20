using NUnit.Framework;
using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System.Collections.Generic;

namespace DataAccess
{
//    [TestFixture()]
//    class FOAddRestaurantFavorite : BaseEntity
//    {

//        private FactoryDAO _facDAO;
//        private ICommensalDAO _commensalDAO;
//        private IRestaurantDAO _restaurantDAO;
//        private Commensal _commensal;
//        private Restaurant _restaurant1;
//        private Restaurant _restaurant2; 
    

//        private void getCommensalDao()
//        {
//            getDao();
//            if (_commensalDAO == null)
//                _commensalDAO = _facDAO.GetCommensalDAO();

//        }

//        private void getRestaurantDao()
//        {
//            getDao();
//            if (_restaurantDAO == null)
//                _restaurantDAO = _facDAO.GetRestaurantDAO();

//        }
//        /// <summary>
//        /// VOID PARA INSTANCIAR LA FABRICA
//        /// </summary>
//        private void getDao()
//        {
//            if (_facDAO == null)
//                _facDAO = FactoryDAO.Intance;
//        }


       
//        private Commensal CreateCommensal()
//        {

//            if (_commensal == null)
//            {
//                _commensal = new Commensal()
//                {
//                    Email = "Commensal@gmail.com",
//                    Password = "12345",
//                    Status = ActiveSimpleStatus.Instance
//                };

                
//            }
            
//            return _commensal;
  
//        }
        
        
//        private Restaurant CreateRestaurant(Restaurant _restaurant)
//        {
            
//            if (_restaurant == null)
//            {
//                _restaurant = new Restaurant()
//                {
//                    Logo = "FondaLogo.jpg",
//                    Currency = new Currency
//                    {
//                        Name = "CurrencyName"
//                    },
//                    coordinate = new Coordinate
//                    {
//                        Latitude = 9.1234,
//                        Longitude = -80.2034
//                    },
//                    Name = "FondaRestaurant",
//                    Address = "Altamira",
//                    Ssn = "Ni idea",
//                    PhoneNumber = "02129415126",
//                    Zone = new Zone(),
//                    RestaurantCategory = new RestaurantCategory(),
//                    Schedule = new Schedule
//                    {
//                        OpeningTime = new TimeSpan(1, 2, 3, 4),
//                        ClosingTime = new TimeSpan(5, 6, 7, 8),
//                        Day = new List<Day>() { }

//                    },
//                    MenuCategories = new List<MenuCategory>(),
//                    Employees = new List<Employee>(),
//                    Tables = new List<Table>(),
//                    FavoritesCommensals = new List<Commensal>(),


//                };

//            }
            
//            return _restaurant;
//        }


//        [Test()]
//        public void TestEmply()
//        {
//            Assert.Null(_commensal);
//            Assert.Null(_restaurant1);

//            _commensal = CreateCommensal();
//            _restaurant1 = CreateRestaurant(_restaurant1);
            

//            Assert.NotNull(_commensal);
//            Assert.NotNull(_restaurant1);
//        }

//        [Test()]
//        public void TestObject()
//        {
//            Assert.AreEqual(_commensal.Email, "Commensal@gmail.com");
//            Assert.AreNotEqual(_commensal.Email, "Comensalgmail.com");
//            Assert.AreEqual(_restaurant1.coordinate.Latitude, 9.1234);
//            Assert.AreEqual(_restaurant1.coordinate.Longitude, -80.2034);
//            Assert.AreEqual(_restaurant2.Address, "Altamira");
//            Assert.AreEqual(_restaurant2.Currency.Name, "CurrencyName");


//        }
        
//        [Test()]
//        public void TestAdd()
//        {
//            getRestaurantDao();
//            getCommensalDao();

//            try
//            {
//                Restaurant _restaurantId1 = _restaurantDAO.FindById(1);
//                Restaurant _restaurantId2 = _restaurantDAO.FindById(2);
//            }
//            catch (Exception e)
//            {
//                e.Message();
//            }

            

//            Assert.NotNull(_restaurantId1);
//            Assert.NotNull(_restaurantId2);
//            Assert.AreNotSame(_restaurantId1,_restaurantId2);
            

//            Commensal _commensalId1 = (Commensal)_commensalDAO.FindById(1);
//            AddRestaurantToCommensal(_commensalId1, _restaurantId1, _restaurantId2);
//            _commensalDAO.Save(_commensalId1);

            
//        }

       
//        public static void AddRestaurantToCommensal
//            (Commensal _commensal, params Restaurant[] _restarants)
//        {
//            foreach (var restaurant in _restarants)
//            {
//                _commensal.AddFavoriteRestaurant(restaurant);
//            }
//        }


           













//        /*/// <summary>
//        /// FABRICA DE OBJETOS
//        /// </summary>
//        private FactoryDAO _facDAO;
//        /// <summary>
//        /// INTERFAZ DE COMMENSAL AL CUAL SE LE VAN AGREGAR RESTAURANTES
//        /// </summary>
//        private ICommensalDAO _commensalDAO;
//        /// <summary>
//        /// INTERFAZ DE LA RESTAURANTE A AGREGAR COMO FAVORTIO
//        /// </summary>
//        private IRestaurantDAO _restaurantDAO;
//        /// <summary>
//        /// RESTAURANTES A AGREGAR MANUALMENTE
//        /// </summary>
//        private Restaurant _restaurantId1;
//        private Restaurant _restaurantId2;
//        /// <summary>
//        /// Ids PARA FINDBYID
//        /// </summary>
//        private int Id1 = 1;
//        private int Id2 = 2;
//        /// <summary>
//        /// COMMENSAL CREADO MANUALMENTE
//        /// </summary>
//        private Commensal _commensalId1;
//        private Commensal _commensal = new Commensal
//        {

//            Password = "prueba",
//            //SesionToken = "prueba",
//            Email = "prueba",
//            Status = ActiveSimpleStatus.Instance
//        };
//        /// <summary>
//        /// RESTAURANTES CREADOS MANUALMENTES
//        /// </summary>
//        private Restaurant _restaurant = new Restaurant
//        {

//            Address = "prueba",
//            Name = "prueba",
//            Ssn = "prueba",
//            Logo = "prueba"
//        };

//        private Restaurant _restaurant2 = new Restaurant
//        {

//            Address = "prueba",
//            Name = "prueba",
//            Ssn = "prueba",
//            Logo = "prueba"
//        };

//        /// <summary>
//        /// VOID TEST QUE AGREGA RESTAURANT MANUALMENTE
//        /// </summary>
//        [Test()]
//        public void agregarRestaurant()
//        {

//            AddRestaurantToCommensal(_commensal, _restaurant, _restaurant2);
//            getCommensalDao();
//            _commensalDAO.Save(_commensal);
//        }
//        /// <summary>
//        /// VOID TEST QUE AGREGA RESTAURANTE COMO FAVORITO
//        /// CON EL ID DEL COMMENSAL Y LOS ID DE LOS RESTAURANTES
//        /// </summary>
//        [Test()]
//        public void addById()
//        {
//            getRestaurantDao();
//            getCommensalDao();
//            _restaurantId1 = _restaurantDAO.FindById(1);
//            _restaurantId2 = _restaurantDAO.FindById(2);
//            //findbyid para traerse objeto de commensal
//            _commensalId1 = (Commensal)_commensalDAO.FindById(5);
//            AddRestaurantToCommensal(_commensalId1, _restaurantId1, _restaurantId2);
//            _commensalDAO.Save(_commensalId1);
//        }
//        /// <summary>
//        /// VOID TEST QUE ELIMINA RESTAURANTE COMO FAVORITO
//        /// CON EL ID DEL COMMENSAL Y LOS ID DE LOS RESTAURANTES
//        /// </summary>
//        [Test()]
//        public void deleteById()
//        {
//            getRestaurantDao();
//            getCommensalDao();
//            _restaurantId1 = _restaurantDAO.FindById(1);
//            _restaurantId2 = _restaurantDAO.FindById(2);
//            //findbyid para traerse objeto de commensal
//            _commensalId1 = (Commensal)_commensalDAO.FindById(6);
//            RemoveRestaurantToCommensal(_commensalId1, _restaurantId1, _restaurantId2);
//            _commensalDAO.Save(_commensalId1);
//        }
//        /// <summary>
//        /// VOID QUE AGREGA RESTAURANTE A LA LISTA DEL OBJETO COMMENSAL
//        /// </summary>
//        /// <param name="commensal"></param>
//        /// OBJETO DE COMMENSAL AL QUE SE LE AGREGARAN RESTAURANTES
//        /// <param name="restarants"></param>
//        /// ARREGLO DE RESTAURANTE A AGREGAR COMO FAVORITOS
//        public static void AddRestaurantToCommensal
//            (Commensal commensal, params Restaurant[] restarants)
//        {
//            foreach (var restaurant in restarants)
//            {
//                commensal.AddFavoriteRestaurant(restaurant);
//            }
//        }
//        /// <summary>
//        /// VOID QUE ELIMINA RESTAURANTE A LA LISTA DEL OBJETO COMMENSAL
//        /// </summary>
//        /// <param name="commensal"></param>
//        /// OBJETO DE COMMENSAL AL QUE SE LE ELIMINARAN RESTAURANTES
//        /// <param name="restarants"></param>
//        /// ARREGLO DE RESTAURANTE A ELIMINARAN COMO FAVORITOS
//        public static void RemoveRestaurantToCommensal
//            (Commensal commensal, params Restaurant[] restarants)
//        {
//            foreach (var restaurant in restarants)
//            {
//                commensal.RemoveFavoriteRestaurant(restaurant);
//            }
//        }

//        private void getCommensalDao()
//        {
//            getDao();
//            if (_commensalDAO == null)
//                _commensalDAO = _facDAO.GetCommensalDAO();

//        }

//        private void getRestaurantDao()
//        {
//            getDao();
//            if (_restaurantDAO == null)
//                _restaurantDAO = _facDAO.GetRestaurantDAO();

//        }
//        /// <summary>
//        /// VOID PARA INSTANCIAR LA FABRICA
//        /// </summary>
//        private void getDao()
//        {
//            if (_facDAO == null)
//                _facDAO = FactoryDAO.Intance;
//        }
//        */

//    }


}