using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System;
using System.Collections.Generic;
using com.ds201625.fonda.DataAccess.FactoryDAO;


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
            RestaurantCategory category = new RestaurantCategory();
            category = FindBy("rc_name", name);
            return category;
        }

    }
}
