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
    public class HistoryVisitsFondaWebApiController : FondaWebApi
    {
        public HistoryVisitsFondaWebApiController() : base() { }

        [Route("historyVisits")]
        [HttpGet]
          public IHttpActionResult getHistoryVisits()
          {

             
              DateTime date1 = new DateTime(2016, 06, 10);

              /*   Person person = new Person();
                 person.Name = "Adriana";
                 person.LastName = "Da Rocha";
               */

              Profile profile = new Profile();
              //   profile.Person = person;
              profile.ProfileName = "Adriana Da Rocha";
           
              RestaurantCategory category1 = new RestaurantCategory();
              category1.NameCategory = "Romantico";

              RestaurantCategory category2 = new RestaurantCategory();
              category2.NameCategory = "Casual";

              RestaurantCategory category3 = new RestaurantCategory();
              category3.NameCategory = "Italiano";

              RestaurantCategory category4 = new RestaurantCategory();
              category4.NameCategory = "Americano";


              Restaurant restaurant1 = new Restaurant();
           
              restaurant1.Name = "The dining room";
              restaurant1.Address = "La Castellana";
              restaurant1.RestaurantCategory = category2;
              restaurant1.Logo = "ic_restaurant001";

              Restaurant restaurant2 = new Restaurant();
              restaurant2.Name = "Mogi Mirin";
              restaurant2.Address = "Los Dos Caminos";
              restaurant2.RestaurantCategory = category1;
              restaurant2.Logo = "ic_restaurant002";

              Restaurant restaurant3 = new Restaurant();
              restaurant3.Name = "Gordo & Magro";
              restaurant3.Address = "La California";
              restaurant3.RestaurantCategory = category3;
              restaurant3.Logo = "ic_restaurant003";

              Restaurant restaurant4 = new Restaurant();
              restaurant4.Name = "La Casona";
              restaurant4.Address = "Parque Central";
              restaurant4.RestaurantCategory = category3;
              restaurant4.Logo = "ic_restaurant004";

              Restaurant restaurant5 = new Restaurant();
              restaurant5.Name = "Tony's";
              restaurant5.Address = "El Rosal";
              restaurant5.RestaurantCategory = category4;
              restaurant5.Logo = "ic_restaurant005";
 
           
              Invoice invoice1 = new Invoice();
              invoice1.Profile = profile;
              invoice1.Restaurant = restaurant1;
              invoice1.Tip = 300;
              invoice1.Tax = 50;
              invoice1.Total = 350;
              invoice1.Date = date1.ToUniversalTime();

              Invoice invoice2 = new Invoice();
              invoice2.Profile = profile;
              invoice2.Restaurant = restaurant2;
              invoice2.Tip = 300;
              invoice2.Tax = 50;
              invoice2.Total = 350;
              invoice2.Date = date1.ToUniversalTime();

              Invoice invoice3 = new Invoice();
              invoice3.Profile = profile;
              invoice3.Restaurant = restaurant3;
              invoice3.Tip = 300;
              invoice3.Tax = 50;
              invoice3.Total = 350;
              invoice3.Date = date1.ToUniversalTime();

              Invoice invoice4 = new Invoice();
              invoice4.Profile = profile;
              invoice4.Restaurant = restaurant4;
              invoice4.Tip = 300;
              invoice4.Tax = 50;
              invoice4.Total = 350;
              invoice4.Date = date1.ToUniversalTime();

              Invoice invoice5 = new Invoice();
              invoice5.Profile = profile;
              invoice5.Restaurant = restaurant5;
              invoice5.Tip = 300;
              invoice5.Tax = 50;
              invoice5.Total = 350;
              invoice5.Date = date1.ToUniversalTime();

              Invoice invoice6 = new Invoice();
              invoice6.Profile = profile;
              invoice6.Restaurant = restaurant1;
              invoice6.Tip = 300;
              invoice6.Tax = 50;
              invoice6.Total = 350;
              invoice6.Date = date1.ToUniversalTime();
            
              List<Invoice> lista = new List<Invoice>();
              lista.Add(invoice1);
              lista.Add(invoice2);
              lista.Add(invoice3);
              lista.Add(invoice4);
              lista.Add(invoice5);
              lista.Add(invoice6);
              
              return Ok(lista);
          }
    }
    
}
