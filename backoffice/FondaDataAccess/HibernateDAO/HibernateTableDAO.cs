using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System;
using System.Collections.Generic;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateTableDAO : HibernateBaseEntityDAO<Table>, ITableDAO
    {
        private com.ds201625.fonda.DataAccess.FactoryDAO.FactoryDAO _facDAO;
        public IList<Table> GetAll()
        {
            return FindAll();
        }

        public IList<Table> GetTables(int restaurant)
        {
            IList<Table> tables = GetAll();
            IList<Table> restaurantTables = new List<Table>();
            Restaurant _restaurant = new Restaurant();
            foreach(Table t in tables)
            {

                if (t.Restaurant.Id == restaurant)
                    restaurantTables.Add(t);
            }
            return restaurantTables;
        }

        /* public IList<Reservation> ReservationsOfTable(int table)
         {
             IList<Reservation> tables = ;

         }*/

        public IList<Table> TablesAvailableByDate(IList<Reservation> listReservation, DateTime date)
        {
            IList<Table> tablesAvailible = new List<Table>();

            foreach ( Reservation t in listReservation)
            {
                if (t.ReserveDate == date && t.ReserveTable != null)
                    tablesAvailible.Add(t.ReserveTable);  
            }

            return tablesAvailible;
        }

        public IList<Table> TablesAvailableByCapacity(IList<Table> listTable, int commensalNumber)
        {
            //IList<Table> tables=GetTables(restaurant);
            IList<Table> tablesAvailible = new List<Table>();

            foreach (Table t in listTable)
            {
                if ((t.Capacity >= commensalNumber))
                    tablesAvailible.Add(t);
            }

            return tablesAvailible;
        }
    }
}
