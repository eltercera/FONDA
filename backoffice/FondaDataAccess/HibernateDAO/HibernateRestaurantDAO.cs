using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System;
using System.Collections.Generic;
using NHibernate.Criterion;
using NHibernate;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateRestaurantDAO : HibernateNounBaseEntityDAO<Restaurant>, IRestaurantDAO
    {
        public Restaurant findByTable(Table table)
        {
            ICriteria crit = Session.CreateCriteria(typeof(Restaurant));
            // Inner Join
            crit.CreateAlias("Tables", "sm");
            crit.Add(Restrictions.Eq("sm.Id", table.Id));
            return (Restaurant)crit.List()[0];
        }
    }
}
