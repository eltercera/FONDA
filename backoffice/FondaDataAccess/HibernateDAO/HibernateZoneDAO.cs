using System;
using System.Collections.Generic;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using NHibernate.Criterion;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateZoneDAO : HibernateBaseEntityDAO<Zone>, IZoneDAO
    {
        /// <summary>
        /// Retorna todas las zonas 
        /// </summary>
        /// <returns></returns>

        public IList<Zone> allZone()
        {

            return FindAll();
            
        }
    }
}
