using System;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System.Collections.Generic;
using NHibernate.Criterion;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateDishDAO
        : HibernateNounBaseEntityDAO<Dish>, IDishDAO
    {
        public IList<Dish> GetAll()
        {
            return FindAll();
        }
    }
}
