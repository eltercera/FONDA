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
        private Commensal _commensal = new Commensal
        {    
            Password = "prueba",
          SesionToken = "prueba",
            Email = "prueba",
            Status = ActiveSimpleStatus.Instance
        };
        
        private Restaurant _restaurant = new Restaurant
        {
            Address = "prueba",
            Name = "prueba",
            Ssn = "prueba",
            Logo = "prueba"            
        };

        private Restaurant _restaurant2 = new Restaurant
        {
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



        public static void AddRestaurantToCommensal
            (Commensal commensal, params Restaurant[] restarants)
        {
            foreach (var restaurant in restarants)
            {
                commensal.AddFavoriteRestaurant(restaurant);
            }
        }

        private void getCommensalDao()
        {
            getDao();
            if (_commensalDAO == null)
                _commensalDAO = _facDAO.GetCommensalDAO();

        }

        private void getDao()
        {
            if (_facDAO == null)
                _facDAO = FactoryDAO.Intance;
        }


    }


}
