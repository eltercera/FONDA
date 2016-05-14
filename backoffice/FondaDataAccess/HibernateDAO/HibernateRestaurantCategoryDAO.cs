using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System;
using System.Collections.Generic;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateRestaurantCategoryDAO : HibernateNounBaseEntityDAO<RestaurantCategory>, IRestaurantCategoryDAO
    {
        public IList<RestaurantCategory> GetAll()
        {
            return FindAll();
        }
    }
}
