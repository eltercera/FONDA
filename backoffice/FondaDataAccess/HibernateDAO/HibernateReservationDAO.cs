using com.ds201625.fonda.DataAccess.FondaDAOExceptions;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System;
using System.Collections.Generic;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateReservationDAO : HibernateBaseEntityDAO<Reservation>, IReservationDAO
    {
        private FactoryDAO.FactoryDAO _facDAO = FactoryDAO.FactoryDAO.Intance;

        /// <summary>
        /// Devuelve todas las reservaciones
        /// </summary>
        /// <returns>Una lista de reservaciones</returns>
        public IList<Reservation> GetAll()
        {
            return FindAll();
        }

        /// <summary>
        /// Obtiene las reservaciones de una mesa
        /// </summary>
        /// <param name="table">Un id de mesa</param>
        /// <returns>Un objeto List de Reservation</returns>
        public IList<Reservation> FindReservationsByTable(int tableId)
        {
            //Esto no deberia estar aqui
            ITableDAO _tableDAO;
            Table _table;
            _tableDAO = _facDAO.GetTableDAO();

            try
            {
                //Esto tampoco deberia estar aqui
                _table = _tableDAO.FindById(tableId);

                IList<Reservation> _reservations = new List<Reservation>();
                _reservations = _table.Reservations;
                return _reservations;
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new FondaIndexException("Not Found Reservation", e);
            }
        }


        /// <summary>
        /// Obtiene las reservaciones de un restaurant
        /// </summary>
        /// <param name="restaurantId">Un id de restaurant</param>
        /// <returns>Un objeto List de Reservation</returns>
        public IList<Reservation> FindReservationsByRestaurant(int restaurantId)
        {
            //Esto no deberia estar aqui
            IRestaurantDAO _restaurantDAO;
            Restaurant _restaurant;
            _restaurantDAO = _facDAO.GetRestaurantDAO();

            try
            {
                //Esto tampoco deberia estar aqui
                _restaurant = _restaurantDAO.FindById(restaurantId);

                IList<Reservation> _reservations = new List<Reservation>();

                foreach (Table table in _restaurant.Tables)
                {
                    foreach (Reservation reservation in table.Reservations)
                    _reservations.Add(reservation);
                }

                return _reservations;
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new FondaIndexException("Not Found Reservation", e);
            }
        }
    }

}

