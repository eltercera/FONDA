using System;
using System.Web.Http;
using System.Linq;
using System.Collections;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.BackEnd.ActionFilters;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System.Collections.Generic;
using Newtonsoft.Json;
using com.ds201625.fonda.Factory;

namespace com.ds201625.fonda.BackEnd.Controllers
{
    [RoutePrefix("api")]
    /// <summary>
    /// clase que controla la api del ws
    /// </summary>
    public class InvoiceFondaWebApiController : FondaWebApi
    {
        /// <summary>
        /// Metodo que controla el pago de la orden
        /// </summary>
        public InvoiceFondaWebApiController() : base() { }

        //[Route("currentInvoice")]
        //[HttpGet]
        ///// <summary>
        /////Metodo que obtiene el pago de la orden
        ///// </summary>
        ///// <returns> pago de la orden</returns>
        //  public IHttpActionResult getCurrentInvoice()
        //  {
        //    DateTime date1 = new DateTime(2016, 05, 16);

        //    Person person = new Person();
        //    person.Name = "Adriana";
        //    person.LastName = "Da Rocha";
        //    person.Ssn = "20.123.134";

        //    Profile profile = new Profile();
        //    profile.ProfileName = "Adriana";
        //    profile.Person = person;            
            

        //    RestaurantCategory category2 = new RestaurantCategory();
        //    category2.Name = "Casual";            

        //    Restaurant restaurant1 = new Restaurant();

        //    restaurant1.Name = "The dining room";
        //    restaurant1.Address = "La Castellana";
        //    restaurant1.RestaurantCategory = category2;


        //    Dish dish1 = new Dish();
        //    dish1.Name = "Pasta";
        //    dish1.Description = "Pasta Con Salmon";
        //    dish1.Cost = 1000;

        //    Dish dish2 = new Dish();
        //    dish2.Name = "Refresco";
        //    dish2.Description = "Coca-Cola";
        //    dish2.Cost = 100;

        //    Dish dish3 = new Dish();
        //    dish3.Name = "Torta";
        //    dish3.Description = "Terciopelo Rojo";
        //    dish3.Cost = 500;

        //    DishOrder dishO1 = new DishOrder();
        //    dishO1.Dish = dish1;
        //    dishO1.Count = 1;

        //    DishOrder dishO2 = new DishOrder();
        //    dishO2.Dish = dish2;
        //    dishO2.Count = 1;

        //    DishOrder dishO3 = new DishOrder();
        //    dishO3.Dish = dish3;
        //    dishO3.Count = 1;
           
            
        //      List<DishOrder> lista = new List<DishOrder>();
        //      lista.Add(dishO1);
        //      lista.Add(dishO2);
        //      lista.Add(dishO3);

        //    Table table = new Table();
        //    table.Number = 1;

        //    Account account = (Account) EntityFactory.GetAccount(table, lista);

        //    Currency currency = new Currency();
        //    currency.Name = "Bolivar";
        //    currency.Symbol = "Bs.";

        //    Invoice invoice1 = (Invoice)EntityFactory.GetInvoice(null,

        //    profile, 179, 1971, 192, currency, 2);


        //    return Ok(invoice1);
        //  }
    }
}
