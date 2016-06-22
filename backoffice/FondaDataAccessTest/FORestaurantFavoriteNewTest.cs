using NUnit.Framework;
using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System.Collections.Generic;
using com.ds201625.fonda.Factory;
using com.ds201625.fonda.Tests.DataAccess;
using com.ds201625.fonda.DataAccess.Exceptions;

namespace FondaDataAccessTest
{

    /// <summary>
    /// Clase de pruebas unitarias DAO
    /// </summary>
    [TestFixture()]
    class FORestaurantFavoriteNewTest : BaseEntity
    {

        private FactoryDAO _facDAO;
        private ICommensalDAO _commensalDAO;
        private IRestaurantDAO _restaurantDAO;
        private Restaurant _restaurant;
        private Commensal _commensal;
        private IList<Restaurant> _listRestaurant;

        [SetUp]
        /// <summary>
        /// Metodo que inicializa todas las variables
        /// </summary>
        public void Init() {
            getDao();
            getCommensalDao();
            getRestaurantDao();
            getRestaurant();
            getCommensal();
        }

        /// <summary>
		/// Instancia la Fabrica de DAO
		/// </summary>
		private void getDao()
        {
            if (_facDAO == null)
                _facDAO = FactoryDAO.Intance;
        }

        /// <summary>
        /// Obtiene el CommensalDao
        /// </summary>
		private void getCommensalDao()
        {
            if (_commensalDAO == null)
                _commensalDAO = _facDAO.GetCommensalDAO();

        }

        /// <summary>
        /// Obtiene el RestaurantDao
        /// </summary>
        private void getRestaurantDao()
        {
            if (_restaurantDAO == null)
                _restaurantDAO = _facDAO.GetRestaurantDAO();

        }

        /// <summary>
        /// Obtiene el Restaurant
        /// </summary>
        private void getRestaurant()
        {
            _restaurant = (Restaurant) _restaurantDAO.FindById(2);

        }

        /// <summary>
        /// Obtiene el Commensal
        /// </summary>
        private void getCommensal()
        {
            _commensal = (Commensal)_commensalDAO.FindById(1);

        }


        [Test()]
        /// <summary>
        /// Metodo para probar que un comensal existe.
        /// </summary>
        public void CommensalByIdTest()
        {
            getCommensal();

            Assert.IsNotNull(_commensal);

        }

        [Test()]
        /// <summary>
        /// Metodo para probar que un restaurante existe.
        /// </summary>
        public void RestaurantByIdTest()
        {
            getRestaurant();

            Assert.IsNotNull(_restaurant);

        }

      

        [Test()]
        /// <summary>
        /// Metodo para probar que se agrega un restaurante favorito a un comensal.
        /// </summary>
        public void AddFavoriteRestaurantCommensalTest()
        {             
            _commensal.RemoveFavoriteRestaurant(_restaurant);
            _commensal.AddFavoriteRestaurant(_restaurant);
            _commensalDAO.Save(_commensal);
            Assert.IsNotNull(_restaurant);
            Assert.IsNotEmpty(_restaurant.Address);
            Assert.AreEqual("El Mundo del Pollo", _restaurant.Name);
            Assert.IsNotNull(_commensal);
            Assert.IsNotEmpty(_commensal.Email);
            Assert.AreEqual("prueba@gmail.com", _commensal.Email);
           

        }


        [Test()]
        /// <summary>
        /// Metodo para probar que se elima un restaurante favorito a un comensal.
        /// </summary>
        public void DeleteFavoriteRestaurantCommensalTest()
        {
            _commensal.RemoveFavoriteRestaurant(_restaurant);
            _commensalDAO.Save(_commensal);
            Assert.IsNotNull(_commensal);
            Assert.IsNotEmpty(_commensal.Email);
            Assert.AreEqual("prueba@gmail.com", _commensal.Email);
            Assert.AreEqual(1, _commensal.FavoritesRestaurants.Count);
        }
        

        [Test()]
        /// <summary>
        /// Metodo para probar que se obtiene la lista de restaurantes.
        /// </summary>
        public void AllRestaurantTest()
        {          

            _listRestaurant = (IList<Restaurant>)_restaurantDAO.GetAll();
            Assert.IsNotNull(_listRestaurant);
            Assert.IsNotEmpty(_listRestaurant);
            Assert.AreEqual(6, _listRestaurant.Count);
        }


        [Test()]
        /// <summary>
        /// Metodo para probar que se obtiene la lista de restaurantes favoritos.
        /// </summary>
        public void FavoriteRestaurantTest()
        {
            Commensal favorites = (Commensal)_commensalDAO.FindById(13);
            Assert.IsNotNull(favorites.FavoritesRestaurants);
            Assert.IsNotEmpty(favorites.FavoritesRestaurants);
            Assert.AreEqual(2, favorites.FavoritesRestaurants.Count);
        }


        [Test()]
        /// <summary>
        /// Metodo para probar que un comensal existe dado su email.
        /// </summary>
        public void CommensalEmailTest()
        {
            Commensal _byEmail = (Commensal)_commensalDAO.FindByEmail("prueba@gmail.com");
            Assert.IsNotNull(_byEmail);
            Assert.IsNotEmpty(_byEmail.FavoritesRestaurants);
            Assert.AreEqual(1, _byEmail.Id);
        }

        /// <summary>
        /// prueba excepcion al buscar por id commensal
        /// </summary>
        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void FindCommensalByIdNullReferenceTest()
        {
             Commensal _commensalNull = (Commensal)_commensalDAO.FindById(15);
            _commensalDAO.Save(_commensalNull);
        }


        /// <summary>
        /// prueba excepcion al guardar un comensal
        /// </summary>
        [Test]
        [ExpectedException(typeof(SaveEntityFondaDAOException))]
        public void SaveEntityFondaDAOExceptionTest()
        {
            Commensal _commensalEmpty = EntityFactory.GetCommensal();
            _commensalDAO.Save(_commensalEmpty);
        }


        [TearDown]
        /// <summary>
        /// Metodo que limpia todas las variables
        /// </summary>
        public void Clean()
        {
           _facDAO = null;
           _commensalDAO = null;
           _restaurantDAO = null;
           _restaurant = null;
           _commensal = null;
            _listRestaurant = null;
        }

    }

}
