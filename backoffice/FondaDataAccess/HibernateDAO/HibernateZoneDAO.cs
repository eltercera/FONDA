using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System.Collections.Generic;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateZoneDAO : HibernateBaseEntityDAO<Zone>, IZoneDAO
    {
        public IList<Zone> GetAll()
        {
            return FindAll();
        }
    }
}
