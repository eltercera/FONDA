using com.ds201625.fonda.Domain;
using System;
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

        public static Invoice GetInvoice()
        {
            return new Invoice();
        }

        public static Invoice GetInvoice(Payment payment, Profile profile,
         float total, float tax, Currency currency, int number, InvoiceStatus status)
        {
            return new Invoice(payment, profile,
             total, tax, currency, number, status);
        }

        public static Invoice GetInvoice(Payment payment, Profile profile,
            float total, float tax, Currency currency, int number)
        {
            return new Invoice(payment, profile,
            total, tax, currency, number);
        }

        public static Invoice GetInvoice(int id, Payment payment, Profile profile,
            float total, float tax, Currency currency, int number)
        {
            return new Invoice(id, payment, profile,
             total, tax, currency, number);
        }

        public static CashPayment GetCashPayment(float amount)
        {
            return new CashPayment(amount);
        }

        public static CreditCardPayment GetCreditCardPayment(float amount, int lastDigits, float tip)
        {
            return new CreditCardPayment(amount, lastDigits, tip);
        }

        #endregion

        #region Restaurant

        //Instancia los objetos del dominio invocando al constructor(es) de la entidad
        public static Restaurant GetRestaurant()
        {
            return new Restaurant();
        }

        public static RestaurantCategory GetRestCategory(string name)
        {
            RestaurantCategory _restCategory = new RestaurantCategory();
            _restCategory.Name = name;
            return _restCategory;
        }

        public static Zone GetRestzone(string name)
        {
            Zone _zone = new Zone();
            _zone.Name = name;
            return _zone;
        }

        public static Currency GetRestCurrency(string name)
        {
            Currency _currency = new Currency();
            _currency.Name = name;
            return _currency;
        }

        public static Schedule GetRestSchedule (TimeSpan OpeningTime, TimeSpan ClosingTime, IList<Day> listDays)
        {
            Schedule _schedule = new Schedule();
            _schedule.OpeningTime = OpeningTime;
            _schedule.ClosingTime = ClosingTime;
            _schedule.Day = listDays;
            return _schedule;            
        }

        public static Coordinate GetCoordinate(double Long, double Lat)

        {
            Coordinate coordinat = new Coordinate();
            coordinat.Latitude = Lat;
            coordinat.Longitude = Long;
            return coordinat;
        }
        
        public static Restaurant GetGenerateRestaurant(string Name, string Logo, char Nationality, string Rif, string Address, RestaurantCategory category, Currency currency, Zone zone, Coordinate coordinate, Schedule schedule, SimpleStatus status)
        {
            Restaurant restaurant = new Restaurant();
            restaurant.Name = Name;
            restaurant.Logo = Logo;
            restaurant.Nationality = Nationality;
            restaurant.Ssn = Rif;
            restaurant.Address = Address;
            restaurant.RestaurantCategory = category;
            restaurant.Currency = currency;
            restaurant.Zone = zone;
            restaurant.Coordinate = coordinate;
            restaurant.Schedule = schedule;
            restaurant.Status = status;
            return restaurant;
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
        //Instancia de Person
        public static Person GetPerson()
        {
            return new Person();
        }
        //Instancia Arreglo de Tokens
        public static Token[] GetTokenA(int cant)
        {
            return new Token[cant];
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

        //Instancia de MenuCategory
        public static MenuCategory GetMenuCategory()
        {
            return new MenuCategory();
        }

        //Instancia de Dish
        public static Dish GetDish()
        {
            return new Dish();
        }
       

        //Instancia de Currency
        public static Currency GetCurrency()
        {
            return new Currency();
        }

        //Instancia de Coordinate
        public static  Coordinate GetCoordinate()
        {
            return new Coordinate();
        }

        //Instancia de Zone
        public static Zone GetZone()
        {
            return new Zone();
        }

        //Instancia de Shedule
        public static Schedule GetShedule()
        {
            return new Schedule();
        }

        #endregion
    }
}
