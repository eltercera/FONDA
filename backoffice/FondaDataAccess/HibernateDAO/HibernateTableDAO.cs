using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System;
using System.Collections.Generic;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateTableDAO : HibernateBaseEntityDAO<Table>, ITableDAO
    {
        public IList<Table> GetAll()
        {
            return FindAll();
        }

        public IList<Table> GetTables(int restaurant)
        {
            IList<Table> tables = GetAll();
            IList<Table> restaurantTables = new List<Table>();
            foreach(Table t in tables)
            {
                if (t.Restaurant.Id == restaurant)
                    restaurantTables.Add(t);
            }
            return restaurantTables;
        }
    }
}
