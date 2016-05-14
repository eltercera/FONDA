using NUnit.Framework;
using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;

namespace DataAccess
{
    [TestFixture()]
    class FORestaurantRegister
    {
        private FactoryDAOO _facDAO;

        private IRestaurantDAO _restaurantDAO;
        private Restaurant _restaurant;
        private int _restaurantId;
        [Test()]
        public void RestaurantDomainTest()
        {
            generateRestaurant();
        }

        [Test()]
        public void RestaurantSave()
        {
            // Genera una persona
            getRestaurantDao();
            generateRestaurant();

            // La persiste
            _restaurantDAO.Save(_restaurant);

        }

        private void generateRestaurant(bool edit = false)
        {
            if (_restaurant != null & !edit)
                return;

            if ((edit & _restaurant == null) | _restaurant == null)
                _restaurant = new Restaurant();

            string editadd = "";

            if (edit)
                editadd = "Editado";

            _restaurant.Address = "prueba";
            _restaurant.Name = "prueba";
            _restaurant.Ssn = "prueba";
            _restaurant.Logo = "prueba";
           
            

        }
        private void getRestaurantDao()
        {
            getDao();
            if ( _restaurantDAO == null)
                _restaurantDAO = _facDAO.GetRestaurantDAO();

        }

        private void getDao()
        {
            if (_facDAO == null)
                _facDAO = FactoryDAOO.Intance;
        }

    }

}
