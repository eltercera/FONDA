using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System.Collections.Generic;
using com.ds201625.fonda.Factory;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateCurrencyDAO : HibernateNounBaseEntityDAO<Currency> , ICurrencyDAO
    {
        /// <summary>
        /// Devuelve la lista de todos los tipos de moneda de la Base de Datos
        /// </summary>
        /// <returns>Lista de tipo Currency</returns>
        public IList<Currency> GetAll()
        {
            return FindAll();
        }

        /// <summary>
        /// Devuelve un tipo de moneda de la Base de Datos
        /// </summary>
        /// <param name="name">Nombre de la moneda</param>
        /// <returns>Objeto tipo Currency</returns>
        public Currency GetCurrency(string name)
        {
            Currency currency = FindBy("Name", name);
            if (currency == null)
            {
                Currency _currency = EntityFactory.GetRestCurrency(name);
                return _currency;
            }

            return currency;
        }


    }
}
