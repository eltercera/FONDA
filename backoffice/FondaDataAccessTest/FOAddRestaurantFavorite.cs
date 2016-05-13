using NUnit.Framework;
using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;

namespace DataAccess
{
    [TestFixture()]
    class FOAddRestaurantFavorite : BaseEntity
    {
        private FactoryDAO _facDAO;
        private ICommensalDAO _commensalDAO;
        private IRestaurantDAO _restaurantDAO;
        private IUserAccountDAO _userAccountDAO;
        private UserAccount _useraccount;
        private Restaurant _restaurantId1;
        private Restaurant _restaurantId2;
        private int Id1 = 1;
        private int Id2 = 2;
        private Commensal _commensalId1;
        private Commensal _commensal = new Commensal
        {
            Id = 6,
            Password = "prueba",
          SesionToken = "prueba",
            Email = "prueba",
            Status = ActiveSimpleStatus.Instance
        };
        
        private Restaurant _restaurant = new Restaurant
        {
            Id = 5,
            Address = "prueba",
            Name = "prueba",
            Ssn = "prueba",
            Logo = "prueba"            
        };

        private Restaurant _restaurant2 = new Restaurant
        {
            Id = 6,
            Address = "prueba",
            Name = "prueba",
            Ssn = "prueba",
            Logo = "prueba"
        };


        [Test()]
        public void agregarRestaurant()
        {
            
            AddRestaurantToCommensal(_commensal,_restaurant,_restaurant2);
            getCommensalDao();
            _commensalDAO.Save(_commensal);
        }

        [Test()]
        public void addById()
        {
            getRestaurantDao();
            getCommensalDao();
            _restaurantId1 = _restaurantDAO.FindById(3);
            _restaurantId2 = _restaurantDAO.FindById(4);
            //findbyid para traerse objeto de commensal
            _commensalId1 = (Commensal)_commensalDAO.FindById(1);
            AddRestaurantToCommensal(_commensalId1, _restaurantId1, _restaurantId2);
             _commensalDAO.Save(_commensalId1);
        }

        [Test()]
        public void deleteById ()
        {
            getRestaurantDao();
            getCommensalDao();
            _restaurantId1 = _restaurantDAO.FindById(3);
            _restaurantId2 = _restaurantDAO.FindById(4);
            //findbyid para traerse objeto de commensal
            _commensalId1 = (Commensal)_commensalDAO.FindById(1);
            RemoveRestaurantToCommensal(_commensalId1, _restaurantId1, _restaurantId2);
            _commensalDAO.Save(_commensalId1);
        }

        public static void AddRestaurantToCommensal
            (Commensal commensal, params Restaurant[] restarants)
        {
            foreach (var restaurant in restarants)
            {
                commensal.AddFavoriteRestaurant(restaurant);
            }
        }

        public static void RemoveRestaurantToCommensal
            (Commensal commensal, params Restaurant[] restarants)
        {
            foreach (var restaurant in restarants)
            {
                commensal.RemoveFavoriteRestaurant(restaurant);
            }
        }

        private void getCommensalDao()
        {
            getDao();
            if (_commensalDAO == null)
                _commensalDAO = _facDAO.GetCommensalDAO();

        }

        private void getRestaurantDao()
        {
            getDao();
            if (_restaurantDAO == null)
                _restaurantDAO = _facDAO.GetRestaurantDAO();

        }

        private void getDao()
        {
            if (_facDAO == null)
                _facDAO = FactoryDAO.Intance;
        }


    }


}
