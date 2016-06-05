using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System;
using System.Collections.Generic;
using NHibernate.Criterion;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateRestaurantDAO: HibernateNounBaseEntityDAO<Restaurant>, IRestaurantDAO
    {
        public IList<Restaurant> GetAll()
        {
            return FindAll();
        }

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
    }
}
