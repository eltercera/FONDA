using System;
using System.Collections.Generic;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using NHibernate.Criterion;
using com.ds201625.fonda.Factory;
using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.DataAccess.Exceptions.Restaurant;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
	public class HibernateZoneDAO : HibernateNounBaseEntityDAO<Zone>, IZoneDAO
    {
        #region Restaurante
        /// <summary>
        /// Metodo que retorna una lista
        /// de todas las zonas 
        /// </summary>
        /// <returns></returns>
        public IList<Zone> allZone()
        {
            try
            {
                return FindAll();
            }
            catch (FindAllFondaDAOException e)
            {
                throw new GetAllZonesFondaDAOException(ResourceRestaurantMessagesDAO.GetAllZonesFondaDAOException, e);

            }
            catch (Exception e)
            {
                throw new GetAllZonesFondaDAOException(ResourceRestaurantMessagesDAO.GetAllZonesFondaDAOException, e);

            }

        }

        /// <summary>
        /// Devuelve una zona a partir de un nombre
        /// </summary>
        /// <param name="name">Nombre de la zona</param>
        /// <returns>Objeto tipo Zone</returns>
        public Zone GetZone(string name)
        {
            Zone zone;
            try
            {
                zone = FindBy("Name", name);
                if (zone == null)
                {
                    try
                    {
                        Zone _zone = EntityFactory.GetRestzone(name);
                        return _zone;
                    }
                    catch (FindAllFondaDAOException e)
                    {
                        throw new GetAllZonesFondaDAOException(ResourceRestaurantMessagesDAO.GetAllZonesFondaDAOException, e);

                    }
                    catch (Exception e)
                    {
                        throw new GetAllZonesFondaDAOException(ResourceRestaurantMessagesDAO.GetAllZonesFondaDAOException, e);

                    }

                }

            }
            catch (FindByFondaDAOException e)
            {
                throw new GetAllZonesFondaDAOException(ResourceRestaurantMessagesDAO.GetAllZonesFondaDAOException, e);

            }
            catch (Exception e)
            {
                throw new GetAllZonesFondaDAOException(ResourceRestaurantMessagesDAO.GetAllZonesFondaDAOException, e);

            }
            return zone;
        }
        #endregion


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
