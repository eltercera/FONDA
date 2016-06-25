using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System.Collections.Generic;
using com.ds201625.fonda.Factory;
using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.DataAccess.Exceptions.Restaurant;
using System;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateCurrencyDAO : HibernateNounBaseEntityDAO<Currency>, ICurrencyDAO
    {
        #region Restaurant
        /// <summary>
        /// Devuelve la lista de todos los tipos de moneda de la Base de Datos
        /// </summary>
        /// <returns>Lista de tipo Currency</returns>
        public IList<Currency> GetAll()
        {
            try
            {
                return FindAll();
            }
            catch (FindAllFondaDAOException e)
            {
                throw new GetAllCurrenciesFondaDAOException(ResourceRestaurantMessagesDAO.GetAllCurrenciesFondaDAOException, e);

            }
            catch (Exception e)
            {
                throw new GetAllCurrenciesFondaDAOException(ResourceRestaurantMessagesDAO.GetAllCurrenciesFondaDAOException, e);

            }
        }

        /// <summary>
        /// Devuelve un tipo de moneda de la Base de Datos
        /// </summary>
        /// <param name="name">Nombre de la moneda</param>
        /// <returns>Objeto tipo Currency</returns>
        public Currency GetCurrency(string name)
        {
            Currency currency;
            try
            {
                currency = FindBy("Name", name);
                if (currency == null)
                {
                    try
                    {
                        Currency _currency = EntityFactory.GetRestCurrency(name);
                        return _currency;
                    }
                    catch (FindAllFondaDAOException e)
                    {
                        throw new GetAllCurrenciesFondaDAOException(ResourceRestaurantMessagesDAO.GetAllCurrenciesFondaDAOException, e);

                    }
                    catch (Exception e)
                    {
                        throw new GetAllCurrenciesFondaDAOException(ResourceRestaurantMessagesDAO.GetAllCurrenciesFondaDAOException, e);

                    }
                }


            }
            catch (FindByFondaDAOException e)
            {
                throw new GetAllCurrenciesFondaDAOException(ResourceRestaurantMessagesDAO.GetAllCurrenciesFondaDAOException, e);

            }
            catch (Exception e)
            {
                throw new GetAllCurrenciesFondaDAOException(ResourceRestaurantMessagesDAO.GetAllCurrenciesFondaDAOException, e);

            }
            return currency;

        }
        #endregion
    }
}

