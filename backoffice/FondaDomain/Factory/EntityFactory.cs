using com.ds201625.fonda.Domain;
using System.Collections.Generic;

namespace com.ds201625.fonda.Factory
{
    /// <summary>
    /// Fabricada que instancia las entidades del dominio
    /// </summary>
    public class EntityFactory
    {
        #region OrderAccount

        //Instancia los objetos del dominio invocando al constructor(es) de la entidad

        public static Entity GetAccount()
        {
            return new Account();
        }

        public static Entity GetAccount(Table table, Commensal commensal, IList<DishOrder> listOrder, int number)
        {
            return new Account(table, commensal, listOrder, number);
        }

        public static Entity GetAccount(Table table, IList<DishOrder> listOrder)
        {
            return new Account(table, listOrder);
        }

        public static Entity GetInvoice()
        {
            return new Invoice();
        }

        public static Entity GetInvoice(Restaurant restaurant, Payment payment, Profile profile,
            float tip, float total, float tax, Currency currency, int number)
        {
            return new Invoice(restaurant, payment, profile,
            tip, total, tax, currency, number);
        }

        public static Entity GetInvoice(Restaurant restaurant, Payment payment, Profile profile,
            float total, float tax, Currency currency, int number)
        {
            return new Invoice(restaurant, payment, profile,
            total, tax, currency, number);
        }

        #endregion

        #region Restaurant

        //Instancia los objetos del dominio invocando al constructor(es) de la entidad
        public static Entity GetRestaurant()
        {
            return new Restaurant();
        }

        #endregion

        #region Menu

        //Instancia los objetos del dominio invocando al constructor(es) de la entidad

        #endregion

        #region Login

        //Instancia los objetos del dominio invocando al constructor(es) de la entidad

        #endregion
    }
}
