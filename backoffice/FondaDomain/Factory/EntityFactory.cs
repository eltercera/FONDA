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

        public static Account GetAccount()
        {
            return new Account();
        }

        public static Account GetAccount(Table table, Commensal commensal, IList<DishOrder> listOrder, int number)
        {
            return new Account(table, commensal, listOrder, number);
        }

        public static Account GetAccount(Table table, IList<DishOrder> listOrder)
        {
            return new Account(table, listOrder);
        }

        public static Entity GetInvoice()
        {
            return new Invoice();
        }

        public static Invoice GetInvoice(/*Restaurant restaurant, */Payment payment, Profile profile,
            float tip, float total, float tax, Currency currency, int number)
        {
            return new Invoice(/*restaurant,*/ payment, profile,
            tip, total, tax, currency, number);
        }

        public static Invoice GetInvoice(/*Restaurant restaurant, */Payment payment, Profile profile,
            float total, float tax, Currency currency, int number)
        {
            return new Invoice(/*restaurant,*/ payment, profile,
            total, tax, currency, number);
        }

        public static Invoice GetInvoice(int id, Payment payment, Profile profile, float tip,
            float total, float tax, int number)
        {
            return new Invoice(id, payment, profile,
            tip, total, tax, number);
        }
        #endregion

        #region Restaurant

        //Instancia los objetos del dominio invocando al constructor(es) de la entidad
        public static Restaurant GetRestaurant()
        {
            return new Restaurant();
        }

        #endregion

        #region Menu

        //Instancia los objetos del dominio invocando al constructor(es) de la entidad

        #endregion

        #region Login

        //Instancia los objetos del dominio invocando al constructor(es) de la entidad
        public static Employee GetEmployee()
        {
            return new Employee();
        }

        public static Role GetRole()
        {
            return new Role();
        }
        #endregion

        #region LoginFO
        //Instancia de Commensal
        public static Commensal GetCommensal()
        {
            return new Commensal();
        }
        //Instancia de Token
        public static Token GetToken()
        {
            return new Token();
        }
        //Instancia de Profile
        public static Profile GetProfile()
        {
            return new Profile();
        }
        #endregion

        #region Favorito
        //Instancia de UserAccount
        public static UserAccount GetUserAccount()
        {
            return new UserAccount();
        }
        //Instancia de RestaurantCategory
        public static RestaurantCategory GetCategoryRestaurent()
        {
            return new RestaurantCategory();
        }
        #endregion
    }
}
