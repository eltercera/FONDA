using System;
using System.Collections.Generic;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using NHibernate.Criterion;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
	public class HibernateZoneDAO : HibernateNounBaseEntityDAO<Zone>, IZoneDAO
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
            Zone zone = FindBy("Name", name);
            if (zone == null)
            {
                Zone newZone = new Zone();
                newZone.Name = name;
                return newZone;
            }

            return zone;
        }

		#region 3era entrga

		public IList<Zone> FindAllWithRestaurants (string query = null, int max = -1, int page = 1)
		{
			DetachedCriteria critRest = DetachedCriteria.For<Restaurant> ("rest")
				.Add (Property.ForName ("rest.Zone.Id").EqProperty ("thezone.Id"))
				.SetProjection (Projections.Count ("rest.Zone.Id"));

			return FindAllLikeName(query,max,page,Subqueries.Lt (0, critRest),"thezone");
		}

		#endregion
    }
}
