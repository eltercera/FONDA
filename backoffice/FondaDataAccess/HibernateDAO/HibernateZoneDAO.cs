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
        /// Metodo que retorna una lista
        /// de todas las zonas 
        /// </summary>
        /// <returns></returns>

        public IList<Zone> allZone()
        {

            return FindAll();
            
        }

        /// <summary>
        /// Devuelve una zona a partir de un nombre
        /// </summary>
        /// <param name="name">Nombre de la zona</param>
        /// <returns>Objeto tipo Zone</returns>
        public Zone GetZone(string name)
        {
            Zone zone = new Zone();
            zone = FindBy("zon_name", name);
            return zone;
        }
    }
}
