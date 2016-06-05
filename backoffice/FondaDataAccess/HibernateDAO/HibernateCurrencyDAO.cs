using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System.Collections.Generic;
namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateCurrencyDAO : HibernateNounBaseEntityDAO<Currency> , ICurrencyDAO
    {
        public IList<Currency> GetAll()
        {
            return FindAll();
        }
    }
}
