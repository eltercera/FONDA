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
        /// <summary>
        /// FABRICA DE OBJETOS
        /// </summary>
        private FactoryDAO _facDAO;
        /// <summary>
        /// INTERFAZ DE COMMENSAL AL CUAL SE LE VAN AGREGAR RESTAURANTES
        /// </summary>
        private ICommensalDAO _commensalDAO;
        /// <summary>
        /// INTERFAZ DE LA RESTAURANTE A AGREGAR COMO FAVORTIO
        /// </summary>
        private IRestaurantDAO _restaurantDAO;
        /// <summary>
        /// RESTAURANTES A AGREGAR MANUALMENTE
        /// </summary>
        private Restaurant _restaurantId1;
        private Restaurant _restaurantId2;
        /// <summary>
        /// Ids PARA FINDBYID
        /// </summary>
        private int Id1 = 1;
        private int Id2 = 2;
        /// <summary>
        /// COMMENSAL CREADO MANUALMENTE
        /// </summary>
        private Commensal _commensalId1;
        private Commensal _commensal = new Commensal
        {

            Password = "prueba",
            SesionToken = "prueba",
            Email = "prueba",
            Status = ActiveSimpleStatus.Instance
        };
        /// <summary>
        /// RESTAURANTES CREADOS MANUALMENTES
        /// </summary>
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

        /// <summary>
        /// VOID TEST QUE AGREGA RESTAURANT MANUALMENTE
        /// </summary>
        [Test()]
        public void agregarRestaurant()
        {

            AddRestaurantToCommensal(_commensal, _restaurant, _restaurant2);
            getCommensalDao();
            _commensalDAO.Save(_commensal);
        }
        /// <summary>
        /// VOID TEST QUE AGREGA RESTAURANTE COMO FAVORITO
        /// CON EL ID DEL COMMENSAL Y LOS ID DE LOS RESTAURANTES
        /// </summary>
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
        /// <summary>
        /// VOID TEST QUE ELIMINA RESTAURANTE COMO FAVORITO
        /// CON EL ID DEL COMMENSAL Y LOS ID DE LOS RESTAURANTES
        /// </summary>
        [Test()]
        public void deleteById()
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
        /// <summary>
        /// VOID QUE AGREGA RESTAURANTE A LA LISTA DEL OBJETO COMMENSAL
        /// </summary>
        /// <param name="commensal"></param>
        /// OBJETO DE COMMENSAL AL QUE SE LE AGREGARAN RESTAURANTES
        /// <param name="restarants"></param>
        /// ARREGLO DE RESTAURANTE A AGREGAR COMO FAVORITOS
        public static void AddRestaurantToCommensal
            (Commensal commensal, params Restaurant[] restarants)
        {
            foreach (var restaurant in restarants)
            {
                commensal.AddFavoriteRestaurant(restaurant);
            }
        }
        /// <summary>
        /// VOID QUE ELIMINA RESTAURANTE A LA LISTA DEL OBJETO COMMENSAL
        /// </summary>
        /// <param name="commensal"></param>
        /// OBJETO DE COMMENSAL AL QUE SE LE ELIMINARAN RESTAURANTES
        /// <param name="restarants"></param>
        /// ARREGLO DE RESTAURANTE A ELIMINARAN COMO FAVORITOS
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
        /// <summary>
        /// VOID PARA INSTANCIAR LA FABRICA
        /// </summary>
        private void getDao()
        {
            if (_facDAO == null)
                _facDAO = FactoryDAO.Intance;
        }


    }


}