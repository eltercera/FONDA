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
    public class CurrentOrderFondaWebApiController : FondaWebApi
    {
        public CurrentOrderFondaWebApiController() : base() { }

        [Route("listDishOrder")]
        [HttpGet]
          public IHttpActionResult getListDishOrder()
          {

            Account account = new Account();
                        
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

            account.addDish(dishO1);
            account.addDish(dishO2);
            account.addDish(dishO3);
              
              return Ok(account.ListDish);
          }
    }
}
