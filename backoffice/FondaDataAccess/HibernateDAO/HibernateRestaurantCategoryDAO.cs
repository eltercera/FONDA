using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System;
using System.Collections.Generic;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using NHibernate.Criterion;


namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateRestaurantCategoryDAO : HibernateNounBaseEntityDAO<RestaurantCategory>, IRestaurantCategoryDAO
    {
        /// <summary>
        /// Devuelve la lista de todas las Categorias por Restaurante de la Base de Datos
        /// </summary>
        /// <returns>Lista de tipo RestaurantCategory</returns>
        public IList<RestaurantCategory> GetAll()
        {
            return FindAll();
        }

        /// <summary>
        /// Devuelve una categoria de la Base de Datos
        /// </summary>
        /// <param name="name">Nombre de la categoria</param>
        /// <returns>Objeto tipo RestaurantCategory</returns>
        public RestaurantCategory GetRestaurantCategory(string name)
        {
            RestaurantCategory category = FindBy("Name", name);
            if (category == null)
            {
                RestaurantCategory newCategory = new RestaurantCategory();
                newCategory.Name = name;
                return newCategory;
            }

            return category;
        }

		#region 3era entrga

		public IList<RestaurantCategory> FindAllWithRestaurants (
			string query = null, int max = -1, int page = 1)
		{
			DetachedCriteria critRest = DetachedCriteria.For<Restaurant> ("rest")
				.Add (Property.ForName ("rest.RestaurantCategory.Id").EqProperty ("therescat.Id"))
				.SetProjection (Projections.Count ("rest.RestaurantCategory.Id"));

			return FindAllLikeName(query,max,page,Subqueries.Lt (0, critRest),"therescat");
		}

		#endregion
    }
}
