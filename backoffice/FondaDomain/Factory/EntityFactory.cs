using com.ds201625.fonda.Domain;

namespace com.ds201625.fonda.Factory
{
    /// <summary>
    /// Fabricada que instancia las entidades del dominio
    /// </summary>
    public class EntityFactory
    {
        #region OrderAccount

        //Instancia los objetos del dominio invocando al constructor(es) de la entidad

        public static Entity GetOrderAccount()
        {
            return new Account();
        }

        public static Entity GetInvoice()
        {
            return new Invoice();
        }

        public static Entity GetInvoice(Restaurant restaurant, Payment payment, Account account, Profile profile,
            float tip, float total, float tax, Currency currency, int number)
        {
            return new Invoice(restaurant, payment, account, profile,
            tip, total, tax, currency, number);
        }

        public static Entity GetInvoice(Restaurant restaurant, Payment payment, Account account, Profile profile,
            float total, float tax, Currency currency, int number)
        {
            return new Invoice(restaurant, payment, account, profile,
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
