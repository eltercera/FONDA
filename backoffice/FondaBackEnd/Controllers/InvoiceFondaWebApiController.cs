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

namespace com.ds201625.fonda.BackEnd.Controllers
{
    [RoutePrefix("api")]
    public class InvoiceFondaWebApiController : FondaWebApi
    {
        public InvoiceFondaWebApiController() : base() { }

        [Route("currentInvoice")]
        [HttpGet]
          public IHttpActionResult getCurrentInvoice()
          {
            DateTime date1 = new DateTime(2016, 05, 16);

            Profile profile = new Profile();
            profile.ProfileName = "Adriana Da Rocha";

            RestaurantCategory category2 = new RestaurantCategory();
            category2.NameCategory = "Casual";            

            Restaurant restaurant1 = new Restaurant();

            restaurant1.Name = "The dining room";
            restaurant1.Address = "La Castellana";
            restaurant1.RestaurantCategory = category2;


            Dish dish1 = new Dish();
            dish1.Name = "Pasta";
            dish1.Description = "Pasta Con Salmon";
            dish1.Cost = 1000;

            Dish dish2 = new Dish();
            dish2.Name = "Refresco";
            dish2.Description = "Coca-Cola";
            dish2.Cost = 100;

            Dish dish3 = new Dish();
            dish3.Name = "Torta";
            dish3.Description = "Terciopelo Rojo";
            dish3.Cost = 500;

            DishOrder dishO1 = new DishOrder();
            dishO1.Dish = dish1;
            dishO1.Count = 1;

            DishOrder dishO2 = new DishOrder();
            dishO2.Dish = dish2;
            dishO2.Count = 1;

            DishOrder dishO3 = new DishOrder();
            dishO3.Dish = dish3;
            dishO3.Count = 1;
           
            
              List<DishOrder> lista = new List<DishOrder>();
              lista.Add(dishO1);
              lista.Add(dishO2);
              lista.Add(dishO3);

            Table table = new Table();
            table.Number = 1;

            Account account = new Account();
            account.Table = table;
            account.ListDish = lista;

            Currency currency = new Currency();
            currency.Name = "Bolivar";
            currency.Symbol = "Bs.";

            Invoice invoice1 = new Invoice();
            invoice1.Profile = profile;
            invoice1.Restaurant = restaurant1;
            invoice1.Tip = 179;
            invoice1.Tax = 192;
            invoice1.Total = 1971;
            invoice1.Date = date1.ToUniversalTime();
            invoice1.Account = account;
            invoice1.Currency = currency;


            return Ok(invoice1);
          }
    }
}
