﻿using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System;
using System.Collections.Generic;
using NHibernate.Criterion;
using NHibernate;
using com.ds201625.fonda.DataAccess.FondaDAOExceptions;
using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.Resources.FondaResources.OrderAccount;
using com.ds201625.fonda.Factory;
using com.ds201625.fonda.DataAccess.Log;
using com.ds201625.fonda.DataAccess.Exceptions.Restaurant;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateRestaurantDAO : HibernateNounBaseEntityDAO<Restaurant>, IRestaurantDAO
    {
        FactoryDAO.FactoryDAO _facDAO = FactoryDAO.FactoryDAO.Intance;

        /// <summary>
        /// Metodo para devolver todos los restaurantes 
        /// que se encuentran en una zona
        /// </summary>
        /// <param name="zone"></param>
        /// <returns></returns>
        public IList<Restaurant> findByZone(Zone zone)
        {
            ICriterion criterion = Expression.Eq("Zone", zone);
            return (FindAll(criterion));
        }

        #region Restaurant
        /// <summary>
        /// Devuelve todos los restaurantes
        /// </summary>
        /// <returns>Una lista de restaurantes</returns>
        public IList<Restaurant> GetAll()
        {
            try
            {
                return FindAll();
            }
            catch (FindAllFondaDAOException e)
            {
                throw new GetAllRestaurantsFondaDAOException(ResourceRestaurantMessagesDAO.GetAllRestaurantsFondaDAOException, e);

            }
            catch (Exception e)
            {
                throw new GetAllRestaurantsFondaDAOException(ResourceRestaurantMessagesDAO.GetAllRestaurantsFondaDAOException, e);

            }
        }


        /// <summary>
        /// Genera un nuevo Restaurante a partir de los datos suministrados por el usuario
        /// </summary>
        /// <param name="Name">Nombre del Restaurante</param>
        /// <param name="Logo">Logo del Restaurante</param>
        /// <param name="Nationality">Nacionalidad</param>
        /// <param name="Rif">Rif del Restaurante</param>
        /// <param name="Address">Direccion fisica del Restaurante</param>
        /// <param name="Category">Tipo de comida del Restaurante</param>
        /// <param name="Currency">Tipo de moneda del Restaurante</param>
        /// <param name="Zone">Ubicacion del Restaurante</param>
        /// <param name="Long">Longitud para Coordenada</param>
        /// <param name="Lat">Latitud para Coordenada</param>
        /// <param name="OpeningTime">Hora de apertura</param>
        /// <param name="ClosingTime">Hora de cierre</param>
        /// <param name="Days">Dias laborables</param>
        /// <returns></returns>
        public Restaurant GenerateRestaurant(string Name, string Logo, char Nationality, string Rif, string Address,
                string category, string currency, string zone, double Long, double Lat,
                TimeSpan OpeningTime, TimeSpan ClosingTime, bool[] Days)
        {
            try
            {
                IRestaurantCategoryDAO _restcatDAO = _facDAO.GetRestaurantCategoryDAO();
                ICurrencyDAO _currencyDAO = _facDAO.GetCurrencyDAO();
                IZoneDAO _zoneDAO = _facDAO.GetZoneDAO();
                IScheduleDAO _scheduleDAO = _facDAO.GetScheduleDAO();
                SimpleStatus _status = _facDAO.GetActiveSimpleStatus();


                Coordinate _coordinate = EntityFactory.GetCoordinate(Long, Lat);

                RestaurantCategory _category = _restcatDAO.GetRestaurantCategory(category);

                Zone _zone = _zoneDAO.GetZone(zone);

                Currency _currency = _currencyDAO.GetCurrency(currency);

                Schedule _schedule = _scheduleDAO.GetSchedule(OpeningTime, ClosingTime, Days);

                Restaurant restaurant = EntityFactory.GetGenerateRestaurant(Name, Logo, Nationality, Rif, Address, _category, _currency, _zone, _coordinate, _schedule, _status);

                return restaurant;
            }
            catch (GenerateRestaurantFondaDAOException e)
            {
                throw new GenerateRestaurantFondaDAOException(ResourceRestaurantMessagesDAO.GenerateRestaurantFondaDAOException, e);

            }
            catch (Exception e)
            {
                throw new GenerateRestaurantFondaDAOException(ResourceRestaurantMessagesDAO.GenerateRestaurantFondaDAOException, e);

            }
        }

        /// <summary>
        /// Modifica un Restaurante
        /// </summary>
        /// <param name="idRestaurant">Id del Restaurante a modificar</param>
        /// <param name="newRestaurant">Datos a modificar del Restaurante</param>
        /// <returns>Restaurante resultante</returns>
        public Restaurant ModifyRestaurant(int idRestaurant, Restaurant newRestaurant)
        {
            try
            {
                IRestaurantDAO _restaurantDAO = _facDAO.GetRestaurantDAO();

                // Consigue el Restaurante a modificar en la Base de Datos
                com.ds201625.fonda.Domain.Restaurant _restaurant = _restaurantDAO.FindById(idRestaurant);

                // Cambia los valores suministrados por el usuario
                _restaurant.Name = newRestaurant.Name;
                _restaurant.Logo = newRestaurant.Logo;
                _restaurant.Nationality = newRestaurant.Nationality;
                _restaurant.Ssn = newRestaurant.Ssn;
                _restaurant.Address = newRestaurant.Address;
                _restaurant.RestaurantCategory = newRestaurant.RestaurantCategory;
                _restaurant.Currency = newRestaurant.Currency;
                _restaurant.Zone = newRestaurant.Zone;
                _restaurant.Coordinate = newRestaurant.Coordinate;
                _restaurant.Schedule = newRestaurant.Schedule;
                _restaurant.Status = _facDAO.GetActiveSimpleStatus();

                return _restaurant;
            }
            catch (ModifyRestaurantFondaDAOException e)
            {
                throw new ModifyRestaurantFondaDAOException(ResourceRestaurantMessagesDAO.ModifyRestaurantFondaDAOException, e);

            }
            catch (Exception e)
            {
                throw new ModifyRestaurantFondaDAOException(ResourceRestaurantMessagesDAO.ModifyRestaurantFondaDAOException, e);

            }
        }
        #endregion

        /*
        public Restaurant findByTable(Table table)
        {
            ICriteria crit = Session.CreateCriteria(typeof(Restaurant));
            // Inner Join
            crit.CreateAlias("Tables", "sm");
            crit.Add(Restrictions.Eq("sm.Id", table.Id));
            return (Restaurant)crit.List()[0];
        }*/

        public bool Geoposition(double _latitudUser, double _longitudUser, int _idRestaurant)
        {
            bool came = false;
            IRestaurantDAO _restaurantDAO = _facDAO.GetRestaurantDAO();

            // Consigue el Restaurante de la Base de Datos
            com.ds201625.fonda.Domain.Restaurant _restaurant = _restaurantDAO.FindById(_idRestaurant);
            //convertir coordenadas a decimal para cortarlas asi se puede detectar coicidencia en una misma zona
            Decimal _latitudDecimal = Math.Round(Convert.ToDecimal(_latitudUser), 2);
            Decimal _longitudDecimal = Math.Round(Convert.ToDecimal(_longitudUser), 2);
            Decimal _latitudRestaurantDecimal = Math.Round(Convert.ToDecimal(_restaurant.Coordinate.Latitude), 2);
            Decimal _longitudRestaurantDecimal = Math.Round(Convert.ToDecimal(_restaurant.Coordinate.Longitude), 2);
            // compara coordenadas del restaurante con coordenadas del usuario
            if (_latitudRestaurantDecimal == _latitudDecimal && _longitudRestaurantDecimal == _longitudDecimal)
            {   //si es true el usuario llegó
                came = true;
            }
            //si es false no ha llegado
            return came;
        }

        public bool ValidateHour(int _idRestaurant, DateTime _hour)
        {
            bool valid = true;
            TimeSpan _hourSpan;
            IRestaurantDAO _restaurantDAO = _facDAO.GetRestaurantDAO();
            com.ds201625.fonda.Domain.Restaurant _restaurant = _restaurantDAO.FindById(_idRestaurant);
            _hourSpan = _hour.TimeOfDay;
            //compara que la reserva no se haga en un horario fuera del que trabaja el restaurante
            if (_hourSpan < _restaurant.Schedule.OpeningTime || _hourSpan > _restaurant.Schedule.ClosingTime)
            {
                //si es false la reserva no puede ser registrada
                valid = false;
            }

            return valid;
        }

        public bool ValidateDay(int _idRestaurant, DateTime _date)
        {
            bool valid = false;
            DayOfWeek _day;
            IList<Day> _daysRestaurant;
            string nameDayOfWeek = "";
            IRestaurantDAO _restaurantDAO = _facDAO.GetRestaurantDAO();
            com.ds201625.fonda.Domain.Restaurant _restaurant = _restaurantDAO.FindById(_idRestaurant);
            //convierte el date de la reserva por un DayOfWeek para poder saber el dia de la semana será la reserva
            _day = _date.DayOfWeek;
            _daysRestaurant = _restaurant.Schedule.Day;
            //convierte el dia de la semana a un dia de la semana que coicida con los registrados en restaurant
            if ((int)_day == 7)
            {
                nameDayOfWeek = "Domingo";
            }
            if ((int)_day == 1)
            {
                nameDayOfWeek = "Lunes";
            }
            if ((int)_day == 2)
            {
                nameDayOfWeek = "Martes";
            }
            if ((int)_day == 3)
            {
                nameDayOfWeek = "Miercoles";
            }
            if ((int)_day == 4)
            {
                nameDayOfWeek = "Jueves";
            }
            if ((int)_day == 5)
            {
                nameDayOfWeek = "Viernes";
            }
            if ((int)_day == 6)
            {
                nameDayOfWeek = "Sabado";
            }
            //si el dia de la reserva coicide con los dias que trabaja el restaurante se hace true
            foreach (Day d in _daysRestaurant)
            {
                if (d.Name == nameDayOfWeek)
                    valid = true;
            }

            return valid;
        }

        public IList<Restaurant> findByCategory(RestaurantCategory category)
        {
            ICriterion criterion = Expression.Eq("RestaurantCategory", category);
            return (FindAll(criterion));
        }

        #region 3era entrega

        public IList<Restaurant> FindByFilters(
            string query, int idZone, int idCategory, int max, int page)
        {
            Conjunction generalCriterial = Restrictions.Conjunction();

            if (query != null && query != String.Empty)
            {
                query = "%" + query + "%";
                generalCriterial.Add(Restrictions.Disjunction()
                    .Add(Restrictions.InsensitiveLike("Name", query))
                    .Add(Restrictions.InsensitiveLike("Address", query))
                );
            }

            if (idZone > 0)
            {
                generalCriterial.Add(Restrictions.Eq("Zone.Id", idZone));
            }

            if (idCategory > 0)
            {
                generalCriterial.Add(Restrictions.Eq("RestaurantCategory.Id", idCategory));
            }
			generalCriterial.Add(
				Restrictions.Eq("Status", FactoryDAO.FactoryDAO.Intance.GetActiveSimpleStatus()));

            return FindAllSortedByName(true, generalCriterial, max, (page - 1) * max);
        }

        #endregion

        #region OrderAccount

        /// <summary>
        /// Obtiene las ordenes cerradas de un Restaurante
        /// </summary>
        /// <param name="restaurant">El id de un Restaurant</param>
        /// <returns>Una lista de Close Account</returns>
        public IList<Account> ClosedOrdersByRestaurantId(int restaurantId)
        {
            IList<Account> list = new List<Account>();
            try
            {

                Restaurant restaurant = Session.QueryOver<Restaurant>()
                    .Where(r => r.Id == restaurantId)
                    .Where(r => r.Status == ActiveSimpleStatus.Instance)
                    .SingleOrDefault();

             

                foreach (Account closedAccount in restaurant.Accounts)
                {
                    if (closedAccount.Status.Equals(ClosedAccountStatus.Instance))
                        list.Add(closedAccount);
                }


            }
            catch (ArgumentOutOfRangeException e)
            {
                ClosedOrdersByRestaurantFondaDAOException exception =
                       new ClosedOrdersByRestaurantFondaDAOException(
                           OrderAccountResources.MessageClosedOrdersByRestaurantFondaDAOException,
                           e);
                Logger.WriteErrorLog(exception.Message, exception);
                throw exception;
            }
            catch (Exception e)
            {
                ClosedOrdersByRestaurantFondaDAOException exception =
                    new ClosedOrdersByRestaurantFondaDAOException(
                        OrderAccountResources.MessageClosedOrdersByRestaurantFondaDAOException,
                        e);
                Logger.WriteErrorLog(exception.Message, exception);
                throw exception;
            }
            Logger.WriteSuccessLog(OrderAccountResources.ClassNameRestaurantDAO,
                OrderAccountResources.SuccessMessageClosedOrdersByRestaurantId,
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
            return list;

        }

        /// <summary>
        /// Obtiene las ordenes abiertas de un Restaurante
        /// </summary>
        /// <param name="idRestaurant">Un ID de Restaurant tipo int</param>
        /// <returns>Una List de Accounts</returns>
        public IList<Account> OpenOrdersByRestaurantId(int restaurantId)
        {
            IList<Account> list = new List<Account>();
            try
            {
                Restaurant restaurant = Session.QueryOver<Restaurant>()
                    .Where(r => r.Id == restaurantId)
                    .Where(r => r.Status == ActiveSimpleStatus.Instance)
                    .SingleOrDefault();



                foreach (Account closedAccount in restaurant.Accounts)
                {
                    if (closedAccount.Status.Equals(OpenAccountStatus.Instance))
                        list.Add(closedAccount);
                }

            }
            catch (ArgumentOutOfRangeException e)
            {
                OpenOrdersByRestaurantIdFondaDAOException exception =
                       new OpenOrdersByRestaurantIdFondaDAOException(
                           OrderAccountResources.MessageOpenOrdersByRestaurantIdFondaDAOException,
                           e);
                Logger.WriteErrorLog(exception.Message, exception);
                throw exception;
            }
            catch (Exception e)
            {
                OpenOrdersByRestaurantIdFondaDAOException exception =
                    new OpenOrdersByRestaurantIdFondaDAOException(
                        OrderAccountResources.MessageOpenOrdersByRestaurantIdFondaDAOException,
                        e);
                Logger.WriteErrorLog(exception.Message, exception);
                throw exception;
            }
            Logger.WriteSuccessLog(OrderAccountResources.ClassNameRestaurantDAO,
                OrderAccountResources.SuccessMessageOpenOrdersByRestaurantId,
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
            return list;
        }

        /// <summary>
        /// Libera la mesa de estar ocupada pasa a estar disponible
        /// </summary>
        /// <param name="restaurant">Restaurante al que pertenece la mesa</param>
        /// <param name="tableId">Id de la mesa a liberar</param>
        public void ReleaseTable(Restaurant restaurant, int tableId)
        {
            ITableDAO _tableDAO;
            FreeTableStatus freeStatus;
            bool exists = false;
            
            try
            {
                _tableDAO = _facDAO.GetTableDAO();
                freeStatus = _facDAO.GetFreeTableStatus();
                foreach (Table t in restaurant.Tables)
                {
                    if (t.Id.Equals(tableId))
                        exists = true;
                }

                if(exists)
                {
                    Table table = _tableDAO.FindById(tableId);
                    restaurant.Tables.Remove(table);
                    table.Status = freeStatus;
                    restaurant.Tables.Add(table);
                }

                 Save(restaurant);

            }
            catch (ArgumentOutOfRangeException ex)
            {
                ReleaseTableFondaDAOException exception = new ReleaseTableFondaDAOException
                    (OrderAccountResources.MessageReleaseTableFondaDAOException,
                    ex);
                Logger.WriteErrorLog(exception.Message, exception);
                throw exception;

            }
            catch(Exception ex)
            {
                ReleaseTableFondaDAOException exception = new ReleaseTableFondaDAOException
                    (OrderAccountResources.MessageReleaseTableFondaDAOException,
                    ex);
                Logger.WriteErrorLog(exception.Message, exception);
                throw exception;
            }
            Logger.WriteSuccessLog(OrderAccountResources.ClassNameRestaurantDAO,
                OrderAccountResources.SuccessMessageReleaseTable,
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        }

        #endregion

        #region Reservation

        /// <summary>
        /// Obtiene las reservaciones de un Restaurante
        /// </summary>
        /// <param name="idRestaurant">Un ID de Restaurant</param>
        /// <returns>Una List de Reservations</returns>
        public IList<Reservation> ReservationsByRestaurantId(int restaurantId)
        {


            try
            {
                //TODO: Excepcion en caso de no encontrar restaurante
                Restaurant restaurant = Session.QueryOver<Restaurant>()
                    .Where(r => r.Id == restaurantId)
                    .Where(r => r.Status == ActiveSimpleStatus.Instance)
                    .SingleOrDefault();

                IList<Reservation> listReservations = new List<Reservation>();



                //TODO: Excepcion en caso de no encontrar lista llena
                foreach (Table reservedTable in restaurant.Tables)
                {
                    foreach (Reservation reservation in reservedTable.Reservations)
                    {
                        listReservations.Add(reservation);
                    }
                }
                return listReservations;

            }
            //TODO: Arrojar excepciones personalizadas
            catch (ArgumentOutOfRangeException e)
            {
                throw new FondaIndexException("Not Found reservation", e);
            }
        }

        /// <summary>
        /// Obtiene las mesas de un Restaurante
        /// </summary>
        /// <param name="idRestaurant">Un ID de Restaurant</param>
        /// <returns>Una List de Table</returns>
        public IList<Table> TablesByRestaurantId(int restaurantId)
        {


            try
            {
                //TODO: Excepcion en caso de no encontrar restaurante
                Restaurant restaurant = Session.QueryOver<Restaurant>()
                    .Where(r => r.Id == restaurantId)
                    .Where(r => r.Status == ActiveSimpleStatus.Instance)
                    .SingleOrDefault();

                IList<Table> listTables = new List<Table>();



                //TODO: Excepcion en caso de no encontrar lista llena
                foreach (Table restaurantTable in restaurant.Tables)
                {
                    listTables.Add(restaurantTable);
                }
                return listTables;

            }
            //TODO: Arrojar excepciones personalizadas
            catch (ArgumentOutOfRangeException e)
            {
                throw new FondaIndexException("Not Found table", e);
            }
        }

        /// <summary>
        /// Busca un restaurant por una mesa
        /// <param name="tableId"></param>
        /// <returns>Restaurant</returns>
        public Restaurant GetRestaurantByTable(int tableId)
        {
            IList<Restaurant> _listRestaurant = new List<Restaurant>();
            IList<Table> _listTable = new List<Table>();
            Restaurant _restaurant = EntityFactory.GetRestaurant();
            IRestaurantDAO _restaurantDAO = _facDAO.GetRestaurantDAO();
            //  Restaurant _restaurant;
            // _restaurantDAO = _facDAO.GetRestaurantDAO();
            try
            {
                _listRestaurant = _restaurantDAO.GetAll();

                foreach (Restaurant restaurant in _listRestaurant)
                {
              
                    foreach (Table _table in restaurant.Tables)
                    {
                        if (tableId.Equals(_table.Id))
                        {
                            _restaurant = restaurant;
                        }
                    }
                }


            }
            //Todo Reservation: Personalizar
            catch (Exception ex)
            {
                GetOrderAccountFondaDAOException exception = new GetOrderAccountFondaDAOException(
                    OrderAccountResources.MessageCanceledInvoiceException, ex);
                Logger.WriteErrorLog(exception.Message, exception);
                throw exception;
            }
            Logger.WriteSuccessLog(OrderAccountResources.ClassNameOrderAccountDAO,
                OrderAccountResources.SuccessMessageGetOrderAccount,
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
            return _restaurant;
        }

        #endregion
    }
}

