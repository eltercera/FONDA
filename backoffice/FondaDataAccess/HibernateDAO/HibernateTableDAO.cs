using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System;
using System.Collections.Generic;
using NHibernate.Criterion;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateTableDAO : HibernateBaseEntityDAO<Table>, ITableDAO
    {
        private FactoryDAO.FactoryDAO _facDAO = FactoryDAO.FactoryDAO.Intance;

        public IList<Table> GetAll()
        {
            return FindAll();
        }

        /// <summary>
        /// Retorna una lista de Mesas de un restaurante
        /// </summary>
        /// <param name="restaurant">Recibe el ID de un Restaurante</param>
        /// <returns>Retorna una Lista de Table</returns>
        public IList<Table> GetTables(int restaurant)
        {
            IRestaurantDAO _restaurantDAO = _facDAO.GetRestaurantDAO();
            //busca las mesas de un restaurante
            IList<Table> tables = GetAll();
            IList<Table> restaurantTables = new List<Table>();
            Restaurant _restaurant = _restaurantDAO.FindById(restaurant);
            //si la mesa es del restaurante la guarda en unaa lista

            return _restaurant.Tables;
        }

        /// <summary>
        /// Retorna una lista de Mesas disponibles
        /// </summary>
        /// <param name="listTables">Recibe la lista de mesas de un Restaurante</param>
        /// <returns>Retorna una Lista de Table</returns>
        public IList<Table> GetAvailableTables(IList<Table> listTables)
        {
            IRestaurantDAO _restaurantDAO = _facDAO.GetRestaurantDAO();
            //se crea una lista de tables
            IList<Table> tables= new List<Table>();
            //se recorre la lista de todas las tables de un restaurante
            foreach (Table t in listTables)
            {
                //si la table esta disponible la guarda en la lista de tables a retornar
                if (t.Status.Equals(FreeTableStatus.Instance))
                {
                    tables.Add(t);
                }
            }


            return tables;
        }

        //public IList<Table> findByStatus(Status status, int restaurant)
        //{
        //    ICriterion criterion = Expression.And(Expression.Eq("Restaurant.Id", restaurant), Expression.Eq("Status", FreeTableStatus.Instance));
        //    return (FindAll(criterion));
        //}

        public IList<Table> TablesAvailableByDate(int restaurantId, IList<Reserve> listReservation, DateTime date)
        {
            IList<Table> tablesUnavailable = new List<Table>();
            IList<Table> tablesAvailable = GetTables(restaurantId);

            //busca las reservas que existan en la fecha de la nueva reserva
            foreach ( Reserve t in listReservation)
            {
                if (t.ReserveDate == date && t.ReserveTable != null)
                    tablesUnavailable.Add(t.ReserveTable);  
            }

            //si la la lista que se llenaba en el foreach anterior no esta vacia 
            //quita las mesas con reservas que coincidan con la reserva nueva de la lista que tiene todas las tables
            if(tablesUnavailable.Count != 0)
            {
                foreach (Table t in tablesAvailable)
                {
                    tablesAvailable.Remove(t);
                }
            }

            return tablesAvailable;
        }

        public IList<Table> TablesAvailableByCapacity(IList<Table> listTable, int commensalNumber)
        { 
            IList<Table> tablesAvailible = new List<Table>();
            //recibe una lista de mesas y las compara con el numero de comensal de las reservas
            //si la mesa tiene capacidad las guarda en una lista
            foreach (Table t in listTable)
            {
                if ((t.Capacity >= commensalNumber))
                    tablesAvailible.Add(t);
            }

            return tablesAvailible;
        }

    }
}
